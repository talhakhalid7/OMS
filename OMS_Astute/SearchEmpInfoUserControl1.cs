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
    public partial class SearchEmpInfoUserControl1 : UserControl
    {
        public SearchEmpInfoUserControl1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conStr = new SqlConnection();
            conStr.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
            string QUERY = "";
            DataTable dt = new DataTable();
            conStr.Open();
            SqlDataReader myReader = null;
            SqlDataReader myReader2 = null;
            if (txtemp.Text.Trim() != null && txtemp.Text.Trim() != "")
            {
                QUERY = "select * from Employees where EmpID='" + txtemp.Text.ToString() + "'";
            }
            else if (txtcontact.Text.Trim() != null && txtcontact.Text.Trim() != "")
            {
                QUERY = "select * from Employees where Emp_Conatct='" + txtcontact.Text.ToString() + "'";

            }
            SqlCommand myCommand = new SqlCommand(QUERY, conStr);
            myReader = myCommand.ExecuteReader();


            while (myReader.Read())
            {
                txtidReadonly.Text = (myReader["EmpID"].ToString());
                txtEmpName.Text = (myReader["Emp_Name"].ToString());
                txtfathername.Text = (myReader["FathersName"].ToString());
                txtEmpAddress.Text = (myReader["Emp_Address"].ToString());
                txtcontact.Text = (myReader["Emp_Conatct"].ToString());
                txtEmpBNum.Text = (myReader["Emp_Conatct"].ToString());
                txtemail.Text = (myReader["Emp_Email"].ToString());
                txtNationalty.Text = (myReader["Emp_NIC"].ToString());
                txtbloodgroup.Text = (myReader["Emp_BloodGroup"].ToString());
                txtdateJoining.Text = (myReader["Emp_JoiningDate"].ToString());

                string path = (myReader["profileImg"].ToString());
                if (path != string.Empty || path != " " || path != "")
                {
                   // pictureBox1.Image = new Bitmap(path);
                }
                txtdepartment.Text = (myReader["Emp_Department"].ToString());
                txtdesignation.Text = (myReader["Emp_Designation"].ToString());
            }
            myReader.Close();
            SqlCommand myCommand2 = new SqlCommand("select * from SalaryDetails where EmpID='" + txtidReadonly.Text.ToString() + "'", conStr);
            myReader2 = myCommand2.ExecuteReader();
            while (myReader2.Read())
            {
                txtbasicsalary.Text = (myReader2["EmpBasicSalary"].ToString());
            }
            conStr.Close();
        }
    }
}
