using CCGConversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCG_Conversion
{
    class Program
    {
        /// <summary>
        /// Convert one source of data to another format.
        /// File.csv --> json, xml, db
        /// File.json --> csv, xml, db
        /// File.xml --> csv, json, db
        /// File.db (db info not data) --> csv, json, xml
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // default no wait for user key at the end.
            bool waitforUser = false;

            try
            {

                if (Conversion.CheckParams(args) == false)
                {
                    waitforUser = true;
                    HelpCommandLine.DisplayHelp();
                }
                else if(args.Contains("-wait"))
                {
                    //
                    // Did the user state wait for messages?
                    // 
                    waitforUser = true;
                }
            }
            catch(Exception ex)
            {
                waitforUser = true;
                Console.WriteLine(ex.ToString());

                HelpCommandLine.DisplayHelp(args);
            }

            //
            // wait for the user to read the messages.
            //
            if (waitforUser)
            {
                Console.ReadKey();
            }
        }

    }
}
