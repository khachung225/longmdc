#define LOG_DATASET
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ANNPrediction.Entities;
using BaseEntity.Entity;
using BaseEntity.Utils;
using Encog.Engine.Network.Activation;
using Encog.Neural.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Encog.Neural.Networks.Training.Propagation.Resilient;

namespace ANNPrediction.Utils
{
    public delegate void TrainingStatus(int iteration, double error);

    public class PredictIndicators : IDisposable
    {
        #region Private Members

        /// <summary>
        /// Network to be trained
        /// </summary>
        private BasicNetwork _network;

        /// <summary>
        /// Input data S&P, Prime Interest Rate, Nasdaq, Dow indexes
        /// </summary>
        private double[][] _input;

        /// <summary>
        /// Desired output
        /// </summary>
        private double[][] _ideal;

        /// <summary>
        /// Financial market predictor
        /// </summary>
        private PredictorManager _manager;

        /// <summary>
        /// Training tread
        /// </summary>
        private Thread _trainThread;


        /// <summary>
        /// Size of the training data
        /// </summary>
        private int _trainingSize = 0;


        private List<MyError> listErr = new List<MyError>();

        #endregion

        private const int OUTPUT_SIZE = 1; // dau ra
        public int InputCount { get; set; }

        private double _maxErrorTrainning;
        private double _maxEpochTrainning;

        /// <summary>
        /// Gets the information about the predictor
        /// </summary>
        public bool Loaded { get; private set; }

        public PredictIndicators(string fileData, string fileDataTest, int hiddenLayers, List<int> neuralHidden,
                                 double maxError, int maxepoch)
        {
            if (!File.Exists(fileData))
                throw new ArgumentException(" targets an invalid file:" + fileData);

            _maxErrorTrainning = maxError;
            _maxEpochTrainning = maxepoch;

            /*Create new network*/
            _manager = new PredictorManager(OUTPUT_SIZE); /*Create new financial predictor manager*/
            _manager.Load(fileData, fileDataTest); /*Load data*/
            InputCount = _manager.InputSize;

            CreateNetwork(InputCount, hiddenLayers, neuralHidden);

            Loaded = true;
        }

        public void ReloadData(string urlFile)
        {
            if (!File.Exists(urlFile))
                throw new ArgumentException("targets an invalid file:" + urlFile);
        }


        /// <summary>
        /// Create a new network
        /// </summary>
        private void CreateNetwork(int inputCount, int hiddenLayers, List<int> neuralHidden)
        {
            _network = new BasicNetwork();
            _network.AddLayer(new BasicLayer(inputCount)); /*Input*/
            for (int i = 0; i < hiddenLayers; i++)
                _network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, neuralHidden[i]));
                    /*Hidden layer ActivationTANH  ActivationSigmoid*/
            _network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, OUTPUT_SIZE)); /*Output of the network*/
            _network.Structure.FinalizeStructure(); /*Finalize network structure*/
            _network.Reset(); /*Randomize*/
        }



        public void TrainNetworkAsync(TrainingStatus status)
        {
            Action<TrainingStatus> action = TrainNetwork;
            action.BeginInvoke(status, action.EndInvoke, action);
        }

        
        /// <summary>
        // Train network
        /// </summary>
        /// <param name="status">Delegate to be invoked</param>
        /// <param name="trainFrom">Train from</param>
        /// <param name="trainTo">Train to</param>
        private void TrainNetwork(TrainingStatus status)
        {
            if (_input == null || _ideal == null)
                CreateTrainingSets(); /*Create training sets, according to input parameters*/
            _trainThread = Thread.CurrentThread;
            int epoch = 1;
            listErr.Clear();

            ITrain train = null;
            try
            {

                var trainSet = new BasicNeuralDataSet(_input, _ideal);
                train = new ResilientPropagation(_network, trainSet);
                double error;
                do
                {
                    // train.AddStrategy();
                    train.Iteration();
                    error = train.Error;
                    if (status != null)
                        status.Invoke(epoch, error);

                    // if (LeanOverFitting.IsOverfilling(error))
                    //     AbortTraining();
                    listErr.Add(new MyError {index = epoch, value = error});
                     
                    if (epoch > _maxEpochTrainning){
                         
                        break;
                    }
                    epoch++;
                } while (error > _maxErrorTrainning);
            }
            catch (Exception ex)
            {
                /*Training aborted*/
                if (_trainThread != null) _trainThread.Abort();
                _trainThread = null;
            }
            finally
            {
                if (train != null) train.FinishTraining();

                //todo:ve do thi loi
            }
            if (_trainThread != null) _trainThread.Abort();
            _trainThread = null;
        }


        public void CreateTrainingSets()
        {
            // find where we are starting from

            // create a sample factor across the training area
            _trainingSize = _manager.Size;
            var inputsize = _manager.InputSize;
            _input = new double[_trainingSize][];
            _ideal = new double[_trainingSize][];

            // grab the actual training data from that point
            for (int i = 0; i < _trainingSize; i++)
            {
                _input[i] = new double[inputsize];
                _ideal[i] = new double[OUTPUT_SIZE];
                _manager.GetInputData(i, _input[i]);
                _manager.GetOutputData(i, _ideal[i]);
            }
#if LOG_DATASET
            using (StreamWriter writer = new StreamWriter("dataset.csv"), ideal = new StreamWriter("ideal.csv"))
            {
                for (int i = 0; i < _input.Length; i++)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int j = 0; j < _input[0].Length; j++)
                    {
                        builder.Append(_input[i][j]);
                        if (j != _input[0].Length - 1)
                            builder.Append(",");
                    }
                    writer.WriteLine(builder.ToString());

                    StringBuilder idealData = new StringBuilder();
                    for (int j = 0; j < _ideal[0].Length; j++)
                    {
                        idealData.Append(_ideal[i][j]);
                        if (j != _ideal[0].Length - 1)
                            idealData.Append(",");
                    }
                    ideal.WriteLine(idealData.ToString());
                }
            }
#endif

        }

        /// <summary>
        /// Abort training
        /// </summary>
        public void AbortTraining()
        {
            if (_trainThread != null) _trainThread.Abort();

        }

        /// <summary>
        /// Predict the results
        /// </summary>
        /// <returns>List with the prediction results</returns>
        public List<PredictionResults> Predict()
        {
            var results = new List<PredictionResults>();
            double[] present = new double[_manager.InputSize];
            double[] actualOutput = new double[OUTPUT_SIZE];
            int index = 0;
            foreach (var sample in _manager.DataTest)
            {

                var result = new PredictionResults();
                for (int i = 0; i < _manager.InputSize; i++)
                {
                    present[i] = sample.GetData(i);
                }
                actualOutput[0] = sample.GetData(_manager.InputSize);

                var data = new BasicNeuralData(present);
                var predict = _network.Compute(data);
                result.ActualValue = actualOutput[0]*
                                     (_manager.GetMax(_manager.InputSize) - _manager.GetMin(_manager.InputSize)) +
                                     _manager.GetMin(_manager.InputSize);
                result.PredictedValue = predict[0]*
                                        (_manager.GetMax(_manager.InputSize) - _manager.GetMin(_manager.InputSize)) +
                                        _manager.GetMin(_manager.InputSize);


                result.Error = result.PredictedValue - result.ActualValue; //
                results.Add(result);
                index++;
            }


            return results;
        }

        public double CalculateRMS(List<PredictionResults> results)
        {
            //tính lỗi
            ErrorCalculation error = new ErrorCalculation();
            error.Reset();
            error.UpdateError(results);
            return error.CalculateRMS();
        }


        public void Dispose()
        {
            if (listErr.Count > 0)
            {
                listErr.Clear();
                listErr = null;
            }
            if (_manager != null)
                _manager.Dispose();

            if (_network != null)
                _network = null;
        }
    }
}
