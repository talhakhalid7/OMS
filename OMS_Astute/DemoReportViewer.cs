using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMS_Astute
{
    public partial class DemoReportViewer : Form
    {
        public DemoReportViewer()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        public void ShowReport(string datefrom , string dateto)
        {
            string appPath = Application.StartupPath;
            string reportPath = @"\CrystalReport1.rpt";

            ReportDocument rdoc = new ReportDocument();
            CrystalReport1 objrpt = new CrystalReport1();
            ReportsUserControl1 rpt = new ReportsUserControl1();
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            DataSet dt = new DataSet();
            string query = "select EMPid,Name,Status,Date from Attendence where Date Between '" + datefrom + "' AND '"+ dateto + "'";
            SqlCommand cmd = new SqlCommand(query, conStr);
            conStr.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            objrpt.SetDataSource(dt);
            conStr.Close();
            objrpt.ExportToDisk(ExportFormatType.CrystalReport, appPath + reportPath);
            //CrystalDecisions.CrystalReports.Engine.TextObject root;
            //root = (CrystalDecisions.CrystalReports.Engine.TextObject)
            //     objrpt.ReportDefinition.ReportObjects["txt_header"];
            //root.Text = "Sample Report By Using Data Table!!";
            //string reportFullpath = appPath+reportPath;
            //rdoc.Load(reportFullpath);
            //crystalReportViewer1.ReportSource = rdoc;
           // DemoReportViewer d = new DemoReportViewer();
           // d.Show();
        }

        public void DemoReportViewer_Load(object sender, EventArgs e)
        {
        }
    }
}
