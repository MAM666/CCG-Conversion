using CCGConversion.ConversionOutput.OutputModel;
using CCGConversion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ConversionOutput
{

    /// <summary>
    /// Specifically a JSON Person Output file
    /// </summary>
    public class JSONOutputPerson : JSONOutputBase<Person>
    {
        public JSONOutputPerson(string outputFileName) 
            : base(outputFileName)
        {
        }

        /// <summary>
        /// Specifically to use Person Model.
        /// </summary>
        /// <param name="data">row of data</param>
        /// <returns></returns>
        internal override Person GetRowElement(string[] data)
        {
            return RowPerson.GetRowElement(data);
        }
    }
}
