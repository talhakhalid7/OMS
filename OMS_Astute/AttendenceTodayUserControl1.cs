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
    public partial class AttendenceTodayUserControl1 : UserControl
    {
        public AttendenceTodayUserControl1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string empID = txtEmpIdSearch.Text.ToString();
            string empName = txtnameSearch.Text.ToString();
            string month = txtmonthSearch.SelectedItem.ToString();
            string[] splitdate = month.Split('/');
            int mon = Convert.ToInt32(splitdate[0]);
            SqlConnection conStr = new SqlConnection();
            conStr.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();

            DataTable dt = new DataTable();
            SqlDataReader myReader = null;
            conStr.Open();
            string query = "select * from Attendence where EMPid='" + empID + "'  AND  Month(Date) ='" + mon + "'";
            SqlCommand cmd = new SqlCommand(query, conStr);
            //conStr.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlCommand myCommand = new SqlCommand("select * from Attendence where EMPid='" + empID + "'  AND  Month(Date) ='" + mon + "'", conStr);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                txtEmpIdSearch.Text = (myReader["EMPid"].ToString());
                txtnameSearch.Text = (myReader["Name"].ToString());


            }
            conStr.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");

            var datetoday = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();

            string query = "select * from Attendence where Date='" + datetoday + "'";
            SqlCommand cmd = new SqlCommand(query, conStr);
            conStr.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conStr.Close();
        }

        private void AttendenceTodayUserControl1_Load(object sender, EventArgs e)
        {
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");

            var datetoday = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();

            string query = "select * from Attendence where Date='" + datetoday + "'";
            SqlCommand cmd = new SqlCommand(query, conStr);
            conStr.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conStr.Close();
        }
    }
}
