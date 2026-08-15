using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Licenses;
using GumroadLicensing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.InternationalLicense
{
    public partial class frmIssueInternationalLicense : Form
    {
        clsLicenses _Licenses;
        int _LicenseID;

        clsInternationalLicenses _InternationalLicense;
        public frmIssueInternationalLicense()
        {
            InitializeComponent();
        }



        private void btnShowNewLicenseInfo_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo internationalLicenseInfo = new frmInternationalLicenseInfo(_InternationalLicense.InternationalLicenseID);
            internationalLicenseInfo.ShowDialog();
        }

        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            frmLicensesHistory LicenseHistory = new frmLicensesHistory(_Licenses.Driver.PersonID);
            LicenseHistory.ShowDialog();
        }

        private void cntrlFindDriverInfo1_OnLicenseselected(int obj)
        {
            _LicenseID = obj;
            _Licenses = cntrlFindDriverInfo1.LicenseInfo;

            btnShowLicenseHistory.Enabled = _LicenseID != -1;

            if (_Licenses == null)
            {
                return;
            }

            if (_Licenses.LicenseClassID != 3)//class 3 : normal vehcile
            {
                MessageBox.Show($"Cannot Issue International Licesens Becuase the local license is not class 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Compare(_Licenses.ExpirationDate, DateTime.Now
                ) <= 0)
            {
                MessageBox.Show($"Cannot Issue International Licesens Becuase the local license is expired,please renew it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Licenses.IsDetained)
            {
                MessageBox.Show($"Selected License Is Detained, Please Select A Released License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_Licenses.IsActive)
            {
                MessageBox.Show($"Selected License Is Not Active , Please Select An Active License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (clsInternationalLicenses.IsInternationalLicenseExistByLicenseID(_LicenseID))
            {
                MessageBox.Show($"Applicant Has Already An Active International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbLocalLicenseID.Text = _Licenses.LicenseID.ToString();
            lbMadeByUser.Text = clsCurrentUser.User.UserName.ToString();
            lbApplicationDate.Text = DateTime.Now.ToString();

            decimal fees = 0;
            if (clsApplicationTypes.GetApplicationTypeFees((int)clsApplications.enApplicationType.NewInternationalLicense, ref fees))
            {
                lbApplicationFees.Text = fees.ToString();
            }

            lbIssueDate.Text = DateTime.Now.ToString();
            lbExpirationDate.Text = DateTime.Now.AddYears(1).ToString();

            btnIssueLicense.Enabled = true;
        }

        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            _InternationalLicense = _Licenses.IssueInternationalLicense(clsCurrentUser.User.UserID);

            if (_InternationalLicense != null) 
            {
                MessageBox.Show($"International License Is Issued With ID {_InternationalLicense.InternationalLicenseID}", "Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lbInternationalApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                lbInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();

                btnShowNewLicenseInfo.Enabled = true;
                return;

            }
            else
            {
                MessageBox.Show($"Error: International License Was Not Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
    }
}
