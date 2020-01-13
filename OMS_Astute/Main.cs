using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMS_Astute
{
    delegate void Function();
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void Main_Load(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Show();
            registerEmpUserControl11.Hide();
            searchEmpInfoUserControl11.Hide();
            manualAttendenceUserControl11.Hide();
            settingsUserControl11.Hide();
            reportsUserControl11.Hide();
            attendenceTodayUserControl11.Hide();
            contactsUserControl11.Hide();
            weeklyReport1.Hide();
            //btntagWeekRep.Tag = weeklyReport1;
           

        }

        private void btnattendenceModule_Click(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Show();
            registerEmpUserControl11.Hide();
            searchEmpInfoUserControl11.Hide();
            manualAttendenceUserControl11.Hide();
            settingsUserControl11.Hide();
            reportsUserControl11.Hide();
            attendenceTodayUserControl11.Hide();
            contactsUserControl11.Hide();
            weeklyReport1.Hide();
            
        }

        private void btbEmplyeeregister_Click(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Hide();
            registerEmpUserControl11.Show();
            manualAttendenceUserControl11.Hide();
            searchEmpInfoUserControl11.Hide();
            settingsUserControl11.Hide();
            reportsUserControl11.Hide();
            attendenceTodayUserControl11.Hide();
            contactsUserControl11.Hide();
            weeklyReport1.Hide();

            RegisterEmp frmRegister = new RegisterEmp();
            this.Hide();
            frmRegister.Show();


        }

        private void btnAttendence_Click(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Hide();
            registerEmpUserControl11.Hide();
            manualAttendenceUserControl11.Show();
            searchEmpInfoUserControl11.Hide();
            settingsUserControl11.Hide();
            reportsUserControl11.Hide();
            attendenceTodayUserControl11.Hide();
            contactsUserControl11.Hide();
            weeklyReport1.Hide();




        }

        private void btnSearchEmp_Click(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Hide();
            settingsUserControl11.Hide();
            registerEmpUserControl11.Hide();
            manualAttendenceUserControl11.Hide();
            searchEmpInfoUserControl11.Show();
            reportsUserControl11.Hide();
            attendenceTodayUserControl11.Hide();
            contactsUserControl11.Hide();
            weeklyReport1.Hide();

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Hide();
            registerEmpUserControl11.Hide();
            manualAttendenceUserControl11.Hide();
            searchEmpInfoUserControl11.Hide();
            settingsUserControl11.Show();
            reportsUserControl11.Hide();
            attendenceTodayUserControl11.Hide();
            contactsUserControl11.Hide();
            weeklyReport1.Hide();

        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Hide();
            registerEmpUserControl11.Hide();
            manualAttendenceUserControl11.Hide();
            searchEmpInfoUserControl11.Hide();
            settingsUserControl11.Hide();
            reportsUserControl11.Hide();
            attendenceTodayUserControl11.Hide();
            contactsUserControl11.Show();
            weeklyReport1.Hide();
        }

        private void btrnReports_Click(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Hide();
            registerEmpUserControl11.Hide();
            manualAttendenceUserControl11.Hide();
            searchEmpInfoUserControl11.Hide();
            settingsUserControl11.Hide();
            reportsUserControl11.Show();
            attendenceTodayUserControl11.Hide();
            contactsUserControl11.Hide();
            weeklyReport1.Hide();

        }

        private void btnAttenedenceRecord_Click(object sender, EventArgs e)
        {
            attendenceModeUserControl11.Hide();
            registerEmpUserControl11.Hide();
            manualAttendenceUserControl11.Hide();
            searchEmpInfoUserControl11.Hide();
            settingsUserControl11.Hide();
            reportsUserControl11.Hide();
            contactsUserControl11.Hide();
            weeklyReport1.Hide();
            attendenceTodayUserControl11.Show();
        }

        private void button1_Click(object sender, EventArgs e)
         {
        //    attendenceModeUserControl11.SuspendLayout();
        //    Enrollment.MainForm frm = new Enrollment.MainForm();
        //    var dialogResult = frm.ShowDialog();
        }

        
    }
}
