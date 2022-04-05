using System;
using System.Collections.Generic;

//Feedback
//using regions for code segregation looks good
//Please provide brief comments for the Class and Methods - will make the usage easier and quicker
//Exception handling - Use try catch to handle exceptions and if required save it for diagnostics and troubleshooting
//Using List instead of Array - this might make the program easier to read and maintain (no harm in using Arrays however)
//Decimal or double - if this is a money related operation decimal might provide the required precision

namespace Test.Discounter
{
    /// <summary>
    /// Provides methods for Discounted value calculation
    /// </summary>
    public class DiscountEndOfYear:Discounter,IDiscounter
    {
        #region Constructor
        public DiscountEndOfYear(Projector projector) 
            : base(projector)
        {
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates discounted values for the given Inflated Cost with decrement
        /// </summary>
        /// <param name="inflatedCostWithDecrement">Inflated Cost with Decrement</param>
        /// <returns></returns>
        public double[] GetDiscountedValue(double[] inflatedCostWithDecrement)
        {
            try
            {
                double[] value = inflatedCostWithDecrement;

                for (int i = 0; i < value.Length; i++)
                {
                    value[i] = value[i] * GetDiscountFactor(i);
                }

                return value;
            }
            catch (Exception ex)
            {
                //log or throw exception as appropriate
                throw;
            }
        }

        #endregion

        #region Private Methods
        private double GetDiscountFactor(int refNumber)
        {
            return Math.Pow(((100+Projector.Inputs.DiscountRate)/100),-(refNumber+1));
        }
        #endregion
    }
}