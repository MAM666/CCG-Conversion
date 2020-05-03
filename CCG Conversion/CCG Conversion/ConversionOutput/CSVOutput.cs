using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ConversionOutput
{
    internal class CSVOutput : Output, IOutput
    {
        internal CSVOutput(string outputFileName)
            :base(outputFileName)
        {
        }

        public bool Process(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
