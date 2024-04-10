using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProject
{
    public class Constants
    {
        public const string DatabaseFilename = "Library.db3";

        public const SQLite.SQLiteOpenFlags Flags = 
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create;


        public static string DatabasePath =>
            
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\Library.db3");
        public Constants()
        {
        }
    }
}
