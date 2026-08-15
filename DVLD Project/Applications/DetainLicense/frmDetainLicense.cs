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

namespace DVLD_Project.Applications.DetainLicense
{
    public partial class frmDetainLicense : Form
    {
        clsLicenses _Licenses;
        int _LicenseID;


        public frmDetainLicense()
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

            if (_Licenses.IsDetained)
            {
                MessageBox.Show($"Selected License Is Already Detained , Please Select A Non Detained License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbLicenseID.Text = _Licenses.LicenseID.ToString();
            lbMadeByUser.Text = clsCurrentUser.User.UserName.ToString();
            lbDetainDate.Text = DateTime.Now.ToString();


            btnDetain.Enabled = true;


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

        private void btnDetain_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show($"Error Some Fileds Are Required , Please Fill Them", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int DetainedLicenseID = -1;

            if (MessageBox.Show("Are you sure you want to Detain this license ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            DetainedLicenseID = _Licenses.Detain( Convert.ToDecimal(txtFineFees.Text.Trim()) ,clsCurrentUser.User.UserID);


            if (DetainedLicenseID != -1)

            {
                MessageBox.Show($"License Is Detained Successfully , The New Detained License ID Is {DetainedLicenseID}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbDetainID.Text = DetainedLicenseID.ToString();

                btnShowLicenseInfo.Enabled = true;

                return;

            }
            else
            {
                MessageBox.Show($"Error Licesens Is Not Detained ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                errorProvider1.SetError(txtFineFees, "This Field Is Required");
                e.Cancel = true;

            }

        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
