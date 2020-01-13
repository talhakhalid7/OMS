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
    public partial class RegisterEmp : Form
    {
        public RegisterEmp()
        {
            InitializeComponent();
        }

        private void RegisterEmp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main frmmain = new Main();
            frmmain.Show();
            //this.Close();
        }
    }
}
