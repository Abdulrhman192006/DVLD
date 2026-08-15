using DVLD_BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Drivers
{
    public partial class cntrlDriverInfo : UserControl
    {
        clsLicenses _License;
        int _LicenseID;

        public clsLicenses License
        {
            get
            {
                return _License;
            }
        }



        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }
        public cntrlDriverInfo()
        {
            InitializeComponent();
        }

        private void _LoadInfo()
        {

            lbLicenseClassName.Text = _License.LicenseClassInfo.ClassName;
            lbApplicantName.Text = _License.Driver.PersonInfo.FullName;
            lbLicenseID.Text = _License.LicenseID.ToString();
            lbNationalNo.Text = _License.Driver.PersonInfo.NationalNumber.ToString();
            lbIssueDate.Text = _License.IssueDate.ToString();
            lbIssueReason.Text = _License.IssueReasonString;
            tsActive.Checked = _License.IsActive;
            tsIsDetained.Checked = _License.IsDetained;
            btnGender.Text = _License.Driver.PersonInfo.Gender == clsPeople.enGender.Male ? "Male" : "Female";
            btnGender.Checked = true;
            lbDriverID.Text = _License.DriverID.ToString();
            lbExpirationDate.Text = _License.ExpirationDate.ToString();
            lbDateOfBirth.Text = _License.Driver.PersonInfo.DateOfBirth.ToString();
            txtNotes.Text = _License.Notes;

            if (!string.IsNullOrEmpty(_License.Driver.PersonInfo.ImagePath))
            {
                if (File.Exists(_License.Driver.PersonInfo.ImagePath))
                {
                    pbPersonPhoto.ImageLocation = _License.Driver.PersonInfo.ImagePath;

                }
                else
                    MessageBox.Show("Error : Person Image Was Not Loaded","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void LoadLicenseInfo(int LicenseID )
        {
            _LicenseID = LicenseID;
            _License = clsLicenses.FindLicenseByID( LicenseID );

            if (_License == null) 
            {
                MessageBox.Show("License was not found!" , "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            _LoadInfo();
        }

        public void LoadLicenseInfoByApplcaitonID(int ApplicationID)
        {
            _License = clsLicenses.FindLicenseByApplicationID(ApplicationID);

            if (_License == null)
            {
                MessageBox.Show("License was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            _LoadInfo();
        }
    }
}
