namespace OMS_Astute
{
    partial class ContactsUserControl1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtcontact = new System.Windows.Forms.TextBox();
            this.lblSearchMobile = new System.Windows.Forms.Label();
            this.txtemp = new System.Windows.Forms.TextBox();
            this.lblSearchEmpID = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 368);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1087, 368);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtcontact);
            this.groupBox1.Controls.Add(this.lblSearchMobile);
            this.groupBox1.Controls.Add(this.txtemp);
            this.groupBox1.Controls.Add(this.lblSearchEmpID);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 189);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contact Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(152, 115);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtcontact
            // 
            this.txtcontact.Location = new System.Drawing.Point(98, 59);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Size = new System.Drawing.Size(144, 20);
            this.txtcontact.TabIndex = 8;
            // 
            // lblSearchMobile
            // 
            this.lblSearchMobile.AutoSize = true;
            this.lblSearchMobile.Location = new System.Drawing.Point(42, 62);
            this.lblSearchMobile.Name = "lblSearchMobile";
            this.lblSearchMobile.Size = new System.Drawing.Size(50, 13);
            this.lblSearchMobile.TabIndex = 7;
            this.lblSearchMobile.Text = "Contact :";
            // 
            // txtemp
            // 
            this.txtemp.Location = new System.Drawing.Point(98, 33);
            this.txtemp.Name = "txtemp";
            this.txtemp.Size = new System.Drawing.Size(144, 20);
            this.txtemp.TabIndex = 6;
            this.txtemp.TextChanged += new System.EventHandler(this.txtemp_TextChanged);
            this.txtemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtemp_KeyDown);
            // 
            // lblSearchEmpID
            // 
            this.lblSearchEmpID.AutoSize = true;
            this.lblSearchEmpID.Location = new System.Drawing.Point(19, 36);
            this.lblSearchEmpID.Name = "lblSearchEmpID";
            this.lblSearchEmpID.Size = new System.Drawing.Size(73, 13);
            this.lblSearchEmpID.TabIndex = 5;
            this.lblSearchEmpID.Text = "Employee ID :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name :";
            // 
            // ContactsUserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ContactsUserControl1";
            this.Size = new System.Drawing.Size(1087, 575);
            this.Load += new System.EventHandler(this.ContactsUserControl1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtcontact;
        private System.Windows.Forms.Label lblSearchMobile;
        private System.Windows.Forms.TextBox txtemp;
        private System.Windows.Forms.Label lblSearchEmpID;
    }
}
