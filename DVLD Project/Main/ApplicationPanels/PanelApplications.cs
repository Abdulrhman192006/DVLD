using DVLD_Project.Application;
using DVLD_Project.Applications.Renew_License;
using DVLD_Project.Applications.Replace_License;
using DVLD_Project.Licenses;
using DVLD_Project.Test;
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
    public partial class PanelApplications : UserControl
    {
        public PanelApplications()
        {
            InitializeComponent();
        }

        private void btnOpenNewDrivingLicensApp_Click(object sender, EventArgs e)
        {

            PanelLocalDrivingApplications panellocal = new PanelLocalDrivingApplications();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(panellocal);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes applicationTypes = new frmListApplicationTypes();
            applicationTypes.TopLevel = false;
            applicationTypes.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(applicationTypes);

            applicationTypes.Show();
        }

        private void btnTestTypes_Click(object sender, EventArgs e)
        {
            frmListTestTypes TestTypes = new frmListTestTypes();
            TestTypes.TopLevel = false;
            TestTypes.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(TestTypes);

            TestTypes.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseForFirstTime IssueLicense = new frmIssueDriverLicenseForFirstTime();
            IssueLicense.TopLevel = false;
            IssueLicense.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(IssueLicense);

            IssueLicense.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmRenewLicense renewLicense = new frmRenewLicense();
            renewLicense.TopLevel = false;
            renewLicense.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(renewLicense);

            renewLicense.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            frmReplaceLicense frmReplaceLicense = new frmReplaceLicense();
            frmReplaceLicense.TopLevel = false;
            frmReplaceLicense.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frmReplaceLicense);

            frmReplaceLicense.Show();
        }
    }
}
