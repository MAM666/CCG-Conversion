using CCGConversion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput
{

    /// <summary>
    /// Specifically an XML Person Input file
    /// </summary>
    public class XMLInputPerson : XMLInputBase<Person>
    {
        public XMLInputPerson(string inputFileName)
            : base(inputFileName)
        {
        }

        public override bool ReadInData()
        {
            throw new NotImplementedException();
        }
    }
}
