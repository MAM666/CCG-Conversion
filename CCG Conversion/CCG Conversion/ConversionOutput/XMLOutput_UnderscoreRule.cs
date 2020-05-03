using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CCGConversion.ConversionOutput
{
    /// <summary>
    /// XML Output file with '_' rule for making child elements.
    /// </summary>
    public class XMLOutput_UnderscoreRule : XMLOutputBase, IOutput
    {
        public XMLOutput_UnderscoreRule(string outputFileName)
            : base(outputFileName)
        {
        }

        /// <summary>
        /// Specifically to use '_' rule.
        /// </summary>
        /// <param name="data">row of data</param>
        /// <returns></returns>
        internal override XElement GetRowElement(string[] data)
        {
            XElement child = null;
            XElement row = new XElement("row");
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
                        child = new XElement(childName);
                    }
                    child.Add(new XElement(newKey, data[r]));
                }
                else
                {
                    row.Add(new XElement(Headers[r], data[r]));
                }
            }
            if (child != null)
                row.Add(child);

            return row;
        }
    }
}
