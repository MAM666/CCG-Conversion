using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.Helpers
{
    public interface  IInputHelper
    {
        /// <summary>
        /// Check if it is the required params for that Conversion.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        bool CheckItsTypeConversion(string[] args);

        /// <summary>
        /// Process the data
        /// </summary>
        /// <returns></returns>
        bool Process();
    }
}
