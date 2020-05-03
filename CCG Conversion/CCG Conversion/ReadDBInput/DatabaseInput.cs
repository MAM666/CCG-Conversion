using CCGConversion.ReadFileInput;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.ReadDBInput
{

    //TODO: change into abstract  <ENtity> class.


    /// <summary>
    /// Connect and retrieve the data
    /// 
    /// </summary>
    public class DatabaseInput : IInput
    {
        private readonly string _fileLocation;
        private string _connectionString;
        private string _sql;

        public DatabaseInput(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public string[] Source { get; private set; }
        public Exception Problem { get; set; }

        public bool ReadInData()
        {
            string[] databaseInfo = File.ReadAllLines(_fileLocation);
            _connectionString = databaseInfo[0];
            _sql = databaseInfo[1];

            // using connection to the DB

            // retreive the sql data and convert it to rows of string
            return true;
        }
    }
}
