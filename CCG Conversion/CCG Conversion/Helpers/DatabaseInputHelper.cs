using CCGConversion.ReadDBInput;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.Helpers
{
    public class DatabaseInputHelper : BaseHelper, IInputHelper
    {
        public DatabaseInputHelper()
        {
            Problem = null;
        }

        public bool CheckItsTypeConversion(string[] args)
        {
            if (args[0].StartsWith("DB\\") == false 
                | args[1].StartsWith("O\\") == false) return false;

            if (args[0].Length < 5 
                | args[1].Length < 4)
                return false;

            InputConnection = args[0].Substring(3).ToLower();
            OutPutType = args[1].Substring(2).ToLower();

            if (args.Length > 2 && args[2].StartsWith("P\\") && args[2].Length > 2)
                InputPatternType = args[2].Substring(2).ToLower();

            return true;

        }

        public bool Process()
        {
            Problem = new Exception(Constants.Conversion.IsUnderConstruction);
            if (InputReader.ReadInData())
            {
                if (OutputWriter.Process(((DatabaseInput)InputReader).Source))
                {
                    CompleteMessage = $"'{ BaseHelper.InputConnection }' has converted successfully to { DatabaseInputHelper.OutPutFileName }";
                    return true;
                }
            }
            return false;
        }

        #region "private functions"
        /// <summary>
        /// Pass the file location
        /// </summary>
        /// <returns>true - its covered : otherwise false</returns>
        internal override bool IsInputTypeCovered()
        {
            InputReader = new DatabaseInput(InputConnection);
            return true;
        }

        #endregion "private functions"
    }
}
