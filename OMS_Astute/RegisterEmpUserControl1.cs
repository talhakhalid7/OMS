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
using System.Diagnostics;

namespace OMS_Astute
{
    public partial class RegisterEmpUserControl1 : UserControl
    {
        public RegisterEmpUserControl1()
        {
            InitializeComponent();
        }
        string pathoutput = "";
        public string fingerpath = "";
        int id = 0;

        private DPFP.Capture.Capture Capturer;
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            string EmpID = txtEmployeeID.Text.ToString();
            string Name = (txtEmpNameFirst.Text + " " + txtEmpNameLast.Text).ToString();
            string Address = txtEmpAddress.Text.ToString();
            string Contact = txtEmpBNum.Text.ToString();
            string NIC = txtNationality.Text.ToString();
            string Email = txtemail.Text.ToString();
            string bloodgroup = txtbloodgroup.Text.ToString();
            string joiningdate = txtjoiningdate.Text.ToString();
            string Emptype = txtEmptype.Text.ToString();
            string department = txtdepartment.Text.ToString();
            string designation = txtdesignation.Text.ToString();
            string accountdetails = txtaccountdetails.Text.ToString();
            string salary = txtbasicsalary.Text.ToString();
            string fathersname = txtFathersname.Text.ToString();
            string bioimg = fingerpath;
            bool Active = false;
            if (checkActive.Checked)
            {
                Active = true;
            }

            string image = pathoutput;
            string sql = "INSERT INTO Employees ([EmpID],[Emp_Name],[FathersName],[Emp_Address],[Emp_NIC],[Emp_Conatct],[Emp_Email],[Emp_BloodGroup],[Emp_JoiningDate],[Emp_Department],[Emp_Designation],[Emp_BankAccountDetails],[Active],[EmptypeID],[BiometricImage],[profileImg])" +
                                      "VALUES   (@empid,@name,@father,@address,@nic,@contact,@email,@bloodgroup,@joiningdate,@department,@designation,@accountdetails,@actvie,@Emptype,@bioimg,@image)";

            string sql2 = "Insert INTO SalaryDetails([EmpID],[EmpBasicSalary],[ActiveStatus]) Values(@Empid,@Salary,@Active)";
            conStr.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conStr))
            {
                cmd.Parameters.AddWithValue("empid", EmpID);
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("father", fathersname);
                cmd.Parameters.AddWithValue("address", Address);
                cmd.Parameters.AddWithValue("nic", NIC);
                cmd.Parameters.AddWithValue("contact", Contact);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("bloodgroup", bloodgroup);
                cmd.Parameters.AddWithValue("joiningdate", joiningdate);
                cmd.Parameters.AddWithValue("department", department);
                cmd.Parameters.AddWithValue("designation", designation);
                cmd.Parameters.AddWithValue("accountdetails", accountdetails);
                cmd.Parameters.AddWithValue("actvie", Active);
                cmd.Parameters.AddWithValue("Emptype", Emptype);
                cmd.Parameters.AddWithValue("bioimg", bioimg);
                cmd.Parameters.AddWithValue("image", image);
                //cmd.Parameters.AddWithValue("",);
                cmd.CommandType = CommandType.Text;
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            using (SqlCommand cmd = new SqlCommand(sql2, conStr))
            {
                cmd.Parameters.AddWithValue("Empid", EmpID);
                cmd.Parameters.AddWithValue("Salary", salary);
                cmd.Parameters.AddWithValue("Active", Active);
                cmd.CommandType = CommandType.Text;
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            conStr.Close();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {

            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            DataTable dt = new DataTable();
            conStr.Open();
            SqlDataReader myReader = null;
            SqlDataReader myReader2 = null;

            SqlCommand myCommand = new SqlCommand("select * from Employees where EmpID='" + txtEmployeeID.Text.ToString() + "' ", conStr);
            myReader = myCommand.ExecuteReader();


            while (myReader.Read())
            {
                txtEmployeeID.Text = (myReader["EmpID"].ToString());
                txtEmpNameFirst.Text = (myReader["Emp_Name"].ToString());
                txtFathersname.Text = (myReader["FathersName"].ToString());
                txtEmpAddress.Text = (myReader["Emp_Address"].ToString());
                txtEmpBNum.Text = (myReader["Emp_Conatct"].ToString());
                txtEmpBNum.Text = (myReader["Emp_Conatct"].ToString());
                txtemail.Text = (myReader["Emp_Email"].ToString());
                txtNationality.Text = (myReader["Emp_NIC"].ToString());
                txtbloodgroup.Text = (myReader["Emp_BloodGroup"].ToString());
                txtjoiningdate.Text = (myReader["Emp_JoiningDate"].ToString());

                string path = (myReader["profileImg"].ToString());
                if (path != string.Empty || path != "")
                {
                    pictureemp.Image = new Bitmap(path);
                }
                string fingerpath = (myReader["BiometricImage"].ToString());
                if (fingerpath != null || fingerpath != "" || fingerpath != string.Empty)
                {
                    //fingerprint.Image = new Bitmap(fingerpath);
                }
                txtdepartment.Text = (myReader["Emp_Department"].ToString());
                txtdesignation.Text = (myReader["Emp_Designation"].ToString());
            }
        }
        Enrollment.MainForm frm = new Enrollment.MainForm();
        private void button2_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //Process.Start(@"C:\Program Files\DigitalPersona\One Touch SDK\.NET\Samples\Visual Studio 2005\CSharp\Enrollment\bin\Debug\EnrollmentSample CS.exe");
            var dialogResult = frm.ShowDialog();
            fingerpath = frm.path;
            
        }

        private void pictureemp_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //New folder created  to save prescription pdf            
            System.IO.Directory.CreateDirectory(@"D:\AstuteFiles\EmpImages\");
            // pdf path define
            pathoutput = @"D:\AstuteFiles\EmpImages\" + txtEmpNameFirst.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            //var output = new FileStream((pathoutput), FileMode.Create);
            if (open.ShowDialog() == DialogResult.OK)
            {
                string path = open.FileName;
                System.IO.File.Copy(path, pathoutput);
                pictureemp.Image = new Bitmap(open.FileName);
                //MessageBox.Show(pathoutput);
            }
        }

        private void RegisterEmpUserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
