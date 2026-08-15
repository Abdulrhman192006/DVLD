using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Renew_License
{
    public partial class frmRenewLicense : Form
    {
        public frmRenewLicense()
        {
            InitializeComponent();

            //subcribe to the event 
            cntrlFindDriverInfo1.OnLicenseselected += LoadRenewLicenseInfo_OnLicenseSelected;
        }

        clsLicenses _Licenses;
        int _LicenseID;

        private void LoadRenewLicenseInfo_OnLicenseSelected(int LicenseID)
        {
            _LicenseID = LicenseID;
            _Licenses = cntrlFindDriverInfo1.LicenseInfo;

            btnShowLicenseHistory.Enabled =  _LicenseID != -1;

            if (_Licenses == null)
            {
                return;
            }

            if (DateTime.Compare(DateTime.Now, _Licenses.ExpirationDate) <= 0)
            {
                MessageBox.Show($"Cannot Renew Licesens Becuase It Will Expire On {_Licenses.ExpirationDate} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_Licenses.IsActive)
            {
                MessageBox.Show($"Selected License Is Not Active , Please Select An Active License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbOldLicenseID.Text = _Licenses.LicenseID.ToString();
            lbMadeByUser.Text = clsCurrentUser.User.UserName.ToString();
            lbApplicationDate.Text = DateTime.Now.ToString();

            decimal fees = 0;
            if (clsApplicationTypes.GetApplicationTypeFees((int)clsApplications.enApplicationType.RenewDrivingLicense, ref fees))
            {
                lbApplicationFees.Text = fees.ToString();
            }

            lbNewLicenseFees.Text = _Licenses.PaidFees.ToString();
            lbIssueDate.Text = DateTime.Now.ToString();
            lbExpirationDate.Text = DateTime.Now.AddYears(_Licenses.LicenseClassInfo.DefaultValidityLength).ToString();
            lbTotalFees.Text = (_Licenses.PaidFees + fees).ToString();

            

            btnRenew.Enabled = true;

        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsLicenses RenewedLicense = _Licenses.RenewLicense(txtNotes.Text.Trim(), clsCurrentUser.User.UserID);

            if (RenewedLicense != null)
            {
                MessageBox.Show($"Renew License Succeeded , The New License ID Is {RenewedLicense.LicenseID}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbRenewedLicenseID.Text = RenewedLicense.LicenseID.ToString();
                lbRenewApplicationID.Text = RenewedLicense.ApplicationID.ToString();


                btnOpenNewDrivingLicensApp.Enabled = true;
                return;

            }
            else
            {
                MessageBox.Show($"Error Renew Licesens Is Not Saved ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            frmLicensesHistory frmLicensesHistory = new frmLicensesHistory(_Licenses.Driver.PersonID);
            frmLicensesHistory.ShowDialog();
        }

        private void btnShowNewLicenseInfo_Click(object sender, EventArgs e)
        {
            frmDriversInfo frmDrivers = new frmDriversInfo(_LicenseID);
            frmDrivers.ShowDialog();
        }


    }
}
