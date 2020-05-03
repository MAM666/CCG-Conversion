using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion
{
    /// <summary>
    /// Display the HELP advice for the user.
    /// </summary>
    internal static class HelpCommandLine
    {
        internal static void DisplayHelp(string[] args = null)
        {
            StringBuilder help = new StringBuilder("");

            help.AppendLine("");
            help.AppendLine("");

            if (args != null)
            {
                help.AppendLine("Your params :-");
                help.AppendLine(String.Join(", ", args.Select(s => s.ToString()).ToArray()));
                help.AppendLine("");
                help.AppendLine("");

            }
            help.AppendLine("CCG file conversion app requires at least 2 params...");
            help.AppendLine("F\\<filename> - the file you want to convert, or the details for connecting to a database");
            help.AppendLine("O\\<output> - the output type required [xml json csv db]. if no named filename, input filename will be used");
            help.AppendLine("P\\<pattern> - (optional) will default to regular conversion if not provided.");
            help.AppendLine("-wait - (optional) dont close the window till the user presses a key");
            help.AppendLine("");
            help.AppendLine("");
            help.AppendLine("All output files will be overwritten if they exist.");
            help.AppendLine("");
            help.AppendLine("example to convert a csv file to a json file with no pattern rules and wait to see any messages...");
            help.AppendLine("C:\\CCSConversion F\\testfile.csv O\\json -wait");
            help.AppendLine("");
            help.AppendLine("");
            help.AppendLine("");
            help.AppendLine("example to convert a csv file to an xml file with Pattern rule '_' wait to see any messages...");
            help.AppendLine("C:\\CCSConversion F\\testfile.csv O\\xml P\\_ -wait");
            help.AppendLine("");
            help.AppendLine("");
            help.AppendLine("example to convert a csv file to a json file with Pattern 'person' and wait to see any messages...");
            help.AppendLine("C:\\CCSConversion F\\testfile.csv O\\json P\\person -wait");
            help.AppendLine("");
            help.AppendLine("example to convert a db file to a named json file with Pattern 'person' and wait to see any messages...");
            help.AppendLine("C:\\CCSConversion DB\\connection_SQL.txt O\\people.json P\\person -wait");

            Console.WriteLine(help);
        }
    }
}
