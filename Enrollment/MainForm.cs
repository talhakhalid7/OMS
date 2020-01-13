using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Enrollment
{
	delegate void Function();	// a simple delegate for marshalling calls from event handlers to the GUI thread

	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
        public string path = "";
        public void CloseButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		public void EnrollButton_Click(object sender, EventArgs e)
		{
			EnrollmentForm Enroller = new EnrollmentForm();
			Enroller.OnTemplate += this.OnTemplate;
			Enroller.ShowDialog();
		}

        public void VerifyButton_Click(object sender, EventArgs e)
		{
			VerificationForm Verifier = new VerificationForm();
			Verifier.Verify(Template);
		}

        public void SaveButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "Fingerprint Template File (*.fpt)|*.fpt";
			if (save.ShowDialog() == DialogResult.OK) {
				using (FileStream fs = File.Open(save.FileName, FileMode.Create, FileAccess.Write)) {
					Template.Serialize(fs);
                    path = save.FileName;
                    

                }
			}
		}

        public void LoadButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "Fingerprint Template File (*.fpt)|*.fpt";
			if (open.ShowDialog() == DialogResult.OK) {
				using (FileStream fs = File.OpenRead(open.FileName)) {
					DPFP.Template template = new DPFP.Template(fs);
					OnTemplate(template);
				}
			}
		}

        public void OnTemplate(DPFP.Template template)
		{
			this.Invoke(new Function(delegate()
			{
				Template = template;
				VerifyButton.Enabled = SaveButton.Enabled = (Template != null);
				if (Template != null)
					MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
				else
					MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
			}));
		}

        public DPFP.Template Template;

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}