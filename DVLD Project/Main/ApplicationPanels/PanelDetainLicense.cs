using DVLD_Project.Application;
using DVLD_Project.Applications.DetainLicense;
using DVLD_Project.Applications.Replace_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Main.ApplicationPanels
{
    public partial class PanelDetainLicense : UserControl
    {
        public PanelDetainLicense()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();

            frmDetainLicense.Dock = DockStyle.Fill;
            frmDetainLicense.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frmDetainLicense);
            frmDetainLicense.Show();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();

            frmReleaseDetainedLicense.Dock = DockStyle.Fill;
            frmReleaseDetainedLicense.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frmReleaseDetainedLicense);
            frmReleaseDetainedLicense.Show();
        }

        private void btnManageDetainedLicenses_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frmListDetainedLicenses = new frmListDetainedLicenses();

            frmListDetainedLicenses.Dock = DockStyle.Fill;
            frmListDetainedLicenses.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frmListDetainedLicenses);
            frmListDetainedLicenses.Show();
        }
    }
}
