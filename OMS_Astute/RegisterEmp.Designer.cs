namespace OMS_Astute
{
    partial class RegisterEmp
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registerEmpUserControl11 = new OMS_Astute.RegisterEmpUserControl1();
            this.SuspendLayout();
            // 
            // registerEmpUserControl11
            // 
            this.registerEmpUserControl11.BackColor = System.Drawing.Color.White;
            this.registerEmpUserControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerEmpUserControl11.Location = new System.Drawing.Point(0, 0);
            this.registerEmpUserControl11.Name = "registerEmpUserControl11";
            this.registerEmpUserControl11.Size = new System.Drawing.Size(1197, 663);
            this.registerEmpUserControl11.TabIndex = 0;
            // 
            // RegisterEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 663);
            this.Controls.Add(this.registerEmpUserControl11);
            this.Name = "RegisterEmp";
            this.Text = "RegisterEmp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterEmp_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private RegisterEmpUserControl1 registerEmpUserControl11;
    }
}