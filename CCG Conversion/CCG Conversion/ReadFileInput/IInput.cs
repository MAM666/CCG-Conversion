using System;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadFileInput
{
    public interface IInput
    {

        Exception Problem {get; set;}
        /// <summary>
        /// Read in the Data
        /// </summary>
        /// <returns></returns>
        bool ReadInData();
    }
}
