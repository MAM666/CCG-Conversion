using Newtonsoft.Json.Linq;
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
    public class JSONOutputRegular : JSONOutputBase
    {
        public JSONOutputRegular(string outputFileName)
            : base(outputFileName)
        {
        }

        /// <summary>
        /// Specifically to use Person Model.
        /// </summary>
        /// <param name="data">row of data</param>
        /// <returns></returns>
        internal override JObject GetRowElement(string[] data)
        {
            JObject row = new JObject();
            for (int r = 0; r < data.Count(); r++)
            {
                row.Add(Headers[r], data[r]);
            }
            return row;
        }
    }
}
