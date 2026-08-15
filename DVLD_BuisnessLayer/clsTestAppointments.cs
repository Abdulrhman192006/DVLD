using DVLD_BuisnessLayer;
using DVLD_DataAccess;
using System;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using static clsTestAppointments;
using static clsTests;
using static clsTestTypes;
using static System.Net.Mime.MediaTypeNames;


public class clsTestAppointments
{
    public int TestAppointmetID { get; set; }
    public int LocalDrivingLicenseApplicationID { get; set; }
    public int TestTypeID { get; set; }
    public string TestTypeText
    {
        get
        {
            switch ((TestType)TestTypeID)
            {
                case TestType.VisionTest:
                    return "Vision";
                case TestType.WrittenTest:
                    return "Written";
                case TestType.PracticalTest:
                    return "Practical";

                default:
                    return "UNKOWN";
                    
            }
        }
    }

    public DateTime AppointmentDate { get; set; }
    public decimal PaidFees { get; set; }
    public bool IsLocked { get; set; }
    public int RetakTestApplicationID { get; set; }
    public int CreatedByUserID { get; set; }


    private clsTestTypes _TestTypes;
    public void RefereshTestType() //use this method in case the Test Tyoe has been edited and we want the object to be refershed becuase of the lazy loading
    {
        _TestTypes = null;
    }
    public clsTestTypes TestTypes
    {
        get
        {
            if (_TestTypes == null)
                _TestTypes = clsTestTypes.Find((clsTestTypes.TestType)TestTypeID);

            return _TestTypes;
        }
    }


    private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
    public void RefereshLocalDrivingLicenseApplications() //use this method in case the Local License Application has been edited and we want the object to be refershed becuase of the lazy loading
    {
        _LocalDrivingLicenseApplication = null;
    }
    public clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication
    {
        get
        {
            if (_LocalDrivingLicenseApplication == null)
                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);

            return _LocalDrivingLicenseApplication;
        }
    }


    private clsUsers _User;
    public void RefereshUser() //use this method in case the Test Tyoe has been edited and we want the object to be refershed becuase of the lazy loading
    {
        _User = null;
    }
    public clsUsers User
    {
        get
        {
            if (_User == null)
                _User = clsUsers.FindUserByID(CreatedByUserID);

            return _User;
        }
    }

    private enum enMode : byte { AddNew = 0, Update = 1 }
    enMode Mode;

    public clsTestAppointments()
    {
        TestAppointmetID = -1;
        LocalDrivingLicenseApplicationID = -1;
        TestTypeID = -1;
        AppointmentDate = DateTime.Now;
        PaidFees = 0;
        IsLocked = false;
        RetakTestApplicationID = -1;
        CreatedByUserID = -1;
        Mode = enMode.AddNew;

    }

    protected clsTestAppointments(int testAppointmetID, int localDrivingLicenseApplicationID, int testTypeID, DateTime appointmentDate, 
        decimal paidFees, bool isLocked, int retakTestApplicationID, int createdByUserID)
    {
        TestAppointmetID = testAppointmetID;
        LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        TestTypeID = testTypeID;
        AppointmentDate = appointmentDate;
        PaidFees = paidFees;
        IsLocked = isLocked;
        RetakTestApplicationID = retakTestApplicationID;
        CreatedByUserID = createdByUserID;
        Mode = enMode.Update;
    }

    public static clsTestAppointments FindTestAppointmetByID(int TestAppointmetID)
    {
        int localDrivingLicenseApplicationID = -1;
        int testTypeID = -1;
        DateTime appointmentDate = DateTime.Now; //this will be converted to enum when making a new object
        decimal paidFees = 0;
        bool isLocked = false;
        int retakTestApplicationID = -1;
        int createdByUserID = -1;

        if (clsTestAppointmentsDataLayer.GetTestAppointmentByID(TestAppointmetID, ref testTypeID, ref localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees,
      ref retakTestApplicationID, ref createdByUserID, ref isLocked))

            return new clsTestAppointments(TestAppointmetID,   localDrivingLicenseApplicationID,   testTypeID,   appointmentDate,   paidFees,
         isLocked, retakTestApplicationID, createdByUserID);
        else
            return null;


    }

    public static DataTable GetAllTestAppointments()
    {
        return clsTestAppointmentsDataLayer.GetAllTestAppointments();
    }


    public static DataTable GetTestAppointmentsByTestTypeID(int LocalDrivingLicenseApplicationID , TestType TestTypeID)
    {
        return clsTestAppointmentsDataLayer.GetTestAppointmentByTestTypeID((int)TestTypeID, LocalDrivingLicenseApplicationID);
    }

    public static DataTable GetVisionTestAppointments(int LocalDrivingLicenseID)
    {
        return clsTestAppointmentsDataLayer.GetTestAppointmentByTestTypeID((int)TestType.VisionTest, LocalDrivingLicenseID);
    }

    public static DataTable GetWriteTestAppointments(int LocalDrivingLicenseID)
    {
        return clsTestAppointmentsDataLayer.GetTestAppointmentByTestTypeID((int)TestType.WrittenTest, LocalDrivingLicenseID);
    }

    public static DataTable GetPracticalTestAppointments(int LocalDrivingLicenseID)
    {
        return clsTestAppointmentsDataLayer.GetTestAppointmentByTestTypeID((int)TestType.PracticalTest, LocalDrivingLicenseID);
    }

    private bool AddNewTestAppointmet()
    {

        this.TestAppointmetID = clsTestAppointmentsDataLayer.InsertTestAppointmentAndReturnID(
               TestTypeID, LocalDrivingLicenseApplicationID,
              AppointmentDate, PaidFees,
        RetakTestApplicationID, CreatedByUserID, IsLocked);

        return (this.TestAppointmetID != -1);

    }

    private bool UpdateTestAppointmet()
    {
        return clsTestAppointmentsDataLayer.UpdateTestAppointmentWhereID(TestAppointmetID, TestTypeID, LocalDrivingLicenseApplicationID,
              AppointmentDate, PaidFees,
        RetakTestApplicationID, CreatedByUserID, IsLocked);

    }

    static public bool DeleteTestAppointmet(int TestAppointmetID)
    {
        return clsTestAppointmentsDataLayer.DeleteTestAppointmentByID(TestAppointmetID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (AddNewTestAppointmet())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            case enMode.Update:
                return UpdateTestAppointmet();


            default:
                return false;
        }

    }


    static public bool IsTestAppointmetExist(int TestAppointmetID)
    {
        return clsTestAppointmentsDataLayer.IsExistTestAppointment(TestAppointmetID);
    }

    static public bool IsTestAppointmentLocked()
    {
        return clsTestAppointmentsDataLayer.IsTestAppointmentLocked();
    }

    static public bool LockTestAppointmet(int testappointmentID)
    {
        return clsTestAppointmentsDataLayer.LockTestAppointment(testappointmentID);
    }

    static public bool IsApplicantHaveFailedTest(int TestTypeID , int LocalDrivingLicenseApplicationID)
    {
        //if the applicant have more than one trial then he failed the test

        return clsTestAppointmentsDataLayer.GetTestTrials(TestTypeID, LocalDrivingLicenseApplicationID, (byte)clsTests.enTestResult.Failed) >= 1;
    }

    static public int GetTestTrials(int TestTypeID, int LocalDrivingLicenseApplicationID)
    {
        //we count how many time the applicant have failed the test , which is the number of trials

        return clsTestAppointmentsDataLayer.GetTestTrials(TestTypeID, LocalDrivingLicenseApplicationID,(byte)clsTests.enTestResult.Failed);
    }

     static public bool DoesApplicantPassedAllTests(int LocalDrivingLicenseApplicationID)
    {
        return clsTestAppointmentsDataLayer.GetPassedTestsTotal(LocalDrivingLicenseApplicationID) == 3;
    }

    static public bool LockTest(int TestAppointment)
    {
        return clsTestAppointmentsDataLayer.LockTestAppointment(TestAppointment);
    }

    static public bool IsApplicantHaveAnActiveTestAppoinment(int LocalDrivingLicenseApplication , int TestTypeID)
    {
        return clsTestAppointmentsDataLayer.IsApplicantHaveAnAciveAppointment(LocalDrivingLicenseApplication , TestTypeID);
    }

    static public bool IsApplicantHavePassedTestByTestTypeID(int LocalDrivingLicenseApplication, clsTestTypes.TestType TestTypeID)
    {
        return clsTestAppointmentsDataLayer.IsApplicantHavePassedTestByTestType(LocalDrivingLicenseApplication, (int)TestTypeID);
    
    
  }

    static public bool DoesApplicantHavePassedPreviousTests(clsTestTypes.TestType CurrentTest,int LocalDrivingLicenseAPPID)
    {

        switch (CurrentTest)
        {
            //if current test is vision then no need the check previous tests
            case TestType.VisionTest:
                return true;

                //check if the applicant have passed vision test if he is in written test
            case TestType.WrittenTest:
                return IsApplicantHavePassedTestByTestTypeID(LocalDrivingLicenseAPPID, TestType.VisionTest);

            //check if the applicant have passed Writtent test if he is in written test
            case TestType.PracticalTest:
                return IsApplicantHavePassedTestByTestTypeID(LocalDrivingLicenseAPPID, TestType.WrittenTest);


            default:
                return false;
        }
    }


}

