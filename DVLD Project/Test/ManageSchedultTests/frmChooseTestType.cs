using DVLD_BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Test.ManageSchedultTests
{
    public partial class frmChooseTestType : Form
    {
        int _LocalDrivingLicenseApplicaitonID;
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        byte _PassedTest ;

        clsTestAppointments _TestAppointment;

        public frmChooseTestType(int LocalDrivingLicenseApplication)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicaitonID = LocalDrivingLicenseApplication;
        }

        private void _SetVisionTestValues()
        {
            pnVision.FillColor = Color.FromArgb(255, 193, 7);
            pnVision.Enabled = false;
            pnWritten.Enabled = true;

            lbVisionStatus.Visible = true;
            lbVisionStatus.Text = "Completed";

            lbWrittenStatus.Visible = false;
        }
        private void _SetWrittenTestValues()
        {
            pnWritten.FillColor = Color.FromArgb(255, 193, 7);
            pnWritten.Enabled = false;
            pnPractical.Enabled = true;

            lbWrittenStatus.Visible = true;
            lbWrittenStatus.Text = "Completed";

            lbPracticalStatus.Visible = false;

        }
        private void _SetPracitcalTestValues()
        {
            pnPractical.FillColor = Color.FromArgb(255, 193, 7);
            pnVision.Enabled = false;
            pnWritten.Enabled = false;
            pnPractical.Enabled = false;

            lbPracticalStatus.Visible = true;
            lbPracticalStatus.Text = "Completed";

        }
        private void _EditTestsTypesValues()
        {
            
            
           //if passed test is 1 then applicant have passed vision test
            if(_PassedTest >= 1)
                 _SetVisionTestValues();

            //if passed test is 2 then applicant have passed Written test
            if (_PassedTest >= 2)
                _SetWrittenTestValues();

            //if passed test is 3 then applicant have passed practical test
            if (_PassedTest >= 3)
                _SetPracitcalTestValues();


            
        }
        private void _LoadManageTestsInfo()
        {
            _PassedTest = clsTests.GetPassedTests(_LocalDrivingLicenseApplicaitonID);
            lbDrivingLicenseAppID.Text = _LocalDrivingLicenseApplicaitonID.ToString();
            lbLicenseClassName.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lbPassedTests.Text = $"{_PassedTest}/3";


            _EditTestsTypesValues();
        }
        private void frmManageScheduleTests_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseApplicaitonID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: Local Driving License Application Is Not Found! , this form will be closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            _LoadManageTestsInfo();
        }

        private void btnVisionAppointments_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments ManageTestAppointments = new frmManageTestAppointments(
                _LocalDrivingLicenseApplicaitonID,(int)clsTestTypes.TestType.VisionTest);

            ManageTestAppointments.ShowDialog();
            _LoadManageTestsInfo();
        }

        private void btnWrittenAppointment_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments ManageTestAppointments = new frmManageTestAppointments(
    _LocalDrivingLicenseApplicaitonID, (int)clsTestTypes.TestType.WrittenTest);

            ManageTestAppointments.ShowDialog();
            _LoadManageTestsInfo();
        }

        private void btnStreetAppointment_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments ManageTestAppointments = new frmManageTestAppointments(
    _LocalDrivingLicenseApplicaitonID, (int)clsTestTypes.TestType.PracticalTest);

            ManageTestAppointments.ShowDialog();
            _LoadManageTestsInfo();
        }
    }
}
