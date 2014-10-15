using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANNPrediction.Entities
{
    public class StaticReporting
    {
        private List<double> _listError = new List<double>();
        private double _min = double.MaxValue;
        private double _max = double.MinValue;
        private double _totalVaule = 0;


        public void Add(double p)
        {
             _listError.Add(p);
            if (_max < p)
                _max = p;
            if (_min > p)
                _min = p;

            _totalVaule += p;
        }
        public void Add(List<PredictionResults> p)
        {
            foreach (var predictionResultse in p)
            {
                Add(Math.Abs(predictionResultse.Error));
            }
        }
        public void Clean()
        {
            _listError.Clear();
            _min = double.MaxValue;
            _max = double.MinValue;
            _totalVaule = 0;
        }

        public double Max { get { return _max; } }
        public double Min { get { return _min; } }

        public double GetMVD()
        {
            if (_listError.Count == 0) return double.MinValue;
            return _totalVaule/_listError.Count;
        }
        public double GetSDD()
        {
            if (_listError.Count == 0) return double.MinValue;
            var a = GetMVD();
            double tl = 0;
            foreach (var d in _listError)
            {
                tl += Math.Pow((d - a), 2);
            }
            return Math.Sqrt(tl/_listError.Count);
        }
        public double GetMDD()
        {
            if (_listError.Count == 0) return double.MinValue;
            var a = GetMVD();
            double tl = 0;
            foreach (var d in _listError)
            {
                tl += Math.Abs(d - a);
            }
            return tl / _listError.Count;
        }
    }
}
