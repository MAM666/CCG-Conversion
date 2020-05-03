using CCGConversion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput
{

    /// <summary>
    /// Specifically a JSON Person Input file
    /// </summary>
    public class JSONInputPerson : JSONInputBase<Person>
    {
        public JSONInputPerson(string inputFileName)
            : base(inputFileName)
        {
        }

        public override bool ReadInData()
        {
            throw new NotImplementedException();
        }
    }
}
