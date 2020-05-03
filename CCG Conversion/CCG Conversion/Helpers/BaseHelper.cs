using CCGConversion.Constants;
using CCGConversion.ConversionOutput;
using CCGConversion.ReadFileInput;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CCGConversion.ReadFileInput.InputModelAssignments;
using CCGConversion.ConversionOutput.OutputModelAssignments;

namespace CCGConversion.Helpers
{
    public abstract class BaseHelper
    {
        #region "variables"
        public Exception Problem { get; internal set; }
        public string CompleteMessage { get; internal set; }


        public string InPutType { get; internal set; }
        public string OutPutType { get; internal set; }
        public string InputPatternType { get; internal set; }

        internal string _filefullPath;

        public static string InputConnection { get; internal set; }
        public static string OutPutFileName { get; internal set; }

        #endregion "variables"

        #region "objects"
        public IInput InputReader { get; internal set; }
        public IOutput OutputWriter { get; internal set; }
        #endregion "objects"

        #region "required functions"
        /// <summary>
        /// Check that the data can be used and read.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Is the supplied input data reachable? 
        /// Does the File exists. 
        /// </summary>
        /// <returns>true - its reachable : otherwise false</returns>
        internal virtual bool CheckDataReachable()
        {
            if (InputConnection.IndexOf(".") == -1)
            {
                Problem = new Exception(string.Format(FileInputConstants.NoExtension, InputConnection));
                return false;
            }

            //
            // No Backslash then it needs the app path.
            //
            if (InputConnection.Contains("\\") == false)
                _filefullPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + InputConnection;
            else
                _filefullPath = InputConnection;

            if (!File.Exists(_filefullPath))
            {
                Problem = new Exception(string.Format(FileInputConstants.FileMissing, InputConnection));
                return false;
            }

            if (InPutType.CompareTo(OutPutType).Equals(0))
            {
                Problem = new Exception(string.Format(Constants.Conversion.InputOutputSame, InputConnection));
                return false;
            }

            return true;
        }


        /// <summary>
        /// Do we have the output type to convert?
        /// </summary>
        /// <returns>true - its covered : otherwise false</returns>
        internal virtual bool IsOutputTypeCovered()
        {
            switch (OutPutType)
            {
                case "csv":
                    OutputWriter = new CSVOutput(OutPutFileName.Replace("." + InPutType, ".csv"));
                    return true;

                case "xml":
                    OutputWriter = XMLPatternsOutput.AssignXMLWriter(InputPatternType, OutPutFileName, InPutType);
                    return (OutputWriter != null);

                case "json":
                    OutputWriter = JSONPatternsOutput.AssignJSONWriter(InputPatternType, OutPutFileName, InPutType);
                    return (OutputWriter != null);

                default:
                    Problem = new Exception(string.Format(Constants.Conversion.NoValidOutputType, OutPutType));
                    return false;
            }
        }

        /// <summary>
        /// Do we have the input type to convert?
        /// </summary>
        /// <returns>true - its covered : otherwise false</returns>
        internal virtual bool IsInputTypeCovered()
        {
            //
            // Is it just a straight conversion
            //
            switch (InPutType)
            {
                case "csv":
                    InputReader = new CSVInput(_filefullPath);
                    return true;

                case "xml":
                    InputReader = XMLPatternsInput.AssignXMLReader(InputPatternType, _filefullPath);
                    return (InputReader != null);

                case "json":
                    InputReader = JSONPatternsInput.AssignJSONReader(InputPatternType, _filefullPath);
                    return (InputReader != null);

                default:
                    Problem = new Exception(string.Format(FileInputConstants.NoValidExtension, InputConnection));
                    return false;
            }

        }

        /// <summary>
        /// Check all the coverage for input and output settings. 
        /// </summary>
        /// <returns></returns>
        internal virtual bool CheckCoverage()
        {

            if (CheckDataReachable() == false)
                return false;

            if (IsInputTypeCovered() == false)
                return false;

            if (IsOutputTypeCovered() == false)
                return false;

            if (OutPutFileName.IndexOf(".") > -1)
            {
                OutPutFileName = ((Output)OutputWriter).FileName;
            }
            return true;

        }
        #endregion "required functions"
    }
}
