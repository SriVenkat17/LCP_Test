using System.Collections.Generic;

//Feedback

//Please provide brief comments for the Class and Methods - will make the usage easier and quicker
//Exception handling - Use try catch to handle exceptions and if required save it for diagnostics and troubleshooting

//Please consider extracting this section to a separate method so that it could be re-used across all other methods where required, refer example method: GetProjectionsExample
/*
 double[] totalYearlyProjections = Aggregator.AggregateYearlyProjections(totalProjection.TotalProjections, listOfInputs);
 return Aggregator.GetTotalSum(totalYearlyProjections);
*/

//
//Consider using a custom type instead of List<double[]> similar to List<Input>

namespace Test
{
    public class Calcs
    {
        private Engine _engine;

        public Calcs(Engine engine)
        {
            _engine = engine;
        }

        //Can be marked as Private if not needed to be called from an external class
        public double GetProjections(bool undiscountedProjection, List<Inputs> listOfInputs)
        {
            Result totalProjection = _engine.GetResultProjections(listOfInputs);

            if (undiscountedProjection)
            {
                double[] totalYearlyProjections = Aggregator.AggregateYearlyProjections(totalProjection.TotalProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyProjections);
            }
            else
            {
                double[] totalYearlyDiscountedProjections = Aggregator.AggregateYearlyProjections(totalProjection.TotalDiscountedProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyDiscountedProjections);
            }
        }
        
        public double GetRollForwardProjections(bool undiscountedProjection, int rollForwardYears, List<Inputs> listOfInputs)
        {
            Result totalRollForwardProjection = _engine.GetRollForwardProjections(listOfInputs, rollForwardYears);

            /* Consider re-using GetProjections method, example below between the commented area
      
            try
            {
                return GetProjections(undiscountedProjection, listOfInputs);
            }
            catch (System.Exception)
            {

                throw;
            }

             */

            if (undiscountedProjection)
            {
                double[] totalYearlyProjections = Aggregator.AggregateYearlyProjections(totalRollForwardProjection.TotalProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyProjections);
            }
            else
            {
                double[] totalYearlyDiscountedProjections = Aggregator.AggregateYearlyProjections(totalRollForwardProjection.TotalDiscountedProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyDiscountedProjections);
            }
        }

        /// <summary>
        /// Get projections based on the given parameters
        /// Preferable to use List<CustomType> instead of List<double[]> similar to List<Input> 
        /// </summary>
        /// <returns>Projection value in double</returns>
        private double GetProjectionsExample(List<double[]> listOfProjections, List<Inputs> listOfInput)
        {
            try
            {
                double[] totalYearlyDiscountedProjections = Aggregator.AggregateYearlyProjections(listOfProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyDiscountedProjections);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
