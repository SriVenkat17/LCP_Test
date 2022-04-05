using System.Collections.Generic;
using System.Linq;

//Feedback

//Please provide brief comments for the Class and Methods - will make the usage easier and quicker
//Exception handling - Use try catch to handle exceptions and if required save it for diagnostics and troubleshooting

//Please check if the class can be static as well since there is only one static method

namespace Test
{
    public class MaximumTermOfProjection
    {
        public static int SetTermOfProjection(List<Inputs> listOfInputs)
        {
            List<int> termOfProjections = new List<int>(4);
            foreach (Inputs input in listOfInputs)
            {
                int termOfProjection = input.Time;
                termOfProjections.Add(termOfProjection);
            }
            
            int[] arrayOfTerms = termOfProjections.ToArray();

            int maximumTerm = arrayOfTerms.Max();
            return maximumTerm;
        }
    }
}