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
using System.IO;

namespace OMS_Astute
{
    public partial class AttendenceModeUserControl1 : UserControl, DPFP.Capture.EventHandler
    {
        string msg = "";
        string path = "";
        int stats = 0;
        string totalhours = "";
        string imagepath = "";
        string day = "";

        public AttendenceModeUserControl1()
        {
            InitializeComponent();
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            MakeReport2("The fingerprint sample was captured.", 0);
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The finger was removed from the fingerprint reader.");

        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The fingerprint reader was touched.");

        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            SetStatus("The fingerprint reader is connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            SetStatus("The fingerprint reader is disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                SetStatus("The quality of the fingerprint sample is good.");
            else
                SetStatus("The quality of the fingerprint sample is poor.");
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;

        }
        public void UpdateStatus()
        {
            StatusText2.Text = msg;
        }
        public string fingerpath = "";
        protected virtual void Init()
        {
            Verificator = new DPFP.Verification.Verification();
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else { }
                //txtboxUpdate.AppendText(Environment.NewLine + "Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DrawPicture(Bitmap bitmap)
        {
            try
            {
                this.Invoke(new Function(delegate ()
                {
                    DisplayPicture.Image = new Bitmap(bitmap, DisplayPicture.Size);   // fit the image into the picture box
                }));
            }
            catch (Exception)
            {


            }

        }
        public virtual void Process(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
            if (rdbTIMEIN.Checked == true)
            {
                getpath(Sample);
            }

            else if (rdbTIMEOUT.Checked == true)
            {
                markOUT(Sample);
            }

        }
        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    //txtboxUpdate.AppendText(Environment.NewLine + "Using the fingerprint reader, scan your fingerprint.");
                }
                catch
                {
                    //txtboxUpdate.AppendText(Environment.NewLine + "Can't initiate capture!");
                }
            }
        }
        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    //txtboxUpdate.AppendText(Environment.NewLine + "Can't terminate capture!");
                }
            }
        }
        protected void SetStatus(string status)
        {
            this.Invoke(new Function(delegate ()
            {
                StatusLine.Text = status;
            }));
        }

        protected void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate ()
            {
                Prompt.Text = prompt;
            }));
        }
        private void MakeReport2(string message, int color)
        {

            try
            {
                this.Invoke(new Function(delegate ()
                {
                    if (color == 1)
                    {
                        StatusText2.ForeColor = Color.Red;
                    }
                    else if (color == 2)
                    {
                        StatusText2.ForeColor = Color.Green;
                    }
                    else if (color == 3)
                    {
                        StatusText2.ForeColor = Color.Blue;
                    }
                    //else {
                    //    StatusText2.ForeColor = Color.Black;

                    //}
                    StatusText2.AppendText(message + "\r\n");
                }));
            }
            catch (Exception)
            {


            }

        }


        private DPFP.Capture.Capture Capturer;
        public DPFP.Verification.Verification Verificator;

        public void getpath(DPFP.Sample Sample)
        {
            string empid = "", empname = "", status = "", TimeIN = "", TimeOUT = "", updateQuery = "";
            DateTime datetoday = DateTime.Today.Date;
            string comparedate = DateTime.Today.Date.ToString("yyyy-MM-dd");
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            conStr.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from Employees", conStr);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {

                path = (myReader["BiometricImage"].ToString());
                if (path != "")
                {
                    using (FileStream fs = File.Open(path, FileMode.Open))
                    {
                        // Process the sample and create a feature set for the enrollment purpose.
                        DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
                        if (features != null)
                        {

                            DPFP.Template template = new DPFP.Template(fs);
                            DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                            Verificator.Verify(features, template, ref result);
                            if (result.Verified)
                            {
                                MakeReport2("The fingerprint [VERIFIED].", 0);

                                this.Invoke(new Function(delegate ()
                                {
                                    empID.Text = (myReader["EmpID"].ToString());
                                    empName.Text = (myReader["Emp_Name"].ToString());
                                    empTimeMarker.Text = DateTime.Now.ToString("hh:mm tt");
                                    empStatus.Text = "Present";
                                    if (imagepath != null || imagepath != "" || imagepath != " ")
                                    {
                                        imagepath = (myReader["ProfileImg"].ToString());
                                        //ProfileImg.Image = new Bitmap(imagepath);
                                    }
                                }));
                                SqlDataReader myreader2 = null;
                                string dbdate = string.Format("yyyy-MM-dd");
                                if (DateTime.Today.Date != datetoday)
                                {
                                    SqlCommand cmd1 = new SqlCommand("select * from Attendence where EMPid = '" + empID.Text + "' AND Date='" + datetoday + "'", conStr);
                                    myreader2 = cmd1.ExecuteReader();
                                    if (myreader2.Read())
                                    {
                                        dbdate = (myreader2["Date"].ToString());
                                        TimeIN = (myreader2["TimeIn"].ToString());
                                        stats = 2;
                                        MakeReport2("Attendence Already Marked For" + datetoday, 0);
                                    }
                                    else
                                    {
                                        stats = 0;
                                        MakeReport2("New Attendence For " + datetoday + " Added", 0);
                                    }
                                }
                                else
                                {
                                    SqlCommand cmd = new SqlCommand("select * from Attendence where EMPid = '" + empID.Text + "' AND Date='" + comparedate + "'", conStr);
                                    myreader2 = cmd.ExecuteReader();
                                    if (myreader2.Read())
                                    {
                                        dbdate = (myreader2["Date"].ToString());
                                        TimeIN = (myreader2["TimeIn"].ToString());
                                        stats = 2;
                                        MakeReport2("Attendence Already Marked For" + datetoday, 0);

                                    }
                                    else
                                    {
                                        stats = 0;
                                        MakeReport2("New Attendence For " + datetoday + " Added", 0);
                                    }
                                }

                                fs.Dispose();
                                if (stats == 0)
                                {
                                    if (rdbTIMEIN.Checked == true)
                                    {
                                        if (DateTime.Now.Hour <= 9 && DateTime.Now.Minute <= 40)
                                        {
                                            MakeReport2("GOOD MORNING", 2);
                                            empid = empID.Text;
                                            empname = empName.Text;
                                            TimeIN = empTimeMarker.Text;
                                            status = "Present";
                                            empStatus.ForeColor = Color.ForestGreen;
                                            updateQuery = "Insert into Attendence  ([EMPid],[Name],[TimeIn],[TimeOUT],[Date],[Status],[TotalHours]) Values(@empid,@name,@timein,@timeout,@date,@status,@totalhours)";
                                            MakeReport2("Welcome " + empName.Text, 3);
                                            using (SqlCommand updateattendence = new SqlCommand(updateQuery, conStr))
                                            {
                                                updateattendence.Parameters.AddWithValue("empid", empid);
                                                updateattendence.Parameters.AddWithValue("name", empname);
                                                updateattendence.Parameters.AddWithValue("timein", TimeIN);
                                                updateattendence.Parameters.AddWithValue("timeout", TimeOUT);
                                                updateattendence.Parameters.AddWithValue("date", datetoday);
                                                updateattendence.Parameters.AddWithValue("status", status);
                                                updateattendence.Parameters.AddWithValue("totalhours", totalhours);
                                                updateattendence.ExecuteNonQuery();

                                            }

                                        }
                                        else if (DateTime.Now.Hour > 9 && DateTime.Now.Hour <= 17 || DateTime.Now.Hour <= 9 && DateTime.Now.Minute > 40)
                                        {
                                            MakeReport2("You Are Marked LATE TODAY", 1);
                                            empid = empID.Text;
                                            empname = empName.Text;
                                            TimeIN = empTimeMarker.Text;
                                            status = "Late";
                                            this.Invoke(new Function(delegate ()
                                            {
                                                empStatus.Text = "Late";
                                                empStatus.ForeColor = Color.Red;
                                            }));
                                            updateQuery = "Insert into Attendence  ([EMPid],[Name],[TimeIn],[TimeOUT],[Date],[Status],[TotalHours]) Values(@empid,@name,@timein,@timeout,@date,@status,@totalhours)";
                                            MakeReport2("Welcome " + empName.Text, 1);
                                            using (SqlCommand updateattendence = new SqlCommand(updateQuery, conStr))
                                            {
                                                updateattendence.Parameters.AddWithValue("empid", empid);
                                                updateattendence.Parameters.AddWithValue("name", empname);
                                                updateattendence.Parameters.AddWithValue("timein", TimeIN);
                                                updateattendence.Parameters.AddWithValue("timeout", TimeOUT);
                                                updateattendence.Parameters.AddWithValue("date", datetoday);
                                                updateattendence.Parameters.AddWithValue("status", status);
                                                updateattendence.Parameters.AddWithValue("totalhours", totalhours);
                                                updateattendence.ExecuteNonQuery();

                                            }
                                        }

                                    }



                                    else if (DateTime.Now.Hour >= 17)
                                    {
                                        rdbTIMEOUT.Checked = true;
                                        MakeReport2("Good BYE", 3);
                                        empStatus.Text = "Good Bye";
                                        empStatus.ForeColor = Color.Tomato;
                                        empid = empID.Text;
                                        empname = empName.Text;
                                        TimeOUT = empTimeMarker.Text;
                                        updateQuery = "Update Attendence set TimeOUT='" + TimeOUT + "'where EMPid='" + empid + "' and Date='" + datetoday + "'";
                                        SqlCommand cmd = new SqlCommand(updateQuery, conStr);
                                        cmd.ExecuteNonQuery();
                                    }


                                    MakeReport2(empName.Text + "\n" + "Your [TIME IN] Marked at " + empTimeMarker.Text, 0);

                                }
                               

                                else if (stats == 2)
                                {
                                    if (DateTime.Now.Hour >= 17)
                                    {
                                        MakeReport2("Good BYE", 3);
                                        empid = empID.Text;
                                        empname = empName.Text;
                                        TimeOUT = empTimeMarker.Text;
                                       
                                        this.Invoke(new Function(delegate ()
                                        {
                                            empStatus.Text = "Good Bye";
                                        empStatus.ForeColor = Color.Tomato;
                                        }));
                                        string timein = TimeIN;
                                        string timeout = TimeOUT;
                                        if (TimeIN != "" && TimeOUT != "")
                                        {
                                            DateTime In = Convert.ToDateTime(TimeIN);
                                            DateTime Out = Convert.ToDateTime(TimeOUT).AddHours(-1);
                                            day = System.DateTime.Now.ToString("dddd");
                                            if (day == "Friday" && DateTime.Now.Hour >= 15)
                                            {
                                                Out = Convert.ToDateTime(TimeOUT).AddHours(-1.5);
                                            }
                                            else if (day != "Friday" && DateTime.Now.Hour >= 14)
                                            {
                                                Out = Convert.ToDateTime(TimeOUT).AddHours(-1);
                                            }
                                            if (In < Out)
                                            {
                                                totalhours = (Out - In).ToString();
                                            }
                                            else
                                            {

                                            }
                                        }
                                        updateQuery = "UPDATE Attendence Set TimeOUT='" + timeout + "', TotalHours='" + totalhours + "' where EMPid='" + empid + "' AND Date='" + datetoday + "'";
                                        SqlCommand cmd = new SqlCommand(updateQuery, conStr);
                                        cmd.ExecuteNonQuery();
                                        MakeReport2(empName.Text + "\n" + "Your [TIME OUT] Marked at " + empTimeMarker.Text, 0);
                                    }
                                    else
                                    {
                                        MakeReport2(empName.Text + "\n" + "Ask Admin To Mark Attendence" + empTimeMarker.Text, 0);

                                    }
                                   
                                }

                                empName.ForeColor = Color.Green;
                                empTimeMarker.ForeColor = Color.Blue;
                                break;
                            }
                        }
                        else
                            MakeReport2("The fingerprint [NOT VERIFIED].", 0);
                    }
                }
            }
            if (DateTime.Now.Hour >= 14)
            {
                MarkAbsent();
            }

            myReader.Close();
            conStr.Close();
                        
        }

        public void markOUT(DPFP.Sample Sample)
        {

            string empid = "", empname = "", status = "", TimeIN = "", TimeOUT = "", updateQuery = "";
            DateTime datetoday = DateTime.Today.Date;
            string comparedate = DateTime.Today.Date.ToString("yyyy-MM-dd");
            SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
            conStr.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from Employees", conStr);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {

                path = (myReader["BiometricImage"].ToString());
                if (path != "")
                {
                    using (FileStream fs = File.Open(path, FileMode.Open))
                    {
                        // Process the sample and create a feature set for the enrollment purpose.
                        DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
                        if (features != null)
                        {

                            DPFP.Template template = new DPFP.Template(fs);
                            DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                            Verificator.Verify(features, template, ref result);
                            if (result.Verified)
                            {
                                MakeReport2("The fingerprint [VERIFIED].", 0);

                                this.Invoke(new Function(delegate ()
                                {
                                    empID.Text = (myReader["EmpID"].ToString());
                                    empName.Text = (myReader["Emp_Name"].ToString());
                                    empTimeMarker.Text = DateTime.Now.ToString("hh:mm tt");
                                    empStatus.Text = "Present";
                                }));
                                SqlDataReader myreader2 = null;
                                string dbdate = string.Format("yyyy-MM-dd");
                                if (DateTime.Today.Date != datetoday)
                                {
                                    SqlCommand cmd1 = new SqlCommand("select * from Attendence where EMPid = '" + empID.Text + "' AND Date='" + datetoday + "'", conStr);
                                    myreader2 = cmd1.ExecuteReader();
                                    if (myreader2.Read())
                                    {
                                        dbdate = (myreader2["Date"].ToString());
                                        TimeIN = (myreader2["TimeIn"].ToString());
                                        stats = 2;
                                        MakeReport2("Attendence Already Marked For" + datetoday, 1);
                                    }
                                    else
                                    {
                                        stats = 0;
                                        MakeReport2("New Attendence For " + datetoday + " Added", 2);
                                    }
                                }
                                else
                                {
                                    SqlCommand cmd = new SqlCommand("select * from Attendence where EMPid = '" + empID.Text + "' AND Date='" + comparedate + "'", conStr);
                                    myreader2 = cmd.ExecuteReader();
                                    if (myreader2.Read())
                                    {
                                        dbdate = (myreader2["Date"].ToString());
                                        TimeIN = (myreader2["TimeIn"].ToString());
                                        stats = 2;
                                        MakeReport2("Attendence Already Marked For" + datetoday, 1);

                                    }
                                    else
                                    {
                                        stats = 0;
                                        MakeReport2("New Attendence For " + datetoday + " Added", 2);
                                    }
                                }

                                fs.Dispose();
                                if (stats == 0)
                                {
                                }
                                else if (stats == 2)
                                {

                                    rdbTIMEOUT.Checked = true;
                                    MakeReport2("Good BYE", 2);

                                    empid = empID.Text;
                                    empname = empName.Text;
                                    TimeOUT = empTimeMarker.Text;
                                    this.Invoke(new Function(delegate ()
                                    {
                                        empStatus.Text = "Good Bye";
                                        empStatus.ForeColor = Color.Tomato;
                                    }));
                                    string timein = TimeIN;
                                    string timeout = TimeOUT;
                                    if (TimeIN != "" && TimeOUT != "")
                                    {
                                        
                                        DateTime In = Convert.ToDateTime(TimeIN);
                                        DateTime Out = Convert.ToDateTime(TimeOUT);
                                        day = System.DateTime.Now.ToString("dddd");
                                        if (day == "Friday" && DateTime.Now.Hour >= 15)
                                        {
                                            Out = Convert.ToDateTime(TimeOUT).AddHours(-1.5);
                                        }
                                        else if(day != "Friday" && DateTime.Now.Hour >= 14)
                                        {
                                            Out = Convert.ToDateTime(TimeOUT).AddHours(-1);
                                        }
                                        if (In < Out )
                                        {
                                            totalhours = (Out - In).ToString();
                                        }
                                        else
                                        {

                                        }
                                    }
                                    updateQuery = "UPDATE Attendence Set TimeOUT='" + timeout + "', TotalHours='" + totalhours + "' where EMPid='" + empid + "' AND Date='" + datetoday + "'";
                                    SqlCommand cmd = new SqlCommand(updateQuery, conStr);
                                    cmd.ExecuteNonQuery();

                                }
                                MakeReport2(empName.Text + "\n" + "Your [TIME OUT] Marked at " + empTimeMarker.Text, 2);
                                empName.ForeColor = Color.Green;
                                empTimeMarker.ForeColor = Color.Blue;






                                break;
                            }


                        }
                        else
                            MakeReport2("The fingerprint [NOT VERIFIED].", 1);
                    }


                }



            }

            myReader.Close();
            conStr.Close();
            this.Invoke(new Function(delegate ()
            {
                rdbTIMEIN.Checked = true;
            }));
            if (DateTime.Now.Hour >= 14)
            {
                MarkAbsent();
            }


        }
        private void AttendenceModeUserControl1_Load(object sender, EventArgs e)
        {
            Init();
            Start();
            SetPrompt("Place your Registered Finger to Mark Attendence.");
            lblDate.Text = DateTime.Now.Date.ToString("dddd, dd, MMMM yyyy");
            rdbTIMEIN.Checked = true;
        }

        public void MarkAbsent() {

            string AbsentEmpID = ""; 
            var d = DateTime.Now;
            string empid = "", AbsentEmpName = "", status = "Absent", AbsentEmpTimeIN = "", AbsentEmpTimeOUT = "", AbsentEmpTotalHours = "" ;
            DateTime datetoday = DateTime.Today.Date;
            if (d.Hour >= 14  && d.Minute >= 05)
            {
                var Month = d.Month;
                var Day = d.Day;
                var Year = d.Year;
                SqlConnection conStr = new SqlConnection(@"Data Source=.\MSSQLSERVER2019;Initial Catalog=LadyDB;Integrated Security=True;MultipleActiveResultSets=True");
                conStr.Open();
                string queryAbsentEmp = "SELECT * FROM   Employees WHERE   NOT EXISTS (SELECT 1 FROM   Attendence WHERE  Attendence.EMPid = Employees.EmpID and MONTH(Date) ='" + Month+"' and DAY(Date) = '"+Day+"' and YEAR(DATE)= '"+Year+ "')and Active=1";
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(queryAbsentEmp, conStr);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    AbsentEmpID = (myReader["EmpID"].ToString());
                    AbsentEmpName = (myReader["Emp_Name"].ToString());
                    AbsentEmpTimeIN = "00:00 AM";
                    AbsentEmpTimeOUT = "00:00 PM";
                    AbsentEmpTotalHours = "00:00";
                    string queryMarkAbsent = "Insert into Attendence  ([EMPid],[Name],[TimeIn],[TimeOUT],[Date],[Status],[TotalHours]) Values(@empid,@name,@timein,@timeout,@date,@status,@totalhours)";
                    using (SqlCommand updateattendence = new SqlCommand(queryMarkAbsent, conStr))
                    {
                        updateattendence.Parameters.AddWithValue("empid", AbsentEmpID);
                        updateattendence.Parameters.AddWithValue("name", AbsentEmpName);
                        updateattendence.Parameters.AddWithValue("timein", AbsentEmpTimeIN);
                        updateattendence.Parameters.AddWithValue("timeout", AbsentEmpTimeOUT);
                        updateattendence.Parameters.AddWithValue("date", datetoday);
                        updateattendence.Parameters.AddWithValue("status", status);
                        updateattendence.Parameters.AddWithValue("totalhours", AbsentEmpTotalHours);
                        updateattendence.ExecuteNonQuery();
                        MakeReport2(AbsentEmpName + "\n" + "Marked Absent" , 0);

                    }
                }


                conStr.Close();

            }
        }
    }
}
