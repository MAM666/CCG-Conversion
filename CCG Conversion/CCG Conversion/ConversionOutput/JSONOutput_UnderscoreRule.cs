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
    public class JSONOutput_UnderscoreRule : JSONOutputBase
    {
        public JSONOutput_UnderscoreRule(string outputFileName)
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
            JArray child = null;
            JObject row = new JObject();
            string childName = "";
            string newKey;
            for (int r = 0; r < data.Count(); r++)
            {

                int splitPos = Headers[r].IndexOf("_");
                if (splitPos > -1)
                {
                    string newChildName = Headers[r].Substring(0, splitPos);
                    newKey = Headers[r].Substring(splitPos + 1);
                    if (!newChildName.CompareTo(childName).Equals(0))
                    {
                        childName = newChildName;
                        child = new JArray();
                    }
                    JObject childRow = new JObject
                    {
                        { newKey, data[r] }
                    };
                    child.Add(childRow);
                }
                else
                {
                    row.Add(Headers[r], data[r]);
                }
            }
            if (child != null)
                row.Add(childName, child);

            return row;
        }
    }
}
