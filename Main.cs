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
    public partial class Main : Form
    {

        Database r = new Database();

        public Main()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Payslip().Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
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
            }else
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
            r.Connect();
            r.cmd = new MySqlCommand("INSERT INTO tbl_employees VALUES (NULL, @en, @add1, @add2, @age, @g, @stat, @pos, @div, @sss, @bir, @pagibig, @acc, @basic, @rate)", r.con);
            r.cmd.Parameters.Add(new MySqlParameter("en", textBox4.Text));
            r.cmd.Parameters.Add(new MySqlParameter("add1", textBox5.Text));
            r.cmd.Parameters.Add(new MySqlParameter("add2", textBox15.Text));
            r.cmd.Parameters.Add(new MySqlParameter("age", textBox6.Text));
            r.cmd.Parameters.Add(new MySqlParameter("g", comboBox1.Text));
            r.cmd.Parameters.Add(new MySqlParameter("stat", textBox7.Text));
            r.cmd.Parameters.Add(new MySqlParameter("pos", textBox8.Text));
            r.cmd.Parameters.Add(new MySqlParameter("div", textBox9.Text));
            r.cmd.Parameters.Add(new MySqlParameter("sss", textBox12.Text));
            r.cmd.Parameters.Add(new MySqlParameter("bir", textBox11.Text));
            r.cmd.Parameters.Add(new MySqlParameter("pagibig", textBox22.Text));
            r.cmd.Parameters.Add(new MySqlParameter("acc", textBox10.Text));
            r.cmd.Parameters.Add(new MySqlParameter("basic", textBox13.Text));
            r.cmd.Parameters.Add(new MySqlParameter("rate", textBox14.Text));
            r.cmd.ExecuteNonQuery();
            r.Disconnect();
        }
    }
}
