// ciumac.sergiu@gmail.com

using System;
using System.Collections.Generic;
using Encog.ML.Data;

namespace ANNPrediction.Entities
{
    /// <summary>
    /// Class for error calculation
    /// </summary>
    public class ErrorCalculation
    {
        /// <summary>
        /// The current error level.
        /// </summary>
        private double _globalError;

        private double _globalErrorA;
        /// <summary>
        /// The size of a training set.
        /// </summary>
        private int _setSize;

        /// <summary>
        /// Returns the root mean square error for a complete training set.
        /// </summary>
        /// <returns>The current error for the neural network.</returns>
        public double CalculateMSE()
        {
            return _globalError/(_setSize);
        }

        public double CalculateRMSE()
        {
            return Math.Sqrt(_globalError / (_setSize));
        }
        public double CalculateMAE()
        {
            return _globalErrorA/ (_setSize);
        }

        /// <summary>
        /// Reset the error accumulation to zero.
        /// </summary>
        public void Reset()
        {
            _globalError = _setSize = 0;
        }

        /// <summary>
        /// Called to update for each number that should be checked.
        /// </summary>
        /// <param name="actual">The actual number.</param>
        /// <param name="ideal">The ideal number.</param>
        public void UpdateError(double[] actual, double[] ideal)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                double delta = ideal[i] - actual[i];
                _globalError += delta * delta;
            }
            _setSize += ideal.Length;
        }
        public void UpdateError(double[] actual, IMLData ideal)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                double delta = ideal[i] - actual[i];
                _globalError += delta * delta;
            }
            _setSize += ideal.Count;
        }

        public void UpdateError(List<PredictionResults> results)
        {
            foreach (var result in results)
            {
                var a = result.PredictedValue;
                var bn = result.ActualValue ;
                //double delta = result.PredictedValue - result.ActualValue;
                double delta = a - bn;
                _globalError += delta*delta;
                _globalErrorA += Math.Abs(delta);
            }
            _setSize += results.Count;
        }
    }
    

    public class MyError
    {
        public double value { get; set; }
        public int index { get; set; }
    }
}
