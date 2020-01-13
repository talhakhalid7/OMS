using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace OMS_Astute
{
    public partial class WeeklyReport : UserControl
    {
        public WeeklyReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void ShowReport()
        {
            ReportDocument rdoc = new ReportDocument();
            string appPath = Application.StartupPath;
            string reportPath = @"CrystalReport1.rpt";
            string reportFullpath = Path.Combine(appPath, reportPath);
            rdoc.Load(reportFullpath);
            crystalReportViewer1.ReportSource = rdoc;
        }

        private void WeeklyReport_Load(object sender, EventArgs e)
        {
            ShowReport();

        }
    }
}
