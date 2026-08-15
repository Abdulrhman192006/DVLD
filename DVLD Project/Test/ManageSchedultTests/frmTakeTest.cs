using DVLD_Project.Golbal_Functions;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clsTestTypes;

namespace DVLD_Project.Test.ManageSchedultTests
{
    public partial class frmTakeTest : Form
    {

        clsTestAppointments _TestAppointment;
        clsTests _Test;
        int _TestAppointmentID;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
        }


        private void _ChangePictureScheduleTest()
        {
            switch ((TestType)_TestAppointment.TestTypeID)
            {
                case TestType.VisionTest:
                    pbScheduleeTest.Image = Resources.zoom;
                    break;
                case TestType.WrittenTest:
                    pbScheduleeTest.Image = Resources.script_editor__1_;
                    break;
                case TestType.PracticalTest:
                    pbScheduleeTest.Image = Resources.steering_wheel_car;
                    break;
            }
        }


        private void _RefereshValues()
        {
            _ChangePictureScheduleTest();

            lbDrivingLicenseAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lbLicenseClassName.Text = _TestAppointment.LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lbApplicantName.Text = _TestAppointment.LocalDrivingLicenseApplication.PersonInfo.FullName;
            lbTestFees.Text = _TestAppointment.PaidFees.ToString();
            lbTestTrials.Text = clsTestAppointments.GetTestTrials(_TestAppointment.TestTypeID, _TestAppointment.LocalDrivingLicenseApplicationID).ToString();
            dtpTestDate.Value = _TestAppointment.AppointmentDate;
        }

        private void HandleLockedTestForm()
        {
            txtTestNotes.Text = _Test.Notes == string.Empty ? "" : _Test.Notes;
            lbTestID.Text = _Test.TestID.ToString();
            lbCannotChange.Visible = true;
            rbPass.Enabled = false;
            rbFail.Enabled = false;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {

            _TestAppointment = clsTestAppointments.FindTestAppointmetByID(_TestAppointmentID);

            if (_TestAppointment == null) 
            {
                MessageBox.Show("Error : Not Test Appointment Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            lbTestTypeHeader.Text = _TestAppointment.TestTypes.TestTypeTitle;
            _RefereshValues();

            if (_TestAppointment.IsLocked) //If applicant sat for the test then we cannot change the test result
            {
                _Test = clsTests.FindTestByTestAppointmentID(_TestAppointmentID);
                HandleLockedTestForm();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (_TestAppointment.IsLocked) // if the test is taken then we do not make a new test object
            {
               if(clsTests.UpdateNotes(txtTestNotes.Text, _TestAppointmentID))
               {
                    MessageBox.Show("Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
               }
                else
                {
                    MessageBox.Show("Error : Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();

                }
                return;
            }

            clsTests Test = new clsTests();

            Test.Notes = txtTestNotes.Text;
            Test.TestResult = rbPass.Checked;
            Test.CreatedByUserID = clsCurrentUser.User.UserID;
            Test.TestAppointmentID = _TestAppointmentID;

            if (Test.Save())
            {
                if (clsTestAppointments.LockTestAppointmet(_TestAppointmentID))
                {
                    MessageBox.Show("Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Error : Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
