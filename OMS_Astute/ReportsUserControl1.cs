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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html;
using OMS_Astute;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net.Mail;
using System.Net;

namespace OMS_Astute
{
    public partial class ReportsUserControl1 : UserControl
    {
        public ReportsUserControl1()
        {
            InitializeComponent();
        }
        public string filepath;
        public string department;
        public string joiningdate;
        public string endingdate;
        public int status = 0;
        public string datefromt;
        public string datetot;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
            groupid = 1;
        }
        public void inserttodb()
        {
            SqlConnection conStr = new SqlConnection();
            conStr.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
            conStr.Open();
            string query = "INSERT INTO ExperienceLetter([NameEmp],[Date],[PrintStatus])Values(@name,@date,@status)";

            using (SqlCommand cmd = new SqlCommand(query, conStr))
            {
                cmd.Parameters.AddWithValue("name", txtEmpName.Text.ToString());
                cmd.Parameters.AddWithValue("date", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("status", status);
                cmd.ExecuteNonQuery();
            }
            conStr.Close();
        }
        public void Search()
        {
            SqlConnection conStr = new SqlConnection();
            conStr.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
            DataTable dt = new DataTable();
            conStr.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from Employees where EmpID='" + txtid.Text.ToString() + "'", conStr);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                if (groupid == 1)
                {
                    txtid.Text = (myReader["EmpID"].ToString());
                    txtEmpName.Text = (myReader["Emp_Name"].ToString());
                    txtfathername.Text = (myReader["FathersName"].ToString());
                    txtEmpAddress.Text = (myReader["Emp_Address"].ToString());
                    txtNationalty.Text = (myReader["Emp_NIC"].ToString());
                    txtdesignation.Text = (myReader["Emp_Designation"].ToString());
                    department = (myReader["Emp_Department"].ToString());
                    joiningdate = (myReader["Emp_JoiningDate"].ToString());
                }
                else if (groupid == 2)
                {
                    terIdtxt.Text = (myReader["EmpID"].ToString());
                    terNametxt.Text = (myReader["Emp_Name"].ToString());
                    terFathertxt.Text = (myReader["FathersName"].ToString());
                    terAddtxt.Text = (myReader["Emp_Address"].ToString());
                    terNICtxt.Text = (myReader["Emp_NIC"].ToString());
                    terDesignationtxt.Text = (myReader["Emp_Designation"].ToString());
                    department = (myReader["Emp_Department"].ToString());
                    joiningdate = (myReader["Emp_JoiningDate"].ToString());
                }

            }
            myReader.Close();
            endingdate = datepick.Text.ToString();
            if (groupid == 2)
            {
                endingdate = terEndtxt.Text.ToString();
            }
            conStr.Close();
        }
        int groupid = 0;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GenerateexperienceLTR();
        }
        public void print()
        {
            Spire.Pdf.PdfDocument pdf = new Spire.Pdf.PdfDocument();
            pdf.LoadFromFile(filepath);
            pdf.Print();
            status = 1;
        }
        public void GenerateexperienceLTR()
        {
            //adding new collors and fonts
            endingdate = datepick.Text.ToString();
            BaseColor myColor = WebColors.GetRGBColor("#D3D3D3");
            BaseColor colorBorder = WebColors.GetRGBColor("#000000");
            var fontHeaderbold_12 = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
            var fontHeaderbold_10 = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            var fontheader_10 = FontFactory.GetFont(FontFactory.TIMES, 10);
            var fontheader_8 = FontFactory.GetFont(FontFactory.TIMES, 12);
            //new document with A4 page size started
            Document doc = new Document(PageSize.A4);

            //New folder created  to save prescription pdf            
            System.IO.Directory.CreateDirectory(@"D:\AstuteFiles\ExperienceLetters\");
            // pdf path define
            var output = new FileStream((@"D:\AstuteFiles\ExperienceLetters\" + txtEmpName.Text + "-ExperienceLetter.pdf"), FileMode.Create);

            filepath = output.Name.ToString();
            var writer = PdfWriter.GetInstance(doc, output);
            doc.Open();
            //new logo generated
            //var logo = iTextSharp.text.Image.GetInstance((@"..\1.png"));
            //logo.SetAbsolutePosition(360, 840);
            //logo.Alignment = 40;
            //logo.ScaleAbsoluteHeight(70);
            //logo.ScaleAbsoluteWidth(70);
            // first table created with Doctors information
            PdfPTable tablebefore = new PdfPTable(2);
            tablebefore.DefaultCell.Border = 0;
            tablebefore.WidthPercentage = 80;
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 2;
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            Phrase phrase0 = new Phrase();
            phrase0.Add(new Chunk(" "));
            cell.AddElement(phrase0);
            tablebefore.AddCell(cell);
            tablebefore.SpacingAfter = 55.0f;




            PdfPTable table1 = new PdfPTable(3);
            table1.DefaultCell.Border = 0;
            //table1.DefaultCell.BackgroundColor = myColor;
            table1.WidthPercentage = 100;
            //var titleFont = new iTextSharp.text.Font();
            //var subTitleFont = new iTextSharp.text.Font();
            PdfPCell cell11 = new PdfPCell();
            cell11.Colspan = 1;
            cell11.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cell11.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            Phrase phrase = new Phrase();
            phrase.Add(new Chunk());
            cell11.AddElement(phrase);
            PdfPCell cellcenter = new PdfPCell();
            cellcenter.BorderWidth = 0;
            cellcenter.HorizontalAlignment = Element.ALIGN_CENTER;
            float[] columnWidths = new float[] { 30f, 20f, 30f };
            PdfPCell cell2 = new PdfPCell();
            cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell2.BorderWidth = 0;
            Phrase phrase2 = new Phrase();
            phrase2.Add(new Chunk("                   Dated: " + DateTime.Now.Date.ToString("dd-MM-yyyy"), FontFactory.GetFont(FontFactory.TIMES, 10)));
            cell2.AddElement(phrase2);
            PdfPCell cell3 = new PdfPCell();
            cell3.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            PdfPCell emptycell = new PdfPCell(new Phrase(" ")); emptycell.Colspan = 3;
            table1.AddCell(cell11);
            table1.AddCell(cellcenter);
            table1.AddCell(cell2);
            table1.SpacingBefore = 80.0f;
            table1.SpacingAfter = 20.0f;



            // third table created with History and Symptoms 
            PdfPTable table3 = new PdfPTable(2);
            table3.WidthPercentage = 80;
            Chunk chunk1 = new Chunk(("TO WHOM IT MAY CONCERN"), FontFactory.GetFont(FontFactory.TIMES_BOLD, 14));
            chunk1.SetUnderline(2, -3);
            PdfPCell Historr = new PdfPCell(new Phrase(chunk1));
            Historr.FixedHeight = 20.0f;
            Historr.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Historr.HorizontalAlignment = Element.ALIGN_CENTER;
            Historr.Colspan = 2;
            PdfPCell nextdate = new PdfPCell(new Phrase("(Experience Letter)", FontFactory.GetFont(FontFactory.TIMES_BOLD, 12)));
            nextdate.Border = iTextSharp.text.Rectangle.NO_BORDER;
            nextdate.HorizontalAlignment = Element.ALIGN_CENTER;
            nextdate.Colspan = 2;
            table3.AddCell(Historr);
            table3.AddCell(nextdate);
            table3.SpacingAfter = 25.0f;



            //5th table for advice 
            PdfPTable advice = new PdfPTable(2);
            advice.WidthPercentage = 90;
            string empname = txtEmpName.Text.ToString();
            Chunk ch1 = new Chunk(empname, FontFactory.GetFont(FontFactory.TIMES_BOLD, 10));
            Chunk ch2 = new Chunk(txtdesignation.Text.ToString(), FontFactory.GetFont(FontFactory.TIMES_BOLD, 10));

            PdfPCell note = new PdfPCell(new Phrase("This is to certify that Mr." + ch1 + " S/O " + txtfathername.Text.ToString() + ", holding CNIC(" + txtNationalty.Text.ToString() + ") was employed with us as '" + ch2 + "' in '" + department + " Team' from " + joiningdate + " to " + endingdate + ".", FontFactory.GetFont(FontFactory.TIMES, 12)));
            note.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //note.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            note.HorizontalAlignment = Element.ALIGN_LEFT;
            note.Colspan = 2;
            note.FixedHeight = 50.0f;

            PdfPCell note2 = new PdfPCell(new Phrase("During this period of his assignment, we found him sincere, hardworking and a keen learner.", FontFactory.GetFont(FontFactory.TIMES, 12)));
            note2.Border = iTextSharp.text.Rectangle.NO_BORDER;
            note2.HorizontalAlignment = Element.ALIGN_LEFT;
            note2.Colspan = 2;
            note2.FixedHeight = 40.0f;
            PdfPCell note3 = new PdfPCell(new Phrase("We wish him all the best in his future endeavours.", FontFactory.GetFont(FontFactory.TIMES, 12)));
            note3.HorizontalAlignment = Element.ALIGN_LEFT;
            note3.Border = iTextSharp.text.Rectangle.NO_BORDER;
            note3.Colspan = 2;
            note3.FixedHeight = 50.0f;
            advice.AddCell(note);
            advice.AddCell(note2);
            advice.AddCell(note3);

            string nextapp = "";



            //6th table for doc signature and next appointment details
            PdfPTable RegardsTable = new PdfPTable(1);
            RegardsTable.WidthPercentage = 90;
            PdfPCell Regards = new PdfPCell(new Phrase(new Chunk("Regards", FontFactory.GetFont(FontFactory.TIMES_BOLD, 12))));
            Regards.HorizontalAlignment = Element.ALIGN_LEFT;
            Regards.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Regards.Colspan = 2;
            Regards.FixedHeight = 30.0f;
            RegardsTable.AddCell(Regards);
            RegardsTable.SpacingAfter = 60.0f;

            PdfPTable OwnersTable = new PdfPTable(2);
            OwnersTable.WidthPercentage = 90;
            string ownerchunk = txtownerdetails.Text.ToString();

            PdfPCell owner = new PdfPCell(new Phrase(new Chunk(ownerchunk, FontFactory.GetFont(FontFactory.TIMES_BOLD, 12))));
            owner.HorizontalAlignment = Element.ALIGN_LEFT;
            owner.Border = iTextSharp.text.Rectangle.NO_BORDER;
            owner.Colspan = 2;
            owner.FixedHeight = 30.0f;
            OwnersTable.AddCell(owner);

            PdfPTable footer = new PdfPTable(2);
            footer.WidthPercentage = 90;
            PdfPCell foot = new PdfPCell(new Phrase(new Chunk("Astute Solutions", FontFactory.GetFont(FontFactory.TIMES_BOLD, 12))));
            PdfPCell foot1 = new PdfPCell(new Phrase(new Chunk("Serving All your Web Development Needs", FontFactory.GetFont(FontFactory.TIMES, 12))));
            foot.HorizontalAlignment = Element.ALIGN_LEFT;
            foot.Border = iTextSharp.text.Rectangle.NO_BORDER;
            foot.Colspan = 2;
            //foot.FixedHeight = 10.0f;
            foot1.HorizontalAlignment = Element.ALIGN_LEFT;
            foot1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            foot1.Colspan = 2;

            footer.AddCell(foot);
            footer.AddCell(foot1);

            //adding all tables to the document 
            doc.Add(tablebefore);
            doc.Add(table1);

            doc.Add(table3);
            doc.Add(advice);
            doc.Add(RegardsTable);
            doc.Add(OwnersTable);
            doc.Add(footer);
            // FooterTable.WriteSelectedRows(0, -1, doc.LeftMargin, doc.BottomMargin, DocSignature);

            doc.Close();
            print();
            inserttodb();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search();
            groupid = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            endingdate = datepick.Text.ToString();
            BaseColor myColor = WebColors.GetRGBColor("#D3D3D3");
            BaseColor colorBorder = WebColors.GetRGBColor("#000000");
            var fontHeaderbold_12 = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
            var fontHeaderbold_10 = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            var fontheader_10 = FontFactory.GetFont(FontFactory.TIMES, 10);
            var fontheader_8 = FontFactory.GetFont(FontFactory.TIMES, 12);
            //new document with A4 page size started
            Document doc = new Document(PageSize.A4);

            //New folder created  to save prescription pdf            
            System.IO.Directory.CreateDirectory(@"D:\AstuteFiles\TerminationLetters\");
            // pdf path define
            var output = new FileStream((@"D:\AstuteFiles\TerminationLetters\" + txtEmpName.Text + "-TerminationLetter.pdf"), FileMode.Create);

            filepath = output.Name.ToString();
            var writer = PdfWriter.GetInstance(doc, output);
            doc.Open();
            //new logo generated
            //var logo = iTextSharp.text.Image.GetInstance((@"..\1.png"));
            //logo.SetAbsolutePosition(360, 840);
            //logo.Alignment = 40;
            //logo.ScaleAbsoluteHeight(70);
            //logo.ScaleAbsoluteWidth(70);
            // first table created with Doctors information
            PdfPTable tablebefore = new PdfPTable(2);
            tablebefore.DefaultCell.Border = 0;
            tablebefore.WidthPercentage = 80;
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 2;
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            Phrase phrase0 = new Phrase();
            phrase0.Add(new Chunk(" "));
            cell.AddElement(phrase0);
            tablebefore.AddCell(cell);
            tablebefore.SpacingAfter = 55.0f;




            PdfPTable table1 = new PdfPTable(3);
            table1.DefaultCell.Border = 0;
            //table1.DefaultCell.BackgroundColor = myColor;
            table1.WidthPercentage = 100;
            //var titleFont = new iTextSharp.text.Font();
            //var subTitleFont = new iTextSharp.text.Font();
            PdfPCell cell11 = new PdfPCell();
            cell11.Colspan = 1;
            cell11.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cell11.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            Phrase phrase = new Phrase();
            phrase.Add(new Chunk());
            cell11.AddElement(phrase);
            PdfPCell cellcenter = new PdfPCell();
            cellcenter.BorderWidth = 0;
            cellcenter.HorizontalAlignment = Element.ALIGN_CENTER;
            float[] columnWidths = new float[] { 30f, 20f, 30f };
            PdfPCell cell2 = new PdfPCell();
            cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell2.BorderWidth = 0;
            Phrase phrase2 = new Phrase();
            phrase2.Add(new Chunk("                   Dated: " + DateTime.Now.Date.ToString("dd-MM-yyyy"), FontFactory.GetFont(FontFactory.TIMES, 10)));
            cell2.AddElement(phrase2);
            PdfPCell cell3 = new PdfPCell();
            cell3.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            PdfPCell emptycell = new PdfPCell(new Phrase(" ")); emptycell.Colspan = 3;
            table1.AddCell(cell11);
            table1.AddCell(cellcenter);
            table1.AddCell(cell2);
            table1.SpacingBefore = 80.0f;
            table1.SpacingAfter = 20.0f;



            // third table created with History and Symptoms 
            PdfPTable table3 = new PdfPTable(2);
            table3.WidthPercentage = 80;
            Chunk chunk1 = new Chunk(("TO WHOM IT MAY CONCERN"), FontFactory.GetFont(FontFactory.TIMES_BOLD, 14));
            chunk1.SetUnderline(2, -3);
            PdfPCell Historr = new PdfPCell(new Phrase(chunk1));
            Historr.FixedHeight = 20.0f;
            Historr.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Historr.HorizontalAlignment = Element.ALIGN_CENTER;
            Historr.Colspan = 2;
            PdfPCell nextdate = new PdfPCell(new Phrase("(Termination Letter)", FontFactory.GetFont(FontFactory.TIMES_BOLD, 12)));
            nextdate.Border = iTextSharp.text.Rectangle.NO_BORDER;
            nextdate.HorizontalAlignment = Element.ALIGN_CENTER;
            nextdate.Colspan = 2;
            table3.AddCell(Historr);
            table3.AddCell(nextdate);
            table3.SpacingAfter = 25.0f;



            //5th table for advice 
            PdfPTable advice = new PdfPTable(2);
            advice.WidthPercentage = 90;
            string empname = txtEmpName.Text.ToString();
            Chunk ch1 = new Chunk(empname, FontFactory.GetFont(FontFactory.TIMES_BOLD, 10));
            Chunk ch2 = new Chunk(txtdesignation.Text.ToString(), FontFactory.GetFont(FontFactory.TIMES_BOLD, 10));

            PdfPCell note = new PdfPCell(new Phrase("This is to certify that Mr." + ch1 + " S/O " + txtfathername.Text.ToString() + ", holding CNIC(" + txtNationalty.Text.ToString() + ") was employed with us as '" + ch2 + "' in '" + department + " Team' is being informed that his services are not required by the company and is terminated effective immidiately. Your outstandings would be either transfered to your bank account or will be sent through cheque.", FontFactory.GetFont(FontFactory.TIMES, 12)));
            note.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //note.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            note.HorizontalAlignment = Element.ALIGN_LEFT;
            note.Colspan = 2;
            note.FixedHeight = 50.0f;

            PdfPCell note2 = new PdfPCell(new Phrase("Thankyou very much for being a part of Astute Solutions.", FontFactory.GetFont(FontFactory.TIMES, 12)));
            note2.Border = iTextSharp.text.Rectangle.NO_BORDER;
            note2.HorizontalAlignment = Element.ALIGN_LEFT;
            note2.Colspan = 2;
            note2.FixedHeight = 40.0f;
            PdfPCell note3 = new PdfPCell(new Phrase("Best of luck", FontFactory.GetFont(FontFactory.TIMES, 12)));
            note3.HorizontalAlignment = Element.ALIGN_LEFT;
            note3.Border = iTextSharp.text.Rectangle.NO_BORDER;
            note3.Colspan = 2;
            note3.FixedHeight = 50.0f;
            advice.AddCell(note);
            advice.AddCell(note2);
            advice.AddCell(note3);

            string nextapp = "";



            //6th table for doc signature and next appointment details
            PdfPTable RegardsTable = new PdfPTable(1);
            RegardsTable.WidthPercentage = 90;
            PdfPCell Regards = new PdfPCell(new Phrase(new Chunk("Regards", FontFactory.GetFont(FontFactory.TIMES_BOLD, 12))));
            Regards.HorizontalAlignment = Element.ALIGN_LEFT;
            Regards.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Regards.Colspan = 2;
            Regards.FixedHeight = 30.0f;
            RegardsTable.AddCell(Regards);
            RegardsTable.SpacingAfter = 60.0f;

            PdfPTable OwnersTable = new PdfPTable(2);
            OwnersTable.WidthPercentage = 90;
            string ownerchunk = txtownerdetails.Text.ToString();

            PdfPCell owner = new PdfPCell(new Phrase(new Chunk(ownerchunk, FontFactory.GetFont(FontFactory.TIMES_BOLD, 12))));
            owner.HorizontalAlignment = Element.ALIGN_LEFT;
            owner.Border = iTextSharp.text.Rectangle.NO_BORDER;
            owner.Colspan = 2;
            owner.FixedHeight = 30.0f;
            OwnersTable.AddCell(owner);

            PdfPTable footer = new PdfPTable(2);
            footer.WidthPercentage = 90;
            PdfPCell foot = new PdfPCell(new Phrase(new Chunk("Astute Solutions", FontFactory.GetFont(FontFactory.TIMES_BOLD, 12))));
            PdfPCell foot1 = new PdfPCell(new Phrase(new Chunk("Serving All your Web Development Needs", FontFactory.GetFont(FontFactory.TIMES, 12))));
            foot.HorizontalAlignment = Element.ALIGN_LEFT;
            foot.Border = iTextSharp.text.Rectangle.NO_BORDER;
            foot.Colspan = 2;
            //foot.FixedHeight = 10.0f;
            foot1.HorizontalAlignment = Element.ALIGN_LEFT;
            foot1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            foot1.Colspan = 2;

            footer.AddCell(foot);
            footer.AddCell(foot1);

            //adding all tables to the document 
            doc.Add(tablebefore);
            doc.Add(table1);

            doc.Add(table3);
            doc.Add(advice);
            doc.Add(RegardsTable);
            doc.Add(OwnersTable);
            doc.Add(footer);
            // FooterTable.WriteSelectedRows(0, -1, doc.LeftMargin, doc.BottomMargin, DocSignature);

            doc.Close();
            print();
            inserttodbTermination();
        }
        public void inserttodbTermination()
        {
            SqlConnection conStr = new SqlConnection();
            conStr.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
            conStr.Open();
            string query = "INSERT INTO TerminationLetter([NameEmp],[Date],[PrintStatus])Values(@name,@date,@status)";

            using (SqlCommand cmd = new SqlCommand(query, conStr))
            {
                cmd.Parameters.AddWithValue("name", txtEmpName.Text.ToString());
                cmd.Parameters.AddWithValue("date", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("status", status);
                cmd.ExecuteNonQuery();
            }
            conStr.Close();
        }

        public void btnWeeklyReports_Click(object sender, EventArgs e)
        {
            string EmpName = "";
            string EmpID = "";
            string email = "";
            string searchemp = "";
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            if (txtEMPid.Text.Trim() != null && txtEMPid.Text.Trim() != "")
            {
                searchemp = "select * from Employees where EmpID='" + txtEMPid.Text.ToString() + "' AND Active=1";
            }
            else
            {
                searchemp = "select * from Employees where Active=1";
            }
            SqlCommand myCommand = new SqlCommand(searchemp, conStr);
            SqlDataReader myReader = null;
            conStr.Open();
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                EmpID = (myReader["EmpID"].ToString());
                EmpName = (myReader["Emp_Name"].ToString());
                email = (myReader["Emp_Email"].ToString());
                string query;
                datefromt = datefrom.Value.ToString("yyyy-MM-dd");
                datetot = dateto.Value.ToString("yyyy-MM-dd");
                DemoReportViewer dm = new DemoReportViewer();
                string appPath = @"D:\AstuteFiles\WeeklyReports";
                string reportPath = @"\" + EmpName + "-" + EmpID + "-WeeklyReport.pdf";
                string fullpath = appPath + reportPath;
                CrystalReport1 objrpt = new CrystalReport1();
                DataTable dt = new DataTable();
                query = "select EMPid, Name, TimeIn,TimeOUT, Date,Status,TotalHours from Attendence where EMPid = '" + EmpID + "'and Date Between '" + datefromt + "' AND '" + datetot + "' Order by Date asc ";
                SqlCommand cmd = new SqlCommand(query, conStr);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                objrpt.SetDataSource(dt);
                objrpt.ExportToDisk(ExportFormatType.PortableDocFormat, fullpath);
                objrpt.Close();
                string attachment = fullpath;
                if (checkSendEmail.Checked == true)
                {
                    if (email != null && email != "")
                    {
                        if (attachment != null)
                        {
                            SendMail(email, "Weekly Attendence Report", "Please Find The Attachment", attachment);
                        }
                    }
                }
                LateCount(EmpID);
            }
            conStr.Close();
        }

        private void btnSalarySheet_Click(object sender, EventArgs e)
        {
            string query;
            datefromt = datefrom.Value.ToString("yyyy-MM-dd");
            datetot = dateto.Value.ToString("yyyy-MM-dd");
            DemoReportViewer dm = new DemoReportViewer();
            string appPath = @"D:\AstuteFiles\MonthlyReports";
            string reportPath = @"\"+datefrom.Value.ToString("MMMM")+"-Monthly.pdf";
            MonthlyReports objrpt = new MonthlyReports();
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            DataTable dt = new DataTable();
            query = "select EMPid, Name, TimeIn,TimeOUT, Date, Status,TotalHours from Attendence where Date Between '" + datefromt + "' AND '" + datetot + "' order by EMPid asc";
            SqlCommand cmd = new SqlCommand(query, conStr);
            conStr.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            objrpt.SetDataSource(dt);
            conStr.Close();
            objrpt.ExportToDisk(ExportFormatType.PortableDocFormat, appPath + reportPath);
            objrpt.Close(); 
        }


        public void LateCount(string Empid)
        {
            int id;
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            string queryLate = "select Count(*) from Attendence where Status='Late' and EMPid='"+ Empid + "'";
            string queryShortLeave = "select Count(*) from Attendence where Status='ShortLeave' and EMPid='" + Empid + "'";
            string queryAbsent = "select Count(*) from Attendence where Status='Absent' and EMPid='" + Empid + "'";
            string queryLeave = "select Count(*) from Attendence where Status='Leave' and EMPid='" + Empid + "'";
            SqlCommand Late = new SqlCommand(queryLate, conStr);
            SqlCommand ShortLeave = new SqlCommand(queryShortLeave, conStr);
            SqlCommand Absent = new SqlCommand(queryAbsent, conStr);
            SqlCommand Leave = new SqlCommand(queryLeave, conStr);
            conStr.Open();
            int LateCount =  (Int32)Late.ExecuteScalar();
            int Shortleave = (Int32)ShortLeave.ExecuteScalar();
            int absent = (Int32)Absent.ExecuteScalar();
            int leave = (Int32)Leave.ExecuteScalar();
            string InsertValues = "INSERT INTO EMP_LateDetails([Date],[EmpID],[LateCount],[ShortLeaveCount] ,[AbsentCount],[LeaveCount],[Month],[Year])"
                +"VALUES(@date,@empid,@late,@short,@absent,@leave,@month,@year)";
            using (SqlCommand cmd = new SqlCommand(InsertValues, conStr))
            {
                cmd.Parameters.AddWithValue("date", DateTime.Now.ToString("dd-MMM-yyyy"));
                cmd.Parameters.AddWithValue("empid", Empid);
                cmd.Parameters.AddWithValue("late", LateCount);
                cmd.Parameters.AddWithValue("short", Shortleave);
                cmd.Parameters.AddWithValue("absent", absent);
                cmd.Parameters.AddWithValue("leave", leave);
                cmd.Parameters.AddWithValue("month", datefrom.Value.ToString("MMMM"));
                cmd.Parameters.AddWithValue("year", datefrom.Value.ToString("yyyy"));
                cmd.CommandType = CommandType.Text;
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            conStr.Close();
        }
        
        public static void SendMail(string recipient, string subject, string body, string attachmentFilename)
        {

            string emailFrom = "info@astutesol.com";
            string password = "info@1122";
           // SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.UseDefaultCredentials = false;
            NetworkCredential basicCredential = new NetworkCredential(emailFrom, password);
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(emailFrom);
            // setup up the host, increase the timeout to 5 minutes
            //smtpClient.Host = "smtp.gmail.com";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.Timeout = (60 * 5 * 1000);
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            message.From = fromAddress;
            message.Subject = subject;
            message.IsBodyHtml = false;
            message.Body = body;
            message.To.Add(recipient);
            if (attachmentFilename != null)
            { message.Attachments.Add(new Attachment(attachmentFilename)); }
            smtpClient.Send(message);
        }

        private void ReportsUserControl1_Load(object sender, EventArgs e)
        {
            dateto.MaxDate = DateTime.Today;
            datefrom.MaxDate = DateTime.Today;
        }
    }
}
