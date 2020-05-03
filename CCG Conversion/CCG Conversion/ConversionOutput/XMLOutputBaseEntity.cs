using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ConversionOutput
{
    /// <summary>
    /// Provides a base for model configurations.
    /// </summary>
    /// <typeparam name="Entity">The type of the entity object.</typeparam>
    public abstract class XMLOutputBase<Entity> : Output, IOutput where Entity : class
    {
        public XMLOutputBase(string outputFileName)
            : base(outputFileName)
        {
        }

        /// <summary>
        /// Output Results
        /// </summary>
        public List<Entity> Results { get; private set; }

        /// <summary>
        /// Process to XML if we can.
        /// Default it to the using _ pattern in header names for child splits.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public virtual bool Process(string[] lines)
        {

            if (lines == null || lines.Count() < 2)
                return false;

            Results = new List<Entity>();

            // loop the data
            for (int row = 1; row < lines.Count(); row++)
            {
                Results.Add(GetRowElement(lines[row].Split(',')));
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

            System.Xml.Serialization.XmlSerializer writer =
                        new System.Xml.Serialization.XmlSerializer(typeof(List<Entity>));

            FileStream file = File.Create(@FileName);

            writer.Serialize(file, Results);
            file.Close();
            Results = null;
        }

        /// <summary>
        /// Build each data row model
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal abstract Entity GetRowElement(string[] data);

    }
}
