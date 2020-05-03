using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput
{
    /// <summary>
    /// CSV Input
    /// </summary>
    internal class CSVInput : Input, IInput
    {
        public CSVInput(string inputFileName) 
            : base(inputFileName)
        {
        }

        /// <summary>
        /// The Data read in from the file.
        /// </summary>
        public string[] Source { get; private set; }

        public Exception Problem { get; set; }

        public bool ReadInData()
        {
            Source = File.ReadAllLines(DataLocation);

            if(Source == null || Source.Length == 0)
            {
                Problem = new Exception(Constants.Conversion.NoDataToProcess);
                return false;
            }
            return true;
        }
    }
}
