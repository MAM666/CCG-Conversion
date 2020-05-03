using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput
{

    /// <summary>
    /// Input from a file.
    /// </summary>
    public abstract class Input
    {
        public string DataLocation { get; private set; }

        public Input(string inputFileName)
        {
            DataLocation = inputFileName;
        }
    }
}
