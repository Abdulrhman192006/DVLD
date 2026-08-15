using DVLD_Project.Applications.InternationalLicense;
using DVLD_Project.Applications.LocalDrivingLisence;
using DVLD_Project.Users;
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
    public partial class PanelLocalDrivingApplications : UserControl
    {
        public PanelLocalDrivingApplications()
        {
            InitializeComponent();
        }

        private void btnLocalLicense_Click(object sender, EventArgs e)
        {

        }

        private void btnLocalLicense_Click_1(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications ListLocal = new frmListLocalDrivingLicenseApplications();
            ListLocal.Dock = DockStyle.Fill;
            ListLocal.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ListLocal);

            ListLocal.Show();
        }

        private void btnInternationalLicense_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses listInternationalLicenses = new frmListInternationalLicenses();

            listInternationalLicenses.Dock = DockStyle.Fill;
            listInternationalLicenses.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(listInternationalLicenses);

            listInternationalLicenses.Show();
        }
    }
}
