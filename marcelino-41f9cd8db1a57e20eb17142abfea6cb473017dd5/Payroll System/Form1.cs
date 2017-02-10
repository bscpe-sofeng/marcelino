using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace Payroll_System
{
    public partial class Form1 : Form
    {
        Database data3 = new Database();

        public Form1()
        {
            InitializeComponent();
        }

   
        private void button1_Click(object sender, EventArgs e)
        {

            
            data3.Connect();
            data3.cmd = new MySqlCommand("select * from tbl_login where username=@username and password=@password", data3.con);
            data3.cmd.Parameters.Add(new MySqlParameter("username", usertxtbox.Text));
            data3.cmd.Parameters.Add(new MySqlParameter("password", passwordtxtbox.Text));
            data3.dr = data3.cmd.ExecuteReader();


            if (data3.dr.Read())
            {
                new Time().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Incorrect Usename and Password!");

            }
            

        }

        private void passwordtxtbox_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = loginbtn;
        }
    }
}
