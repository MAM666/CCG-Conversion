using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ConversionOutput.OutputModelAssignments
{
    public static class XMLPatternsOutput
    {
        /// <summary>
        /// Do we have the input pattern type covered. writer will now be Model Specific
        /// </summary>
        /// <returns>true - its covered : otherwise false</returns>
        public static IOutput AssignXMLWriter(string inputPatternType, string outputFileName, string inputType)
        {
            switch (inputPatternType)
            {
                case "_":
                    return new XMLOutput_UnderscoreRule(outputFileName.Replace("." + inputType, ".xml"));

                case "person":
                    return new XMLOutputPerson(outputFileName.Replace("." + inputType, ".xml"));
            }

            return new XMLOutputRegular(outputFileName.Replace("." + inputType, ".xml")); ;
        }

    }
}
