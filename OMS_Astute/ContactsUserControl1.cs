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
    public partial class ContactsUserControl1 : UserControl
    {
        public ContactsUserControl1()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");


        private void ContactsUserControl1_Load(object sender, EventArgs e)
        {

            var datetoday = DateTime.Now.ToString("yyyy-MM-dd");
           
            string query = "select Emp_Name,Emp_Conatct  from Employees";
            SqlCommand cmd = new SqlCommand(query, conStr);
            conStr.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conStr.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtemp_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtemp_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
