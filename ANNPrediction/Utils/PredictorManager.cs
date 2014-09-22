using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANNPrediction.Entities;
using BaseEntity.Utils;

namespace ANNPrediction.Utils
{
   public class PredictorManager:IDisposable
    {
       private int _inputSize;
       private int _dataSize;

       private int _outputSize;

       public int InputSize { get { return _inputSize; } }
       public int OutputSize { get { return _inputSize; } }

       public PredictorManager( int outputSize)
       {
            
           if (outputSize <= 0)
               throw new ArgumentException("outputSize cannot be less than 0");
         
           _outputSize = outputSize;

           
       }

       Dictionary<int, PredicData> _dictionary = new Dictionary<int, PredicData>();
       private int _diccount ;
       Dictionary<int, double> _dicMaxValue = new Dictionary<int, double>();
       Dictionary<int, double> _dicMinValue = new Dictionary<int, double>();
       private void LoadCSV(string fileData)
       {
           _dictionary = new Dictionary<int, PredicData>();
           _diccount = 0;
           using (CSVReader csv = new CSVReader(fileData))
           {
               while (csv.Next())
               {
                   if (csv.IsHasValue())
                   {
                       var sample = new PredicData();
                       int km = csv.Count();
                       _dataSize = km;
                       for (int i = 0; i < km; i++)
                       {
                           double amount = csv.GetDouble(i);
                           sample.Add(amount);

                           if (!_dicMaxValue.ContainsKey(i)) _dicMaxValue[i] = amount;
                           if (!_dicMinValue.ContainsKey(i)) _dicMinValue[i] = amount;
                           if (amount > _dicMaxValue[i]) _dicMaxValue[i] = amount;
                           if (amount < _dicMinValue[i]) _dicMinValue[i] = amount;
                       }


                       _dictionary[_diccount] = sample;
                       _diccount++;
                   }
               }
               csv.Close();
           }
           _inputSize = _dataSize - 1;
       }

       public List<PredicData> DataTest { get { return _dictionaryTest.Values.ToList(); } }
           
           Dictionary<int, PredicData> _dictionaryTest = new Dictionary<int, PredicData>();
       private void LoadCSVDataTest(string fileData)
       {
           _dictionaryTest = new Dictionary<int, PredicData>();
            var diccount = 0;
           int dataSize = 0;
           using (CSVReader csv = new CSVReader(fileData))
           {
               while (csv.Next())
               {
                   if (csv.IsHasValue())
                   {
                       var sample = new PredicData();
                       int km = csv.Count();
                       dataSize = km;
                       for (int i = 0; i < km; i++)
                       {
                           double amount = csv.GetDouble(i);
                           sample.Add(amount);

                           if (!_dicMaxValue.ContainsKey(i)) _dicMaxValue[i] = amount;
                           if (!_dicMinValue.ContainsKey(i)) _dicMinValue[i] = amount;
                           if (amount > _dicMaxValue[i]) _dicMaxValue[i] = amount;
                           if (amount < _dicMinValue[i]) _dicMinValue[i] = amount;
                       }


                       _dictionaryTest[diccount] = sample;
                       diccount++;
                   }
               }
               csv.Close();
           }
           
           if (dataSize != _dataSize)
           {
               throw new  NullReferenceException("Du lieu file test va file tranning khong tuong dong ve so dau vao.");
           }
       }
       public void Load(string fileData, string fileDataTest)
       {
           
           try
           {
               LoadCSV(fileData);
               //load data test.
               LoadCSVDataTest(fileDataTest);
           }
           catch
           {
               throw new NotSupportedException("Loading Data file failed.");
           }
           NormalizeData();
       }

     
       public int Size
       {
           get { return _dictionary.Count; }
       }


       public double GetMax(int index)
       {
           return _dicMaxValue[index];
       }

       public double GetMin(int index)
       {
           return _dicMinValue[index];
       }

       /// <summary>
       /// Normalize input data
       /// </summary>
       public void NormalizeData()
       {
           foreach (var t in _dictionary)
           {
               for (int index = 0; index < _dataSize; index++)
               {
                   var value = t.Value.GetData(index);
                   if (((value - _dicMinValue[index]) == 0) ||(_dicMaxValue[index] - _dicMinValue[index] == 0))
                       t.Value.SetData(0, index);
                   else 
                   {
                       value = (value - _dicMinValue[index])/(_dicMaxValue[index] - _dicMinValue[index]);
                       t.Value.SetData(value, index);
                   }
               }
           }
           foreach (var t in _dictionaryTest)
           {
               for (int index = 0; index < _dataSize; index++)
               {
                   var value = t.Value.GetData(index);
                   if ((value - _dicMinValue[index]) == 0)
                       t.Value.SetData(0, index);
                   else
                   {
                       value = (value - _dicMinValue[index]) / (_dicMaxValue[index] - _dicMinValue[index]);
                       t.Value.SetData(value, index);
                   }
               }
           }
       }


       public void GetInputData(int offset, double[] input)
       {
           int total = 0;
           int k = 0;
           // get SP500, prime data, NASDAQ, Dow
           
           var data = _dictionary[offset];
           for (int i = 0; i < _inputSize; i++)
           {
               input[i] = data.GetData(i);
               //input[i*4]       = sample.Sp;
               //input[i*4 + 1]   = sample.PrimeInterestRate;
               //input[i*4 + 2]   = sample.Commodity;
               //input[i*4 + 3]   = sample.VolumeCommo;
           }
       }


       public void GetOutputData(int offset, double[] output)
       {
           var data = _dictionary[offset];
           output[0] = data.GetData(_inputSize);
           //output[1] = sample.PrimeInterestRate;
           //output[2] = sample.Commodity;
           //output[3] = sample.VolumeCommo;

       }

       public void Dispose()
       {
           if (_dictionaryTest.Count > 0)
           {
               _dictionaryTest.Clear();
               _dictionaryTest = null;
           }
           if (_dicMaxValue.Count > 0)
           {
               _dicMaxValue.Clear();
               _dicMaxValue = null;
           }
           if (_dicMinValue.Count > 0)
           {
               _dicMinValue.Clear();
               _dicMinValue = null;
           }
           if (_dictionary.Count > 0)
           {
               _dictionary.Clear();
               _dictionary = null;
           }
       }
    }
}
