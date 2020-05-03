using CCGConversion.ReadFileInput;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.Helpers
{

    /// <summary>
    /// Check the params for file conversion.
    /// Is it possible to convert with these params?
    /// </summary>
    public class FileInputHelper : BaseHelper, IInputHelper
    {

        public FileInputHelper()
        {
            Problem = null;
        }

        /// <summary>
        /// Check if it is a File Conversion.
        /// Does the File Exist
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckItsTypeConversion(string[] args)
        {
            if (args[0].StartsWith("F\\") == false
                | args[1].StartsWith("O\\") == false) return false;

            if (args[0].Length < 4 
                | args[1].Length < 4)
                return false;

            InputConnection = args[0].Substring(2).ToLower();
            int iindex = InputConnection.IndexOf(".");
            if (iindex > -1) 
                InPutType = InputConnection.Substring(iindex + 1);
            OutPutFileName = args[1].Substring(2).ToLower();
            iindex = OutPutFileName.IndexOf(".");
            if (iindex == -1)
            {
                OutPutType = OutPutFileName;
                OutPutFileName = InputConnection;
            }
            else
            {
                OutPutType = OutPutFileName.Substring(iindex + 1);
                OutPutFileName = OutPutFileName.Substring(0, OutPutFileName.Length - OutPutType.Length);
            }
            if (args.Length > 2 && args[2].StartsWith("P\\") && args[2].Length > 2)
                InputPatternType = args[2].Substring(2).ToLower();

            return true;
        }

        /// <summary>
        /// Process the Inputfile
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <returns></returns>
        public bool Process()
        {
            if (InputReader.ReadInData())
            {
                if (OutputWriter.Process(((CSVInput)InputReader).Source))
                {
                    CompleteMessage = $"'{ FileInputHelper.InputConnection }' has converted successfully to { FileInputHelper.OutPutFileName }";
                    return true;
                }
            }
            base.Problem = InputReader.Problem;
            return false;
        }

    }
}
