using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CCGConversion.ConversionOutput
{
    /// <summary>
    /// Just a straight XML Output file
    /// </summary>
    public class XMLOutputRegular : XMLOutputBase, IOutput
    {
        public XMLOutputRegular(string outputFileName)
            : base(outputFileName)
        {
        }

        /// <summary>
        /// Specifically to use NO Model.
        /// </summary>
        /// <param name="data">row of data</param>
        /// <returns></returns>
        internal override XElement GetRowElement(string[] data)
        {
            XElement row = new XElement("row");
            for (int r = 0; r < data.Count(); r++)
            {
                row.Add(new XElement(Headers[r], data[r]));
            }
            return row;
        }
    }
}
