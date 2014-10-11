using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANNPrediction.Entities
{
    [Serializable]
    public class PredicData
    {
        private readonly List<double> _listData = new List<double>(); 

        public int Count{
            get { return _listData.Count; }}

        public void Add(double ad)
        {
            _listData.Add(ad);
        }

        public double GetData(int index)
        {
            if (index >= _listData.Count)
                return -1;
            return _listData[index];
        }
        public void SetData(double value,int index)
        {
            if (index >= _listData.Count)
                return;
            _listData[index] = value;
        }
    }
}
