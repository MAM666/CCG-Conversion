using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ConversionOutput
{
    public abstract class Output
    {
        public string FileName { get; private set; }

        public Output(string outputFileName)
        {
            FileName = outputFileName;
        }
    }
}
