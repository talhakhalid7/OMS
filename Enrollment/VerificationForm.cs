using System;
using System.Collections.Generic;
using System.Text;

namespace Enrollment
{
	/* NOTE: This form is inherited from the CaptureForm,
		so the VisualStudio Form Designer may not load it properly
		(at least until you build the project).
		If you want to make changes in the form layout - do it in the base CaptureForm.
		All changes in the CaptureForm will be reflected in all derived forms 
		(i.e. in the EnrollmentForm and in the VerificationForm)
	*/
	public class VerificationForm : CaptureForm
	{

		public void Verify(DPFP.Template template)
		{
			Template = template;
			ShowDialog();
		}

		protected override void Init()
		{
			base.Init();
			base.Text = "Fingerprint Verification";
			Verificator = new DPFP.Verification.Verification();		// Create a fingerprint template verificator
			UpdateStatus(0);
		}

		protected override void Process(DPFP.Sample Sample)
		{
			base.Process(Sample);

			// Process the sample and create a feature set for the enrollment purpose.
			DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

			// Check quality of the sample and start verification if it's good
			// TODO: move to a separate task
			if (features != null)
			{
				// Compare the feature set with our template
				DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
				Verificator.Verify(features, Template, ref result);
				UpdateStatus(result.FARAchieved);
				if (result.Verified)
					MakeReport("The fingerprint was VERIFIED.");
				else
					MakeReport("The fingerprint was NOT VERIFIED.");
			}
		}

		private void UpdateStatus(int FAR)
		{
			// Show "False accept rate" value
			SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
		}

		private DPFP.Template Template;
		private DPFP.Verification.Verification Verificator;

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(581, 354);
            this.Name = "VerificationForm";
            this.Load += new System.EventHandler(this.VerificationForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {

        }

        private void VerificationForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}