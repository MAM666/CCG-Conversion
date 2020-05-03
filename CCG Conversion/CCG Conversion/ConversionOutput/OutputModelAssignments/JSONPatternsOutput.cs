using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ConversionOutput.OutputModelAssignments
{

    public static partial class JSONPatternsOutput
    {

        /// <summary>
        /// Do we have the input pattern type covered. writer will now be Model Specific
        /// </summary>
        /// <returns>true - its covered : otherwise false</returns>
        public static IOutput AssignJSONWriter(string inputPatternType, string outputFileName, string inputType)
        {
            switch (inputPatternType)
            {
                case "_":
                    return new JSONOutput_UnderscoreRule(outputFileName.Replace("." + inputType, ".json"));

                case "person":
                    return new JSONOutputPerson(outputFileName.Replace("." + inputType, ".json"));
            }

            return new JSONOutputRegular(outputFileName.Replace("." + inputType, ".json"));
        }

    }
}
