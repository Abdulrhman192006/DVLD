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

namespace DVLD_Project.Applications.Replace_License
{
    public partial class frmReplaceLicense : Form
    {

        clsLicenses _Licenses;
        int _LicenseID;

        public frmReplaceLicense()
        {
            InitializeComponent();
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

            if (!_Licenses.IsActive)
            {
                MessageBox.Show($"Selected License Is Not Active , Please Select An Active License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbOldLicenseID.Text = _Licenses.LicenseID.ToString();
            lbMadeByUser.Text = clsCurrentUser.User.UserName.ToString();
            lbApplicationDate.Text = DateTime.Now.ToString();


            btnReplace.Enabled = true;

        }


        private void _ChangeLicensesButtonColor(string License)
        {
            switch (License)
            {
                case "Damaged":
                    btnDamagedLicense.FillColor = Color.FromArgb(255, 193, 7);
                    btnDamagedLicense.ForeColor = Color.White;
                    btnDamagedLicense.BorderColor = Color.FromArgb(255, 193, 7);
                    btnLostLicense.FillColor = Color.White;
                    btnLostLicense.ForeColor = Color.FromArgb(33, 37, 57);
                    btnLostLicense.BorderColor = Color.FromArgb(217, 222, 229);
                    btnDamagedLicense.DisabledState.FillColor = Color.FromArgb(255, 193, 7);
                    btnDamagedLicense.DisabledState.ForeColor = Color.White;
                    btnDamagedLicense.DisabledState.BorderColor = Color.FromArgb(255, 193, 7);
                    break;

                case "Lost":
                    btnLostLicense.FillColor = Color.FromArgb(255, 193, 7);
                    btnLostLicense.ForeColor = Color.White;
                    btnLostLicense.BorderColor = Color.FromArgb(255, 193, 7);
                    btnDamagedLicense.FillColor = Color.White;
                    btnDamagedLicense.ForeColor = Color.FromArgb(33, 37, 57);
                    btnDamagedLicense.BorderColor = Color.FromArgb(217, 222, 229);
                    btnLostLicense.DisabledState.FillColor = Color.FromArgb(255, 193, 7);
                    btnLostLicense.DisabledState.ForeColor = Color.White;
                    btnLostLicense.DisabledState.BorderColor = Color.FromArgb(255, 193, 7);
                    break;

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDamagedLicense_Click(object sender, EventArgs e)
        {
            SelectDamagedLicense();
        }

        private void btnLostLicense_Click(object sender, EventArgs e)
        {
            _ChangeLicensesButtonColor(btnLostLicense.Tag.ToString());

            lbReplcaeReason.Text = "Replacement For Lost License";

            decimal Fees = -1;
            if (clsApplicationTypes.GetApplicationTypeFees((byte)clsApplications.enApplicationType.ReplaceLostDrivingLicense, ref Fees))
            {
                lbApplicationFees.Text = Fees.ToString();

            }

        }

        private void btnShowLicenseHistory_Click_1(object sender, EventArgs e)
        {
            frmLicensesHistory frmLicensesHistory = new frmLicensesHistory(_Licenses.Driver.PersonID);
            frmLicensesHistory.ShowDialog();
        }

        private void btnShowNewLicenseInfo_Click_1(object sender, EventArgs e)
        {
            frmDriversInfo frmDrivers = new frmDriversInfo(_LicenseID);
            frmDrivers.ShowDialog();
        }


        private clsLicenses.IssueReasons _GetIssueReason()
        {

            if (btnDamagedLicense.Checked)
            {
                return clsLicenses.IssueReasons.ReplacementForDamaged;
            }

            else
            {
                return clsLicenses.IssueReasons.ReplacmentForLost;
            }
        }
        private void btnReplace_Click(object sender, EventArgs e)
        {
            clsLicenses ReplacedLicense = null;

            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            ReplacedLicense = _Licenses.Replace(_GetIssueReason(), clsCurrentUser.User.UserID);



            if (ReplacedLicense != null)

            {
                MessageBox.Show($"Replace License Succeeded , The New License ID Is {ReplacedLicense.LicenseID}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbReplacedLicenseID.Text = ReplacedLicense.LicenseID.ToString();
                lbReplaceApplicationID.Text = ReplacedLicense.ApplicationID.ToString();


                btnOpenNewDrivingLicensApp.Enabled = true;
                return;

            }
            else
            {
                MessageBox.Show($"Error Renew Licesens Is Not Saved ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void SelectDamagedLicense()
        {
              _ChangeLicensesButtonColor(btnDamagedLicense.Tag.ToString());

            lbReplcaeReason.Text = "Replacement For Damaged License";

            decimal Fees = -1;

            if (clsApplicationTypes.GetApplicationTypeFees(
                (byte)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense,
                ref Fees))
            {
                lbApplicationFees.Text = Fees.ToString();
            }

        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            SelectDamagedLicense();
        }
    }
}
