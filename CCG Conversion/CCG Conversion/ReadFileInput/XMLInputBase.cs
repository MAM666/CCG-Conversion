using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput
{
    /// <summary>
    /// XML Input for a generic read
    /// </summary>
    public abstract class XMLInputBase : Input, IInput
    {
        public XMLInputBase(string inputFileName)
            : base(inputFileName)
        {
        }
        public Exception Problem { get; set; }
        public abstract bool ReadInData();
    }

    /// <summary>
    /// XML Input for a specific Model read
    /// </summary>

    public abstract class XMLInputBase<Entity> : XMLInputBase where Entity : class
    {
        public XMLInputBase(string inputFileName)
            : base(inputFileName)
        {
        }
    }
}
