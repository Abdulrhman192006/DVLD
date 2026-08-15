using DVLD_BuisnessLayer;
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
    public partial class frmAddUpdateScheduleTest : Form
    {

        int _LocalDrivinglicenseID;

        int _TestAppointmentID;
        clsTestTypes.TestType _TestTypeID;


        public frmAddUpdateScheduleTest(int LocalDrivingLicenseApplication ,  int TespTypeID, int AppointemtnID = -1)
        {

            InitializeComponent();

            _LocalDrivinglicenseID = LocalDrivingLicenseApplication;
            _TestAppointmentID = AppointemtnID;
            _TestTypeID = (clsTestTypes.TestType)TespTypeID;

        }



        private void frmAddUpdateScheduleTest_Load(object sender, EventArgs e)
        {
            cntrlShceduleTest1.TestTypeID = _TestTypeID;

            
          cntrlShceduleTest1.LoadShceduleTestInfo(_LocalDrivinglicenseID,_TestAppointmentID);

            
        }

    }
}
