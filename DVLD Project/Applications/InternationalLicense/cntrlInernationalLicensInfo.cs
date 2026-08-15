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

namespace DVLD_Project.Applications.InternationalLicense
{
    public partial class cntrlInernationalLicensInfo : UserControl
    {
        public cntrlInernationalLicensInfo()
        {
            InitializeComponent();
        }


        clsInternationalLicenses _InternationalLicense;
        int _InternationlLicenseID;

        public clsInternationalLicenses InternationalLicense
        {
            get
            {
                return _InternationalLicense;
            }
        }


        public int InternationalLicenseID
        {
            get
            {
                return _InternationlLicenseID;
            }
        }

        private void _LoadInfo()
        {

            lbApplicantName.Text = _InternationalLicense.Driver.PersonInfo.FullName;
            lbInternationalLicenseID.Text =_InternationlLicenseID.ToString();
            lbNationalNo.Text = _InternationalLicense.Driver.PersonInfo.NationalNumber.ToString();
            lbIssueDate.Text = _InternationalLicense.IssueDate.ToString();
            tsActive.Checked = _InternationalLicense.IsActive;
            btnGender.Text = _InternationalLicense.Driver.PersonInfo.Gender == clsPeople.enGender.Male ? "Male" : "Female";
            btnGender.Checked = true;
            lbDriverID.Text = _InternationalLicense.DriverID.ToString();
            lbExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString();
            lbDateOfBirth.Text = _InternationalLicense.Driver.PersonInfo.DateOfBirth.ToString();
            lbApplicationID.Text = _InternationalLicense.ApplicationID.ToString();

            if (!string.IsNullOrEmpty(_InternationalLicense.Driver.PersonInfo.ImagePath))
            {
                if (File.Exists(_InternationalLicense.Driver.PersonInfo.ImagePath))
                {
                    pbPersonPhoto.ImageLocation = _InternationalLicense.Driver.PersonInfo.ImagePath;

                }
                else
                    MessageBox.Show("Error : Person Image Was Not Loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationlLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicenses.FindInternationalLicenseByID(_InternationlLicenseID);

            if (_InternationalLicense == null)
            {
                MessageBox.Show("License was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationlLicenseID = -1;
                return;
            }

            _LoadInfo();
        }

        public void LoadInetnationalLicensInfoByApplcaitonID(int ApplicationID)
        {
            _InternationalLicense = clsInternationalLicenses.FindInternationalLicenseByApplicationID(ApplicationID);

            if (_InternationalLicense == null)
            {
                MessageBox.Show("License was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationlLicenseID = -1;
                return;
            }

            _LoadInfo();
        }

    }
}
