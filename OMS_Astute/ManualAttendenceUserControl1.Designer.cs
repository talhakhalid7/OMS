namespace OMS_Astute
{
    partial class ManualAttendenceUserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OverTimeIN = new System.Windows.Forms.DateTimePicker();
            this.chkTimeout = new System.Windows.Forms.CheckBox();
            this.timeOUT = new System.Windows.Forms.DateTimePicker();
            this.timeIN = new System.Windows.Forms.DateTimePicker();
            this.btngetInfo = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.todayDate = new System.Windows.Forms.DateTimePicker();
            this.StatusBox = new System.Windows.Forms.ComboBox();
            this.txt_WorkingHours = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.id_txt = new System.Windows.Forms.TextBox();
            this.lblDash = new System.Windows.Forms.Label();
            this.txtEmpNAmeOverTime = new System.Windows.Forms.TextBox();
            this.txtempIDOvertime = new System.Windows.Forms.TextBox();
            this.lblEndOvertime = new System.Windows.Forms.Label();
            this.lblStartOverTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUdateOvertime = new System.Windows.Forms.Button();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblEmployeeId = new System.Windows.Forms.Label();
            this.txtdatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOvergetInfo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OverTimeOut = new System.Windows.Forms.DateTimePicker();
            this.lblEmployeIDovertime = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbldate = new System.Windows.Forms.Label();
            this.MenualattendenceGrp = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.MenualattendenceGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // OverTimeIN
            // 
            this.OverTimeIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverTimeIN.Location = new System.Drawing.Point(124, 113);
            this.OverTimeIN.Name = "OverTimeIN";
            this.OverTimeIN.Size = new System.Drawing.Size(200, 22);
            this.OverTimeIN.TabIndex = 17;
            // 
            // chkTimeout
            // 
            this.chkTimeout.AutoSize = true;
            this.chkTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTimeout.ForeColor = System.Drawing.Color.Red;
            this.chkTimeout.Location = new System.Drawing.Point(124, 246);
            this.chkTimeout.Name = "chkTimeout";
            this.chkTimeout.Size = new System.Drawing.Size(183, 20);
            this.chkTimeout.TabIndex = 18;
            this.chkTimeout.Text = "Check to Enter Time-OUT.";
            this.chkTimeout.UseVisualStyleBackColor = true;
            // 
            // timeOUT
            // 
            this.timeOUT.CustomFormat = "hh:mm tt";
            this.timeOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeOUT.Location = new System.Drawing.Point(124, 275);
            this.timeOUT.Name = "timeOUT";
            this.timeOUT.Size = new System.Drawing.Size(218, 22);
            this.timeOUT.TabIndex = 17;
            // 
            // timeIN
            // 
            this.timeIN.CustomFormat = "hh:mm";
            this.timeIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeIN.Location = new System.Drawing.Point(124, 215);
            this.timeIN.Name = "timeIN";
            this.timeIN.Size = new System.Drawing.Size(218, 22);
            this.timeIN.TabIndex = 16;
            // 
            // btngetInfo
            // 
            this.btngetInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngetInfo.Location = new System.Drawing.Point(227, 63);
            this.btngetInfo.Name = "btngetInfo";
            this.btngetInfo.Size = new System.Drawing.Size(82, 23);
            this.btngetInfo.TabIndex = 15;
            this.btngetInfo.Text = "Get Info >>";
            this.btngetInfo.UseVisualStyleBackColor = true;
            this.btngetInfo.Click += new System.EventHandler(this.btngetInfo_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(396, 317);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 37);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // todayDate
            // 
            this.todayDate.CustomFormat = "dd/MM/yyyy";
            this.todayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.todayDate.Location = new System.Drawing.Point(124, 31);
            this.todayDate.Name = "todayDate";
            this.todayDate.Size = new System.Drawing.Size(185, 22);
            this.todayDate.TabIndex = 13;
            this.todayDate.Value = new System.DateTime(2019, 11, 20, 11, 18, 50, 0);
            // 
            // StatusBox
            // 
            this.StatusBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.FormattingEnabled = true;
            this.StatusBox.Items.AddRange(new object[] {
            "Present",
            "Absent",
            "Late",
            "Half -Daay",
            "Short Leave"});
            this.StatusBox.Location = new System.Drawing.Point(124, 174);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(121, 24);
            this.StatusBox.TabIndex = 12;
            // 
            // txt_WorkingHours
            // 
            this.txt_WorkingHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_WorkingHours.Location = new System.Drawing.Point(124, 138);
            this.txt_WorkingHours.Name = "txt_WorkingHours";
            this.txt_WorkingHours.ReadOnly = true;
            this.txt_WorkingHours.Size = new System.Drawing.Size(185, 22);
            this.txt_WorkingHours.TabIndex = 9;
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(124, 101);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(185, 22);
            this.txt_Name.TabIndex = 8;
            // 
            // id_txt
            // 
            this.id_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_txt.Location = new System.Drawing.Point(124, 66);
            this.id_txt.Name = "id_txt";
            this.id_txt.Size = new System.Drawing.Size(70, 22);
            this.id_txt.TabIndex = 7;
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDash.Location = new System.Drawing.Point(186, 40);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(12, 16);
            this.lblDash.TabIndex = 5;
            this.lblDash.Text = "-";
            // 
            // txtEmpNAmeOverTime
            // 
            this.txtEmpNAmeOverTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpNAmeOverTime.Location = new System.Drawing.Point(202, 37);
            this.txtEmpNAmeOverTime.Name = "txtEmpNAmeOverTime";
            this.txtEmpNAmeOverTime.ReadOnly = true;
            this.txtEmpNAmeOverTime.Size = new System.Drawing.Size(100, 22);
            this.txtEmpNAmeOverTime.TabIndex = 4;
            // 
            // txtempIDOvertime
            // 
            this.txtempIDOvertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtempIDOvertime.Location = new System.Drawing.Point(124, 37);
            this.txtempIDOvertime.Name = "txtempIDOvertime";
            this.txtempIDOvertime.Size = new System.Drawing.Size(56, 22);
            this.txtempIDOvertime.TabIndex = 3;
            // 
            // lblEndOvertime
            // 
            this.lblEndOvertime.AutoSize = true;
            this.lblEndOvertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndOvertime.Location = new System.Drawing.Point(34, 158);
            this.lblEndOvertime.Name = "lblEndOvertime";
            this.lblEndOvertime.Size = new System.Drawing.Size(72, 16);
            this.lblEndOvertime.TabIndex = 2;
            this.lblEndOvertime.Text = "End Time :";
            // 
            // lblStartOverTime
            // 
            this.lblStartOverTime.AutoSize = true;
            this.lblStartOverTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartOverTime.Location = new System.Drawing.Point(31, 119);
            this.lblStartOverTime.Name = "lblStartOverTime";
            this.lblStartOverTime.Size = new System.Drawing.Size(75, 16);
            this.lblStartOverTime.TabIndex = 1;
            this.lblStartOverTime.Text = "Start Time :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Out-Time :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "In-Time :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Status :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Working Hours :";
            // 
            // btnUdateOvertime
            // 
            this.btnUdateOvertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUdateOvertime.Location = new System.Drawing.Point(340, 119);
            this.btnUdateOvertime.Name = "btnUdateOvertime";
            this.btnUdateOvertime.Size = new System.Drawing.Size(96, 59);
            this.btnUdateOvertime.TabIndex = 8;
            this.btnUdateOvertime.Text = "<<Update>>";
            this.btnUdateOvertime.UseVisualStyleBackColor = true;
            this.btnUdateOvertime.Click += new System.EventHandler(this.btnUdateOvertime_Click);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(0, 104);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(116, 16);
            this.lblEmployeeName.TabIndex = 2;
            this.lblEmployeeName.Text = "Employee Name :";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(544, 385);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(563, 179);
            this.dataGridView2.TabIndex = 8;
            // 
            // lblEmployeeId
            // 
            this.lblEmployeeId.AutoSize = true;
            this.lblEmployeeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeId.Location = new System.Drawing.Point(19, 69);
            this.lblEmployeeId.Name = "lblEmployeeId";
            this.lblEmployeeId.Size = new System.Drawing.Size(92, 16);
            this.lblEmployeeId.TabIndex = 1;
            this.lblEmployeeId.Text = "Employee ID :";
            // 
            // txtdatePicker
            // 
            this.txtdatePicker.CustomFormat = "dd/MM/yyyy";
            this.txtdatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtdatePicker.Location = new System.Drawing.Point(124, 79);
            this.txtdatePicker.Name = "txtdatePicker";
            this.txtdatePicker.Size = new System.Drawing.Size(200, 22);
            this.txtdatePicker.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Date :";
            // 
            // btnOvergetInfo
            // 
            this.btnOvergetInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOvergetInfo.Location = new System.Drawing.Point(340, 37);
            this.btnOvergetInfo.Name = "btnOvergetInfo";
            this.btnOvergetInfo.Size = new System.Drawing.Size(96, 23);
            this.btnOvergetInfo.TabIndex = 19;
            this.btnOvergetInfo.Text = "Get Info >>";
            this.btnOvergetInfo.UseVisualStyleBackColor = true;
            this.btnOvergetInfo.Click += new System.EventHandler(this.btnOvergetInfo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtdatePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOvergetInfo);
            this.groupBox1.Controls.Add(this.OverTimeOut);
            this.groupBox1.Controls.Add(this.OverTimeIN);
            this.groupBox1.Controls.Add(this.btnUdateOvertime);
            this.groupBox1.Controls.Add(this.lblDash);
            this.groupBox1.Controls.Add(this.txtEmpNAmeOverTime);
            this.groupBox1.Controls.Add(this.txtempIDOvertime);
            this.groupBox1.Controls.Add(this.lblEndOvertime);
            this.groupBox1.Controls.Add(this.lblStartOverTime);
            this.groupBox1.Controls.Add(this.lblEmployeIDovertime);
            this.groupBox1.Location = new System.Drawing.Point(15, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 188);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Over-Time Adjustment";
            // 
            // OverTimeOut
            // 
            this.OverTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverTimeOut.Location = new System.Drawing.Point(124, 152);
            this.OverTimeOut.Name = "OverTimeOut";
            this.OverTimeOut.Size = new System.Drawing.Size(200, 22);
            this.OverTimeOut.TabIndex = 18;
            // 
            // lblEmployeIDovertime
            // 
            this.lblEmployeIDovertime.AutoSize = true;
            this.lblEmployeIDovertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeIDovertime.Location = new System.Drawing.Point(19, 44);
            this.lblEmployeIDovertime.Name = "lblEmployeIDovertime";
            this.lblEmployeIDovertime.Size = new System.Drawing.Size(92, 16);
            this.lblEmployeIDovertime.TabIndex = 0;
            this.lblEmployeIDovertime.Text = "Employee ID :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(544, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(563, 360);
            this.dataGridView1.TabIndex = 6;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(63, 37);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(43, 16);
            this.lbldate.TabIndex = 0;
            this.lbldate.Text = "Date :";
            // 
            // MenualattendenceGrp
            // 
            this.MenualattendenceGrp.Controls.Add(this.chkTimeout);
            this.MenualattendenceGrp.Controls.Add(this.timeOUT);
            this.MenualattendenceGrp.Controls.Add(this.timeIN);
            this.MenualattendenceGrp.Controls.Add(this.btngetInfo);
            this.MenualattendenceGrp.Controls.Add(this.btnUpdate);
            this.MenualattendenceGrp.Controls.Add(this.todayDate);
            this.MenualattendenceGrp.Controls.Add(this.StatusBox);
            this.MenualattendenceGrp.Controls.Add(this.txt_WorkingHours);
            this.MenualattendenceGrp.Controls.Add(this.txt_Name);
            this.MenualattendenceGrp.Controls.Add(this.id_txt);
            this.MenualattendenceGrp.Controls.Add(this.label7);
            this.MenualattendenceGrp.Controls.Add(this.label6);
            this.MenualattendenceGrp.Controls.Add(this.label5);
            this.MenualattendenceGrp.Controls.Add(this.label4);
            this.MenualattendenceGrp.Controls.Add(this.lblEmployeeName);
            this.MenualattendenceGrp.Controls.Add(this.lblEmployeeId);
            this.MenualattendenceGrp.Controls.Add(this.lbldate);
            this.MenualattendenceGrp.Location = new System.Drawing.Point(12, 10);
            this.MenualattendenceGrp.Name = "MenualattendenceGrp";
            this.MenualattendenceGrp.Size = new System.Drawing.Size(504, 360);
            this.MenualattendenceGrp.TabIndex = 5;
            this.MenualattendenceGrp.TabStop = false;
            this.MenualattendenceGrp.Text = "Menual Attendence Entry";
            // 
            // ManualAttendenceUserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MenualattendenceGrp);
            this.Name = "ManualAttendenceUserControl1";
            this.Size = new System.Drawing.Size(1118, 574);
            this.Load += new System.EventHandler(this.ManualAttendenceUserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.MenualattendenceGrp.ResumeLayout(false);
            this.MenualattendenceGrp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker OverTimeIN;
        private System.Windows.Forms.CheckBox chkTimeout;
        private System.Windows.Forms.DateTimePicker timeOUT;
        private System.Windows.Forms.DateTimePicker timeIN;
        private System.Windows.Forms.Button btngetInfo;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker todayDate;
        private System.Windows.Forms.ComboBox StatusBox;
        private System.Windows.Forms.TextBox txt_WorkingHours;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox id_txt;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.TextBox txtEmpNAmeOverTime;
        private System.Windows.Forms.TextBox txtempIDOvertime;
        private System.Windows.Forms.Label lblEndOvertime;
        private System.Windows.Forms.Label lblStartOverTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUdateOvertime;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.DateTimePicker txtdatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOvergetInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker OverTimeOut;
        private System.Windows.Forms.Label lblEmployeIDovertime;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.GroupBox MenualattendenceGrp;
    }
}
