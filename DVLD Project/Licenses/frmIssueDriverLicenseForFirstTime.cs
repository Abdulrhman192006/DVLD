using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Licenses
{
    public partial class frmIssueDriverLicenseForFirstTime : Form
    {
        public frmIssueDriverLicenseForFirstTime()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication
        {
            get
            {
                return cntrlFindDrivingLicenseApplication1.LocalDrivingLicenseApplication;
            }
        }

  
        private void btnIssueLicenseFirstTime_Click(object sender, EventArgs e)
        {
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error : Application Was Not Found , Please Enter An Application ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if applicant passed all tests
            if (!clsTestAppointments.DoesApplicantPassedAllTests(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("Cannot Issue License : This Applicant Have Not Passed All Tests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if applicant was a driver and issued a license for same class before
            if (_LocalDrivingLicenseApplication.DoesApplicantHaveIssuedLicenseBefore())
            {
                MessageBox.Show("Cannot Issue License : This Applicant Have Issued License Before With Same Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //

            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForFirstTime(txtNotes.Text.Trim(), clsCurrentUser.User.UserID);
            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully", "Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cntrlFindDrivingLicenseApplication1.EnableViewLicenseInfoButton = true;
                return;

            }
            else
            {
                MessageBox.Show("Error Issue License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmIssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {


        }
    }
}
