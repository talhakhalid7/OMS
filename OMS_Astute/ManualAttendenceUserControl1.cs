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

namespace OMS_Astute
{
    public partial class ManualAttendenceUserControl1 : UserControl
    {
        public ManualAttendenceUserControl1()
        {
            InitializeComponent();
            InitializeTimePicker();
        }
        private void InitializeTimePicker()
        {

            timeIN.Format = DateTimePickerFormat.Time;
            timeIN.CustomFormat = "hh:mm tt";
            timeIN.ShowUpDown = true;
            timeIN.Width = 100;
            timeOUT.Format = DateTimePickerFormat.Time;
            timeOUT.CustomFormat = "hh:mm tt";
            timeOUT.ShowUpDown = true;
            timeOUT.Width = 100;
            OverTimeIN.Format = DateTimePickerFormat.Time;
            OverTimeIN.CustomFormat = "hh:mm tt";
            OverTimeIN.ShowUpDown = true;
            OverTimeIN.Width = 100;
            OverTimeOut.Format = DateTimePickerFormat.Time;
            OverTimeOut.CustomFormat = "hh:mm tt";
            OverTimeOut.ShowUpDown = true;
            OverTimeOut.Width = 100;
            todayDate.Value = DateTime.Today;
            txtdatePicker.Value = DateTime.Today;
            btnUdateOvertime.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Enabled = false;
            StatusBox.SelectedIndex = 0;

        }

        private void ManualAttendenceUserControl1_Load(object sender, EventArgs e)
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
            DataTable dt1 = new DataTable();
            string query2 = "select * from OverTime where Date='" + datetoday + "'";
            SqlCommand cmd2 = new SqlCommand(query2, conStr);
            conStr.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            conStr.Close();
        }

        private void btngetInfo_Click(object sender, EventArgs e)
        {

            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            conStr.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from Employees where EmpID='" + id_txt.Text.ToString() + "'", conStr);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                txt_Name.Text = (myReader["Emp_Name"].ToString());
            }
            myReader.Close();
            todayDate.Format = DateTimePickerFormat.Custom;
            todayDate.CustomFormat = "yyyy-MM-dd";
            var dateinform = todayDate.Text;
            string currentdate = DateTime.Today.ToString("yyyy-MM-dd");
            string dbdate = string.Format("yyyy-MM-dd");
            SqlDataReader myreader2 = null;
            if (currentdate != dateinform)
            {
                SqlCommand cmd1 = new SqlCommand("select * from Attendence where EMPid = '" + id_txt.Text.ToString() + "' AND Date='" + dateinform + "'", conStr);
                myreader2 = cmd1.ExecuteReader();
                if (myreader2.Read())
                {
                    dbdate = (myreader2["Date"].ToString());
                    stats = 2;
                    MessageBox.Show("Already Marked Will Update " + dateinform + " Data");
                }
                else
                {
                    stats = 0;
                    MessageBox.Show("New Attendence For " + dateinform + " Would Be Added");
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Attendence where EMPid = '" + id_txt.Text.ToString() + "' AND Date='" + currentdate + "'", conStr);
                myreader2 = cmd.ExecuteReader();
                if (myreader2.Read())
                {
                    dbdate = (myreader2["Date"].ToString());
                    stats = 2;
                    MessageBox.Show("Already Marked Will Update " + currentdate + " Data");

                }
                else
                {
                    stats = 0;
                    MessageBox.Show("Will Update Attendence For " + currentdate);
                }






            }

            myreader2.Close();

            btnUpdate.Enabled = true;
        }
        int stats = 0;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = 0;
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");

            conStr.Open();
            string empID = id_txt.Text.ToString();
            string name = txt_Name.Text.ToString();
            string timein = timeIN.Text.ToString();
            string timeout = "";
            if (chkTimeout.Checked == true)
            {
                timeout = timeOUT.Text.ToString();
            }

            DateTime In = timeIN.Value;
            DateTime Out = timeOUT.Value.AddHours(-1);
            string totalhours = "";
            if (In < Out)
            {
                totalhours = (Out - In).ToString();
            }
            todayDate.Format = DateTimePickerFormat.Custom;
            todayDate.CustomFormat = "yyyy-MM-dd";
            var date = todayDate.Text;
            string status = StatusBox.Text.ToString();
            if (stats == 2)
            {
                string update = "UPDATE Attendence Set TimeIn='" + timein + "',TimeOUT='" + timeout + "', Status='" + status + "', TotalHours='" + totalhours + "' where EMPid='" + empID + "' AND Date='" + date + "'";
                SqlCommand cmdUpdate = new SqlCommand(update, conStr);
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");

            }
            else
            {
                string sql = "INSERT INTO Attendence ([EMPid],[Name],[TimeIn],[TimeOUT],[Date],[Status],[TotalHours]) VALUES(@empid,@name,@timein,@timeout,@date,@status,@totalhours)";
                using (SqlCommand cmd = new SqlCommand(sql, conStr))
                {
                    cmd.Parameters.AddWithValue("empid", empID);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("timein", timein);
                    cmd.Parameters.AddWithValue("timeout", timeout);
                    cmd.Parameters.AddWithValue("date", date);
                    cmd.Parameters.AddWithValue("status", status);
                    cmd.Parameters.AddWithValue("totalhours", totalhours);

                    cmd.CommandType = CommandType.Text;
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                MessageBox.Show("Added Successfully");
                dataGridView1.Refresh();
            }
            conStr.Close();
            var datetoday = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            string query = "select * from Attendence where Date='" + datetoday + "'";
            SqlCommand cmd2 = new SqlCommand(query, conStr);
            conStr.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conStr.Close();
            btnUpdate.Enabled = false;
        }

        private void btnOvergetInfo_Click(object sender, EventArgs e)
        {
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            conStr.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from Employees where EmpID='" + txtempIDOvertime.Text.ToString() + "'", conStr);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                txtEmpNAmeOverTime.Text = (myReader["Emp_Name"].ToString());
            }
            myReader.Close();
            txtdatePicker.Format = DateTimePickerFormat.Custom;
            txtdatePicker.CustomFormat = "yyyy-MM-dd";
            var dateinform = txtdatePicker.Text;
            string currentdate = DateTime.Today.ToString("yyyy-MM-dd");
            string dbdate = string.Format("yyyy-MM-dd");
            SqlDataReader myreader2 = null;
            if (currentdate != dateinform)
            {
                SqlCommand cmd1 = new SqlCommand("select * from OverTime where EmpID = '" + txtempIDOvertime.Text.ToString() + "' AND Date='" + dateinform + "'", conStr);
                myreader2 = cmd1.ExecuteReader();
                if (myreader2.Read())
                {
                    dbdate = (myreader2["Date"].ToString());
                    stats = 2;
                    MessageBox.Show("Already Marked Will Update " + dateinform + " Data");
                }
                else
                {
                    stats = 0;
                    MessageBox.Show("New Over Time For " + dateinform + " Would Be Added");
                }






            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from OverTime where EmpID = '" + txtempIDOvertime.Text.ToString() + "' AND Date='" + currentdate + "'", conStr);
                myreader2 = cmd.ExecuteReader();
                if (myreader2.Read())
                {
                    dbdate = (myreader2["Date"].ToString());
                    stats = 2;
                    MessageBox.Show("Already Marked Will Update " + currentdate + " Data");

                }
                else
                {
                    stats = 0;
                    MessageBox.Show("Will Update OverTime For " + currentdate);
                }






            }

            myreader2.Close();
            btnUdateOvertime.Enabled = true;
        }

        private void btnUdateOvertime_Click(object sender, EventArgs e)
        {

        }
    }
}
