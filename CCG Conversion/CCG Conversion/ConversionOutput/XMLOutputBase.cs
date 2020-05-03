using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CCGConversion.ConversionOutput
{
    /// <summary>
    /// Provides a base for model configurations.
    /// </summary>
    /// <typeparam name="Entity">The type of the entity object.</typeparam>
    public abstract class XMLOutputBase : Output, IOutput
    {
        public XMLOutputBase(string outputFileName)
            : base(outputFileName)
        {
        }

        /// <summary>
        /// Output Results
        /// </summary>
        public virtual XElement Results { get; private set; }

        /// <summary>
        /// Column names
        /// </summary>
        public virtual string[] Headers { get; private set; }
        
        /// <summary>
        /// Process to XML if we can.
        /// Default it to the using _ pattern in header names for child splits.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public virtual bool Process(string[] lines)
        {

            if (lines == null || lines.Count() < 2)
            {
                return false;
            }

            Results = new XElement("header");

            Headers = lines[0].Split(',');
            // loop the data
            for (int row = 1; row < lines.Count(); row++)
            {
                Results.Add( GetRowElement(lines[row].Split(',')) );
            }

            if (!string.IsNullOrEmpty(FileName))
            {
                SaveToFile();
            }

            return true;
        }

        /// <summary>
        /// Save the XML to File.
        /// </summary>
        private void SaveToFile()
        {
            if (File.Exists(@FileName))
                File.Delete(@FileName);

            Results.Save(@FileName);
            Results = null;
        }

        /// <summary>
        /// Build each data row model
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal abstract XElement GetRowElement(string[] data);

    }

}
