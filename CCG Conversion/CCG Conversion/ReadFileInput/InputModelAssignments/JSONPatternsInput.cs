using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput.InputModelAssignments
{
    public static class JSONPatternsInput
    {


        /// <summary>
        /// Do we have the input pattern type covered. reader will now be Model Specific
        /// </summary>
        /// <returns>true - its covered : otherwise false</returns>
        internal static IInput AssignJSONReader(string inputPatternType, string filefullPath)
        {
            switch (inputPatternType)
            {
                case "person":
                    return new JSONInputPerson(filefullPath);
            }

            return null;
        }
    }
}
