using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace OMS_Astute
{
    public partial class SettingsUserControl1 : UserControl
    {
        public SettingsUserControl1()
        {
            InitializeComponent();
        }
        int id = 0;

        private void btnAddDep_Click(object sender, EventArgs e)
        {
            SqlConnection conStr = new SqlConnection();
            conStr.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
            conStr.Open();
            string departmentname = txtdepartment.Text.ToString();
            string sql = "INSERT INTO Departments([DeparmentName])VALUES(@departmentname)";
            using (SqlCommand cmd = new SqlCommand(sql, conStr))
            {
                cmd.Parameters.AddWithValue("departmentname", departmentname);
                cmd.CommandType = CommandType.Text;
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            string Query = "Select * from Departments";
            DataTable dt = new DataTable();
            //string query = "select * from SalaryDetails where EmpID='" + empID + "'";
            SqlCommand cmd2 = new SqlCommand(Query, conStr);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conStr.Close();
        }

        private void btnAddDesig_Click(object sender, EventArgs e)
        {
            SqlConnection conStr = new SqlConnection();
            conStr.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
            conStr.Open();
            string designation = txtAdddDesig.Text.ToString();
            string sql = "INSERT INTO Designation([DesignationName])VALUES(@designation)";
            using (SqlCommand cmd = new SqlCommand(sql, conStr))
            {
                cmd.Parameters.AddWithValue("designation", designation);
                cmd.CommandType = CommandType.Text;
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            string Query = "Select * from Designation";
            DataTable dt = new DataTable();
            //string query = "select * from SalaryDetails where EmpID='" + empID + "'";
            SqlCommand cmd2 = new SqlCommand(Query, conStr);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            conStr.Close();
        }
    }
}
