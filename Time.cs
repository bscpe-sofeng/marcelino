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
    public partial class Time : Form
    {
        Database r = new Database();
        public Time()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            r.Connect();
            r.cmd = new MySqlCommand("SELECT * FROM tbl_employees WHERE `ID` = @id", r.con);
            r.cmd.Parameters.Add(new MySqlParameter("id", textBox1.Text));
            r.dr = r.cmd.ExecuteReader();
            if (!r.dr.Read())
            {
                MessageBox.Show("Employee ID does not exists.");
                r.Disconnect();
                return;
            }
            r.Disconnect();

            r.Connect();
            r.cmd = new MySqlCommand("SELECT * FROM tbl_timekeeping WHERE `Employee ID` = @id AND `Time out` = '2011-11-11 11:11:11'", r.con);
            r.cmd.Parameters.Add(new MySqlParameter("id", textBox1.Text));
            r.dr = r.cmd.ExecuteReader();
            if (r.dr.Read())
            {
                int logInID = int.Parse(r.dr["ID"].ToString());
                r.Disconnect();
                r.Connect();
                r.cmd = new MySqlCommand("UPDATE tbl_timekeeping SET `Time Out` = NOW(), `Total Duration` = TIME_TO_SEC(TIMEDIFF(NOW(),`Time In`)) WHERE ID = @id;", r.con);
                r.cmd.Parameters.Add(new MySqlParameter("id", logInID));
                r.cmd.ExecuteNonQuery();
                MessageBox.Show("Logged out.");
            }
            else
            {
                r.Disconnect();
                r.Connect();
                r.cmd = new MySqlCommand("INSERT INTo tbl_timekeeping VALUES (NULL, @id, NOW(), '2011-11-11 11:11:11', 0)", r.con);
                r.cmd.Parameters.Add(new MySqlParameter("id", textBox1.Text));
                r.cmd.ExecuteNonQuery();
                MessageBox.Show("Logged in.");
            }
            r.Disconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Main().Show();
            
        }
    }
    }

