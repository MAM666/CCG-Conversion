using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput.InputModelAssignments
{
    public static class XMLPatternsInput
    {
        /// <summary>
        /// Do we have the input pattern type covered. reader will now be Model Specific
        /// </summary>
        /// <returns>true - its covered : otherwise false</returns>
        internal static IInput AssignXMLReader(string inputPatternType, string filefullPath)
        {
            switch (inputPatternType)
            {
                case "person":
                    return new XMLInputPerson(filefullPath);
            }

            return null;
        }
    }
}
