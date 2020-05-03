using CCGConversion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ConversionOutput.OutputModel
{
    /// <summary>
    /// Create a Person from string[] data row.
    /// </summary>
    public class RowPerson
    {
        public static Person GetRowElement(string[] data)
        {
            Person person = new Person()
            {
                Name = data[0],
                Address = new Address
                {
                    Line1 = data[1],
                    Line2 = data[2]
                },
            };

            return person;
        }
    }
}
