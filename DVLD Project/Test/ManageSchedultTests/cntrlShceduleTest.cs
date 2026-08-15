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

namespace DVLD_Project.Test.ManageSchedultTests
{
    public partial class cntrlShceduleTest : UserControl
    {
        public cntrlShceduleTest()
        {
            InitializeComponent();
        }
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        int _LocalDrivinglicenseID;

        clsTestAppointments _TestAppointment;
        clsApplications _RetakeTestApplication;

        int _TestAppointmentID;
        clsTestTypes.TestType _TestTypeID;

        clsTestTypes _TestTypes;

        public delegate void DataBackEventHandler(object sender, int AppointmentID);
        public event DataBackEventHandler DataBack;
        enum enMode { Add = 1, Update = 2 }
        enMode _Mode;

        enum enTestResult { Pass = 1, Fail = 2 }
        enTestResult _TestResult;


        //Store test type id to determine the type of the schedule appointment to be stored
        public clsTestTypes.TestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }

            set
            {
                _TestTypeID = value;

                lbTestTypeHeader.Text = _TestTypeID.ToString();
                switch (_TestTypeID)
                {

                    case clsTestTypes.TestType.VisionTest:
                        pbScheduleeTest.Image = Resources.zoom;
                        break;
                    case clsTestTypes.TestType.WrittenTest:
                        pbScheduleeTest.Image = Resources.script_editor__1_;
                        break;
                    case clsTestTypes.TestType.PracticalTest:
                        pbScheduleeTest.Image = Resources.steering_wheel_car;
                        break;


                }
            }
        }


        public bool _HandleActiveTestAppointment()
        {
            if (_Mode == enMode.Add && clsTestAppointments.IsApplicantHaveAnActiveTestAppoinment(_LocalDrivinglicenseID, (int)_TestTypeID))
            {
                lbSheduleTestHeader.Text = "Person Already Have An Active Appointment";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            return true;
        }

        public bool _HandleTestAppointmentLocked()
        {
            //either person passed or failed , he sat for the test then he cannot edit the appointment
            if (_TestAppointment.IsLocked)
            {
                lbSheduleTestHeader.Text = "Person Already Sat for The Test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            return true;
        }

        public bool _HandlePreviousPassedTests()
        {
            if ((_Mode == enMode.Add && !clsTestAppointments.DoesApplicantHavePassedPreviousTests(_TestTypeID, _LocalDrivinglicenseID)))
            {
                lbSheduleTestHeader.Text = "Person Must Pass Previous Test To Unlock This Test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            return true;
        }

        public void LoadShceduleTestInfo(int LocalApp, int TestAppointmentID = -1)

        {

            if (TestAppointmentID == -1)
            {
                _LocalDrivinglicenseID = LocalApp;
                _Mode = enMode.Add;
            }

            else
            {
                _LocalDrivinglicenseID = LocalApp;
                _TestAppointmentID = TestAppointmentID;
                _Mode = enMode.Update;
            }


            _RefereshValues();

            int _TestTrials =
                    clsTestAppointments.GetTestTrials((int)_TestTypeID, _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);

            lbTestTrials.Text = _TestTrials.ToString();


            //if the applicant have failed the test , we load the Retake Test Control and when saving we must add the retake test application
            if (Convert.ToInt16(_TestTrials) >= 1)
            {
                _TestResult = enTestResult.Fail;
                _LoadRetakeTestInfo();
            }
            else
            {
                _TestResult = enTestResult.Pass;
            }

            if (_Mode == enMode.Add)
            {
                _TestAppointment = new clsTestAppointments();
            }

            else
            {
                _TestAppointment = clsTestAppointments.FindTestAppointmetByID(_TestAppointmentID);
                if (_TestAppointment == null)
                {
                    MessageBox.Show("Error : Local Driving License Application Is Not Found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    return;
                }

                _LoadTestAppointmentValues();
            }

            if (!_HandleActiveTestAppointment())
                return;

            if (!_HandleTestAppointmentLocked())
                return;

            if (!_HandlePreviousPassedTests())
                return;



        }

        private void _LoadRetakeTestInfo()
        {

            //we show the retake test panel with the loaded data
            pnRetakTest.Visible = true;
            lbSheduleTestHeader.Text = "Shcedule Retake Test";

            decimal fees = 0;
            if (clsApplicationTypes.GetApplicationTypeFees((int)clsApplications.enApplicationType.RetakeTest, ref fees))
            {
                lbRetakeTestFees.Text = fees.ToString();
            }

            lbTotalFees.Text = (fees + _TestTypes.TestTypeFees).ToString();
        }

        private void _RefereshValues()

        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(_LocalDrivinglicenseID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error : Local Driving License Application Is Not Found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                return;
            }

            _TestTypes = clsTestTypes.Find(_TestTypeID);

            if (_TestTypes == null)
            {
                MessageBox.Show("Error : Test Type Is Not Found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                return;
            }

            lbTestFees.Text = _TestTypes.TestTypeFees.ToString();

            lbDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbLicenseClassName.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lbApplicantName.Text = _LocalDrivingLicenseApplication.PersonInfo.FullName;

        }

        private void _LoadTestAppointmentValues()
        {
            //we assign the value of the date with the minimum value so the applicant cannot issue an application with past date
            //if date time now is less than we assign the min date with date now
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
            {
                dtpTestDate.MinDate = DateTime.Now;
            }
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate; //if the appoined is passed then we assign the min value with the past appontment

            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            lbRetakeTestAppID.Text = _TestAppointment.RetakTestApplicationID.ToString();
        }
        private void frmAddUpdateScheduleTest_Load(object sender, EventArgs e)
        {


        }

        private bool _HandleNewRetakTestApplication()
        {
            //if the applicant have failed test and we are in add mode , then we add a new retake test appliaction
            //and link it with the test appointment
            if (_TestResult == enTestResult.Fail && _Mode == enMode.Add)
            {
                _RetakeTestApplication = new clsApplications();

                _RetakeTestApplication.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                _RetakeTestApplication.ApplicationDate = dtpTestDate.Value;
                _RetakeTestApplication.LastStatusDate = DateTime.Now;
                _RetakeTestApplication.ApplicationDate = DateTime.Now;
                _RetakeTestApplication.ApplicationStatus = clsApplications.enApplicationStatus.Completed;//completed becuase the retake test application is done when saving
                _RetakeTestApplication.ApplicationTypeID = (int)clsApplications.enApplicationType.RetakeTest;
                _RetakeTestApplication.CreatedByUserID = clsCurrentUser.User.UserID;

                decimal fees = 0;
                if (clsApplicationTypes.GetApplicationTypeFees((int)clsApplications.enApplicationType.RetakeTest, ref fees))
                {
                    _RetakeTestApplication.PaidFees = fees;
                }

                if (_RetakeTestApplication.Save())
                {
                    lbRetakeTestAppID.Text = _RetakeTestApplication.ApplicationID.ToString();
                    _TestAppointment.RetakTestApplicationID = _RetakeTestApplication.ApplicationID;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error : Retake Application Is Not Saved ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!_HandleNewRetakTestApplication())
                return;

            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.CreatedByUserID = clsCurrentUser.User.UserID;
            _TestAppointment.TestTypeID = (int)_TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

            //if applicant failed test , we calculate the fees of retake test application plus the test type fees
            _TestAppointment.PaidFees = _TestTypes.TestTypeFees;

            _TestAppointment.IsLocked = false;

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Appointment Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _TestAppointment.TestAppointmetID);

                _Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Error : Appointment Is Not Saved ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }

}

