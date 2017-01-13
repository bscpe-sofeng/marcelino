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
        Class1 data3 = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

    private void Form1_Load(object sender, EventArgs e)
        {
           

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            data3.Connect();
            data3.data2 = new MySqlCommand("select * from tbl_login where username=@username and password=@password", data3.data);
            data3.data2.Parameters.Add(new MySqlParameter("username", usertxtbox.Text));
            data3.data2.Parameters.Add(new MySqlParameter("password", passwordtxtbox.Text));
            data3.data1 = data3.data2.ExecuteReader();


            if (data3.data1.Read())
            {
                new Main().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Incorrect Usename and Password!");

            }

        }

       
    }
}
