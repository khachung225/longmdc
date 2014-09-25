using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANNPrediction.Entities
{
    public class Correlation
    {
        private double Tx { get; set; }
        private double Ty { get; set; }

        private List<CorPoint> listpiont = new List<CorPoint>();
        public void Add(PredictionResults p)
        {
            listpiont.Add(new CorPoint(p.ActualValue,p.PredictedValue));
            Tx += p.ActualValue;
            Ty += p.PredictedValue;
        }
        public void Add(List<PredictionResults> p)
        {
            foreach (var predictionResultse in p)
            {
                Add(predictionResultse);
            }
        }
        public void Clean()
        {
            listpiont.Clear();
            Tx = 0;
            Ty = 0;
        }
        public double GetCorrelation()
        {
            var cout = listpiont.Count;
            var tbx = Tx/cout;
            var tby = Ty/cout;
            double tuso = 0;
            double mauso1 = 0;
            double mauso2 = 0;
            foreach (var corPoint in listpiont)
            {
                var a = corPoint.X - tbx;
                var b = corPoint.Y - tby;

                tuso += a*b;
                mauso1 += a*a;
                mauso2 += b*b;
            }
            if (mauso1 != 0 && mauso2 != 0)
            {
                return tuso/Math.Sqrt(mauso1*mauso2);
            }
            return 0;
        }
    }
    public class CorPoint
{
        public CorPoint(){}
        public CorPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
}
}
