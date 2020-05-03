using System;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ConversionOutput
{
    public interface IOutput
    {
        bool Process(string[] lines);
    }
}
