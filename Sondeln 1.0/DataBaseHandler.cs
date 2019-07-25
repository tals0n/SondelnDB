using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sondeln_1._0
{
    class DataBaseHandler
    {
         private static string CONNECTION = @"Data Source = C:\Sondeln\sondeln.db; Version = 3";
         SQLiteConnection conn = new SQLiteConnection(CONNECTION);


        public void getAllentry()
        {
            conn.Open();


        }
    }
}
