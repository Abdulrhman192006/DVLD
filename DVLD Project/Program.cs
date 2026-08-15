using DVLD_BuisnessLayer;
using DVLD_Project;
using DVLD_Project.Application;
using DVLD_Project.Applications.LocalDrivingLicense;
using DVLD_Project.Applications.Renew_License;
using DVLD_Project.Licenses;
using DVLD_Project.Main;
using DVLD_Project.People;
using DVLD_Project.Test.ManageSchedultTests;
using DVLD_Project.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new Form1());
        //Application.Run(new frmAddEdit());
        //Application.Run(new frmMainMenu());
        //Application.Run(new frm());
        //Application.Run(new frmFindPerson());
        //Application.Run(new frmManageUsers());
        // Application.Run(new frmAddEditUser());
        // Application.Run(new frmFindPerson());
        Application.Run(new frmLogin());
        //Application.Run(new frmListApplicationTypes());
        //Application.Run(new frmAddUpdateLocalDrivingLicenseApplication(36));
        //Application.Run(new frmChooseTestType(44));
        // Application.Run(new frmAddUpdateScheduleTest(86,3,clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(44)));
        // Application.Run(new frmManageTestAppointments(44,3));
      // Application.Run(new frmRenewLicense());








    }
}

