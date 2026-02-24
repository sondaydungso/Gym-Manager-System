using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Manager_System.Forms
{
    public partial class FaceRegistrationForm : Form
    {
        public FaceRegistrationForm()
        {
            InitializeComponent();
        }

        private void picCamera_Click(object sender, EventArgs e)
        {
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            // TODO: capture current camera frame and complete face registration
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
        }

        private void lblMemName_Click(object sender, EventArgs e)
        {
        }
    }
}
