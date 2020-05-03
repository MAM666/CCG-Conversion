using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCGConversion.ConversionTypes;
using Newtonsoft.Json.Linq;

namespace CCGConversion.ConversionOutput
{

    /// <summary>
    /// Provides a base for model configurations.
    /// </summary>
    /// <typeparam name="Entity">The type of the entity object.</typeparam>
    public abstract class JSONOutputBase : Output, IOutput
    {
        public JSONOutputBase(string outputFileName)
            : base(outputFileName)
        {
        }

        /// <summary>
        /// Output Results
        /// </summary>
        public virtual JObject Results { get; set; }

        /// <summary>
        /// Column names
        /// </summary>
        public virtual string[] Headers { get; private set; }

        public virtual bool Process(string[] lines)
        {
            if (lines == null || lines.Count() < 2)
                return false;

            Headers = lines[0].Split(',');
            Results = new JObject();
            var jHeader = new JArray();

            // loop the data
            for (int row = 1; row < lines.Count(); row++)
            {
                jHeader.Add(GetRowElement(lines[row].Split(',')));
            }
            Results["header"] = jHeader;

            if (!string.IsNullOrEmpty(FileName))
            {
                SaveToFile();
            }

            return true;
        }

        /// <summary>
        /// Save the JSON to File.
        /// </summary>
        private void SaveToFile()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };

            string json = JsonConvert.SerializeObject(Results, settings);

            if (File.Exists(@FileName))
                File.Delete(@FileName);
            using (var tw = new StreamWriter(@FileName, true))
            {
                tw.WriteLine(json);
                tw.Close();
            }
            Results = null;
        }

        /// <summary>
        /// Build each data row model
        /// </summary>
        /// <param name="data"></param>
        /// <returns>JSON element</returns>
        internal abstract JObject GetRowElement(string[] data);

    }

}
