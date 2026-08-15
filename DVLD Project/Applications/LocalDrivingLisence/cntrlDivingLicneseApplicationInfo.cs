using DVLD_BuisnessLayer;
using DVLD_Project.Licenses;
using DVLD_Project.People;
using DVLD_Project.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications
{
    public partial class cntrlDivingLicneseApplicationInfo : UserControl
    {
        public cntrlDivingLicneseApplicationInfo()
        {
            InitializeComponent();
        }

        clsLocalDrivingLicenseApplications _LDApplication;

        public clsLocalDrivingLicenseApplications LocalDrivingLicense
        {
            get
            {
               return _LDApplication;
            }
        }
        public bool EnableViewLicenseInfoButton
        {
            set
            {
                btnViewLicenseInformation.Enabled = value;
            }
        }
 
        private void btnViewLicenseInformation_Click(object sender, EventArgs e)
        {
            
                frmDriversInfo DriverInfo = new frmDriversInfo(_LDApplication);
                DriverInfo.ShowDialog();
      
        }


        private void _LoadDrivingLicenseInfo()
        {
            lbApplicationID.Text = _LDApplication.ApplicationID.ToString(); 
            lbDrivingLicenseAppID.Text =    _LDApplication.LocalDrivingLicenseApplicationID.ToString();
            lbLicenseClassName.Text = _LDApplication.LicenseClass.ClassName;
            lbApplicantName.Text = _LDApplication.PersonInfo.FullName;
            lbStatusText.Text = _LDApplication.StatusText;
            lbStatusDate.Text = _LDApplication.LastStatusDate.ToString();
            lbAppFees.Text = _LDApplication.ApplicationType.ApplicationTypeFees.ToString();
            lbApplicationType.Text = _LDApplication.ApplicationType.ApplicationTypeTitle.ToString();
            lbPassedTests.Text = $"{clsTests.GetPassedTests(_LDApplication.LocalDrivingLicenseApplicationID)}/3";
            lbMadeByUser.Text = _LDApplication.UserInfo.UserName;

            //if applicant have not issued a license , then the button for license info will be disabled
            btnViewLicenseInformation.Enabled = clsLicenses.IsLicenseExistByApplicationID(_LDApplication.ApplicationID);

        }

        private void btnViewPersonInfo_Click(object sender, EventArgs e)
        {
            frmPersonCard personcard = new frmPersonCard(_LDApplication.ApplicantPersonID);
            personcard.ShowDialog();

            if (personcard._IsPersonCardDataChanged)
            {
                _LDApplication.RefereshPerson(); //referesh person if the edit form inside the person card is changed
            }

            _LoadDrivingLicenseInfo();
            
        }

        public void LoadDrivingLicenseApplicationInfo(int LDid) 
        {

            _LDApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(LDid);

            if(_LDApplication == null)
            {
                MessageBox.Show("Application Is Not Found" , "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDrivingLicenseInfo();
        }

        public void LoadDrivingLicenseApplicationInfoByAppID(int ApplicationID)
        {

            _LDApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByApplicationID(ApplicationID);

            if (_LDApplication == null)
            {
                MessageBox.Show("Application Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDrivingLicenseInfo();
        }
    }
}
