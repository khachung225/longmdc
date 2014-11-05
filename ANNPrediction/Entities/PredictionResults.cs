
// ciumac.sergiu@gmail.com
using System;

namespace ANNPrediction.Entities

{
    /// <summary>
    /// Prediction results
    /// </summary>
    public class PredictionResults
    {
        #region Properties
        

        /// <summary>
        /// Actual percentage move
        /// </summary>
        public double ActualValue {get; set; }
   
        /// <summary>
        /// Predicted percentage move
        /// </summary>
        public double PredictedValue {get; set; }

        public double Distance { get; set; }

        /// <summary>
        /// Error between predicted and actual values
        /// </summary>
        public double Error { get; set; }

        #endregion
    }
}
