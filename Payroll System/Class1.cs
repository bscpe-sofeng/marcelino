using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Payroll_System
{
    class Class1
    {
        public MySqlConnection data;
        public MySqlDataReader data1;
        public MySqlCommand data2;
    
        public void Connect()
        {
            data = new MySqlConnection("server=127.0.0.1;user=root;database=pr_database");
            data.Open();
        }

        public void Disconnect()
        {
            if (data.State==System.Data.ConnectionState.Open)
            {
                data.Close();
                data.Dispose();

            }
        }

    }
}
