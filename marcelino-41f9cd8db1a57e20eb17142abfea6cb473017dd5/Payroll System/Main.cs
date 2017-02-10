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

        // register datagrid
        private void LoadTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Employee Name");
            dt.Columns.Add("Address 1");
            dt.Columns.Add("Address 2");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Status");
            dt.Columns.Add("Position");
            dt.Columns.Add("Division");
            dt.Columns.Add("SSS ID");
            dt.Columns.Add("BIR ID");
            dt.Columns.Add("Pag-IBIG ID");
            dt.Columns.Add("Account No.");
            dt.Columns.Add("Basic Salary");
            dt.Columns.Add("Rate Per Hour");

            r.Connect();
            r.cmd = new MySqlCommand("Select * from tbl_employees where ID like'%" + txtEmpName.Text + "%'", r.con);
            r.dr = r.cmd.ExecuteReader();

            while (r.dr.Read())
            {
                dt.Rows.Add(new Object[]{
                r.dr["ID"],
                r.dr["Employee Name"],
                r.dr["Address 1"],
                r.dr["Address 2"],
                r.dr["Age"],
                r.dr["Gender"],
                r.dr["Status"],
                r.dr["Position"],
                r.dr["Division"],
                r.dr["SSS ID"],
                r.dr["BIR ID"],
                r.dr["Pag-IBIG ID"],
                r.dr["Account No."],
                r.dr["Basic Salary"],
                r.dr["Rate Per Hour"],

            });
            }
            r.Disconnect();
            dataGridView1.DataSource = dt;
        }
        /// compute datagrid
        private void LoadTable1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Employee ID");
            dt.Columns.Add("Total Salary");
            dt.Columns.Add("SSS");
            dt.Columns.Add("Pag-IBIG");
            dt.Columns.Add("PhilHealth");
            dt.Columns.Add("BIR");
            dt.Columns.Add("Other Deduction");
            dt.Columns.Add("Total Deduction");
            dt.Columns.Add("Total Income");


            r.Connect();
            r.cmd = new MySqlCommand("Select * from tbl_deductions where ID like'%" + textBox16.Text + "%'", r.con);
            r.dr = r.cmd.ExecuteReader();

            while (r.dr.Read())
            {
                dt.Rows.Add(new Object[]{
                r.dr["Employee ID"],
                r.dr["Total Salary"],
                r.dr["SSS"],
                r.dr["Pag-IBIG"],
                r.dr["PhilHealth"],
                r.dr["BIR"],
                r.dr["Other Deduction"],
                r.dr["Total Deduction"],
                r.dr["Total Income"],

            });
            }
            r.Disconnect();
            dataGridView2.DataSource = dt;
        }
        ///

        private void button5_Click(object sender, EventArgs e)
        {
            new Payslip().Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadTable1();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            r.Connect();
            r.cmd = new MySqlCommand("INSERT INTO tbl_employees VALUES (NULL, @en, @add1, @add2, @age, @g, @stat, @pos, @div, @sss, @bir, @pagibig, @ph, @acc, @basic, @rate)", r.con);
            r.cmd.Parameters.Add(new MySqlParameter("en", txtEmpName.Text));
            r.cmd.Parameters.Add(new MySqlParameter("add1", txtAddress1.Text));
            r.cmd.Parameters.Add(new MySqlParameter("add2", txtAddress2.Text));
            r.cmd.Parameters.Add(new MySqlParameter("age", Agetext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("g", comboBox1.Text));
            r.cmd.Parameters.Add(new MySqlParameter("stat", Stattext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("pos", postex.Text));
            r.cmd.Parameters.Add(new MySqlParameter("div", Divtext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("sss", SSStext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("bir", BIRtext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("pagibig", PItext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("ph", PHtext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("acc", ANtext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("basic", BStext.Text));
            r.cmd.Parameters.Add(new MySqlParameter("rate", RPHtext.Text));
            r.cmd.ExecuteNonQuery();
            r.Disconnect();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            txtEmpName.Text = row.Cells["Employee Name"].Value.ToString();
            txtAddress1.Text = row.Cells["Address 1"].Value.ToString();
            txtAddress2.Text = row.Cells["Address 2"].Value.ToString();
            Agetext.Text = row.Cells["Age"].Value.ToString();
            comboBox1.Text = row.Cells["Gender"].Value.ToString();
            Stattext.Text = row.Cells["Status"].Value.ToString();
            postex.Text = row.Cells["Position"].Value.ToString();
            Divtext.Text = row.Cells["Division"].Value.ToString();
            SSStext.Text = row.Cells["SSS ID"].Value.ToString();
            BIRtext.Text = row.Cells["BIR ID"].Value.ToString();
            PItext.Text = row.Cells["Pag-IBIG ID"].Value.ToString();
            ANtext.Text = row.Cells["Account No."].Value.ToString();
            BStext.Text = row.Cells["Basic Salary"].Value.ToString();
            RPHtext.Text = row.Cells["Rate Per Hour"].Value.ToString();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            r.Connect();
            r.cmd = new MySqlCommand("SELECT * FROM tbl_employees WHERE `Employee Name` LIKE @empn", r.con);
            r.cmd.Parameters.Add(new MySqlParameter("empn", txtEmpName.Text + "%"));
            r.dr = r.cmd.ExecuteReader();
            if (r.dr.Read())
            {
                txtEmpName.Text = r.dr["Employee Name"].ToString();
                txtAddress1.Text = r.dr["Address 1"].ToString();
                txtAddress2.Text = r.dr["Address 2"].ToString();
            }
            r.Disconnect();
        }
    }
}
