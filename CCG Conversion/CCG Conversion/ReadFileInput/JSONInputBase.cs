using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput
{
    /// <summary>
    /// JSON Input for a generic read
    /// </summary>
    public abstract class JSONInputBase : Input, IInput
    {
        public JSONInputBase(string inputFileName) 
            : base(inputFileName)
        {
        }

        public Exception Problem { get; set; }
        public abstract bool ReadInData();
    }

    /// <summary>
    /// JSON Input for a specific model read
    /// </summary>
    public abstract class JSONInputBase<Entity> : JSONInputBase where Entity : class
    {
        public JSONInputBase(string inputFileName)
           : base(inputFileName)
        {
        }
    }
}
