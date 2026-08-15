using DVLD_BuisnessLayer;
using DVLD_Project.Drivers;
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

namespace DVLD_Project.Applications.DetainLicense
{
    public partial class frmReleaseDetainedLicense : Form
    {
        clsLicenses _Licenses;
        int _LicenseID;

        clsDetainedLicenses _DetainedLicense;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();

            //if this constuctor is used then we load info with current license id

            cntrlFindDriverInfo1.LoadLicenseInfo(LicenseID);
            cntrlFindDriverInfo1.Enabled = false;
        }

        private void cntrlFindDriverInfo1_OnLicenseselected(int obj)
        {
            _LicenseID = obj;

            if (_LicenseID == -1)
            {
                return;
            }
            _Licenses = cntrlFindDriverInfo1.LicenseInfo;

            btnShowLicenseHistory.Enabled = _LicenseID != -1;

            if (_Licenses == null)
            {
                return;
            }


            if (!_Licenses.IsDetained)
            {
                MessageBox.Show($"Selected License Is Not Detained , Please Select A Detained License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _DetainedLicense = clsDetainedLicenses.FindDetainedLicenseByLicenseID(_LicenseID);

            if (_DetainedLicense == null)
            {
                MessageBox.Show($"Error : Detained License Info Could Not Load", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbLicenseID.Text = _Licenses.LicenseID.ToString();
            lbDetainID.Text = _DetainedLicense.DetainID.ToString();
            lbDetainDate.Text = _DetainedLicense.DetainDate.ToString();
            lbFineFees.Text = _DetainedLicense.FineFees.ToString();

            decimal fees = 0;
            if(clsApplicationTypes.GetApplicationTypeFees((byte)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense, ref fees))
            {
                lbReleaseApplicationFees.Text = fees.ToString();
            }
            
            lbTotalFees.Text = (fees + _DetainedLicense.FineFees).ToString();
            lbMadeByUser.Text = _DetainedLicense.CreatedByUserID.ToString();


            btnRelease.Enabled = true;

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {


            int ReleaseApplicationID = -1;

            if (MessageBox.Show("Are you sure you want to Release this license ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            ReleaseApplicationID = _Licenses.Release(clsCurrentUser.User.UserID, _DetainedLicense.DetainID);


            if (ReleaseApplicationID != -1)

            {
                MessageBox.Show($"License Is Released Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbReleaseApplicationID.Text = ReleaseApplicationID.ToString();

                btnShowLicenseInfo.Enabled = true;

                return;

            }
            else
            {
                MessageBox.Show($"Error Licesens Is Not Released ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            frmLicensesHistory frmLicensesHistory = new frmLicensesHistory(_Licenses.Driver.PersonID);
            frmLicensesHistory.ShowDialog();
        }

        private void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {
            frmDriversInfo frmDrivers = new frmDriversInfo(_LicenseID);
            frmDrivers.ShowDialog();
        }
    }
}
