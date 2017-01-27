using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Payroll_System
{
    class Database
    {
        public MySqlConnection con;
        public MySqlDataReader dr;
        public MySqlCommand cmd;

        public void Connect()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Open) con.Close();
                con.Open();
            }
            catch (Exception ex)
            {
                con = new MySqlConnection("server=127.0.0.1;user=root;database=pr_database");
                con.Open();
            }
        }

        public void Disconnect()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();

            }
        }

    }
}