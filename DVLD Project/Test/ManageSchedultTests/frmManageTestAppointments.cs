using DVLD_BuisnessLayer;
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
    public partial class frmManageTestAppointments : Form
    {
        DataTable dtTestAppointment;


        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID;

        int _TestTypeID;


        public delegate void DataBackEventHandler(object sender, int AppointmentID);
        public event DataBackEventHandler OnAppointment;

        public frmManageTestAppointments(int LocalID,int TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalID;
            _TestTypeID = TestTypeID;

        }

        private void _LoadDataGridView()
        {
            dtTestAppointment = clsTestAppointments.GetTestAppointmentsByTestTypeID(
                _LocalDrivingLicenseApplicationID,(clsTestTypes.TestType)_TestTypeID);

            dtTestAppointment = dtTestAppointment.DefaultView.ToTable(false, "TestAppointmentID", "AppointmentDate",
                                                       "PaidFees", "IsLocked");

            dgvTestAppointments.DataSource = dtTestAppointment;

            dgvTestAppointments.EnableHeadersVisualStyles = false;

            dgvTestAppointments.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvTestAppointments.ColumnHeadersDefaultCellStyle.BackColor;

            dgvTestAppointments.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvTestAppointments.ColumnHeadersDefaultCellStyle.ForeColor;

            if (dgvTestAppointments.Rows.Count > 0)
            {
                dgvTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvTestAppointments.Columns[3].HeaderText = "Is Locked";
            }
        }


        private void _RefershApplicationInfo()
        {
            cntrlDivingLicneseApplicationInfo1.LoadDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
            lbTestTypeHeader.Text =  ((clsTestTypes.TestType)_TestTypeID).ToString();

        }
        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadDataGridView();


            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error : Application is not found");
                return;
            }

            _RefershApplicationInfo();
        }

        private void btnScheduleAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointments.IsApplicantHaveAnActiveTestAppoinment(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                MessageBox.Show("Applicant already have an active test appointment, retake test only if failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
           if( clsTestAppointments.IsApplicantHavePassedTestByTestTypeID(_LocalDrivingLicenseApplicationID, (clsTestTypes.TestType)_TestTypeID))
            {
                MessageBox.Show("Applicant already passed the test , retake test only if failed","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            frmAddUpdateScheduleTest Appointments = new frmAddUpdateScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);

            Appointments.ShowDialog();
            _LoadDataGridView();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvTestAppointments.Rows.Count != 0)
            {

                frmTakeTest Test = new frmTakeTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value);
                Test.ShowDialog();
                _LoadDataGridView();
                _RefershApplicationInfo();
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int TestAppointment = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;

            frmAddUpdateScheduleTest Appointments = new frmAddUpdateScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, TestAppointment);
            Appointments.ShowDialog();
            _LoadDataGridView();
        }
    }
}
