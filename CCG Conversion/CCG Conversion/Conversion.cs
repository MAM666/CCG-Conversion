using CCGConversion.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion
{
    /// <summary>
    /// Is the file usable?
    /// Decide what type the Input will use from the filename.
    /// </summary>
    public class Conversion
    {
        /// <summary>
        /// Finished with a message look here
        /// </summary>
        public static string CompleteMessage { get; private set; }

        /// <summary>
        /// If there is a problem then look here
        /// </summary>
        public static Exception Problem { get; private set; }

        /// <summary>
        /// command line args here instead of passing them around
        /// </summary>
        private static string[] commandlineArgs;

        /// <summary>
        /// Have we enough params? then Convert from concrete IInput type.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool CheckParams(string[] args)
        {
            if (args == null || args.Count() < 2)
            {
                Problem = new Exception(Constants.Conversion.NoParams);
                return false;
            }
            else
            {
                commandlineArgs = args;
                if (Convert())
                {
                    Console.WriteLine(CompleteMessage);
                }
                else if (Problem != null)
                {
                    Console.WriteLine(Problem);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Can it convert?
        /// If so try to Convert.
        /// FileInput
        /// DatabaseInput
        /// </summary>
        /// <returns></returns>
        private static bool Convert()
        {

            Problem = null;

            bool converted = TryInput(new FileInputHelper()); 
            if (converted == false & Problem == null)
            {
                converted = TryInput(new DatabaseInputHelper());
            }
            
            if (converted)
                return true;
            else if (Problem == null)
            {
                // 
                // we cant use the params, nothing to convert?
                //
                Problem = new Exception(Constants.Conversion.NoParams);
            }

            //
            // No conversion happened.
            //
            return false;
        }

        /// <summary>
        /// Try the Input type
        /// </summary>
        /// <param name="inputHelper">the type of input we can try to convert.</param>
        /// <returns></returns>
        private static bool TryInput(IInputHelper inputHelper)
        {
            try
            {
                //
                // What do we have for conversion?
                //
                if (inputHelper.CheckItsTypeConversion(commandlineArgs))
                {
                    if (((BaseHelper)inputHelper).CheckCoverage() && inputHelper.Process())
                    {
                        // convert it
                        CompleteMessage = ((BaseHelper)inputHelper).CompleteMessage;
                        return true;
                    }
                    Problem = ((BaseHelper)inputHelper).Problem;
                }
            }
            catch (Exception ex)
            {
                Problem = ex;
            }
            return false;
        }

    }
}
