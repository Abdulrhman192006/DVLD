using DVLD_BuisnessLayer;
using DVLD_DataAccess;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using static clsTests;
using static clsTestTypes;
using static System.Net.Mime.MediaTypeNames;


public class clsTests
{

    public enum enTestResult { Failed = 0 , Passed = 1}

    public int TestID { get; set; }
    public int TestAppointmentID { get; set; }
    public bool TestResult { get; set; } // 1 = pass , 0 = fail
    public string Notes { get; set; }
    public int CreatedByUserID { get; set; }

    private clsTestAppointments _TestAppointment;
    public void RefereshTestAppointment() //use this method in case the Test Appoinment has been edited and we want the object to be refershed becuase of the lazy loading
    {
        _TestAppointment = null;
    }
    public clsTestAppointments TestAppointment
    {
        get
        {
            if (_TestAppointment == null)
                 _TestAppointment = clsTestAppointments.FindTestAppointmetByID(TestAppointmentID);

            return _TestAppointment;
        }
    }

    private enum enMode : byte { AddNew = 0, Update = 1 }
    enMode Mode;



    public clsTests()
    {
        TestID = -1;
        TestAppointmentID = -1;
        TestResult = false;
        CreatedByUserID = -1;
    }
    protected clsTests(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
    {
        TestID = testID;
        TestAppointmentID = testAppointmentID;
        TestResult = testResult;
        Notes = notes;
        CreatedByUserID = createdByUserID;
    }
    public static clsTests FindTestByID(int TestID)
    {
        int testAppointmentID = -1;
        string notes = string.Empty;
        bool testResult = false;
        int createdByUserID = -1;

        if (clsTestsDataLayer.GetTestsByID(TestID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))

            return new clsTests(TestID, testAppointmentID, testResult, notes, createdByUserID);
        else
            return null;

    }


    public static clsTests FindTestByTestAppointmentID(int TestAppointmentID)
    {
        int TestID = -1;
        string notes = string.Empty;
        bool testResult = false;
        int createdByUserID = -1;

        if (clsTestsDataLayer.GetTestsByTestAppointmentID(ref TestID, TestAppointmentID, ref testResult, ref notes, ref createdByUserID))

            return new clsTests(TestID, TestAppointmentID, testResult, notes, createdByUserID);
        else
            return null;

    }

    public static DataTable GetAllTests()
    {
        return clsTestsDataLayer.GetAllTests();
    }

    private bool AddNewTest()
    {

        this.TestID = clsTestsDataLayer.InsertTestsAndReturnID(
               TestAppointmentID, TestResult,
              Notes, CreatedByUserID);

        return (this.TestID != -1);

    }

    private bool UpdateTest()
    {
        return clsTestsDataLayer.UpdateTestsWhereID(TestID, TestAppointmentID, TestResult,
              Notes, CreatedByUserID);

    }

    static public bool DeleteTest(int TestID)
    {
        return clsTestsDataLayer.DeleteTestsByID(TestID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (AddNewTest())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            case enMode.Update:
                return UpdateTest();


            default:
                return false;
        }

    }


    static public bool IsTestExist(int TestID)
    {
        return clsTestsDataLayer.IsExistTests(TestID);
    }
    public static bool UpdateTestResultByTestType(TestType TestType , byte TestResult,int TestAppointmentID)
    {
        switch (TestType)
        {
            case TestType.VisionTest:
               return clsTestsDataLayer.UpdateTestResult((int)TestType.VisionTest, TestResult, TestAppointmentID);
                
            case TestType.WrittenTest:
                return clsTestsDataLayer.UpdateTestResult((int)TestType.WrittenTest, TestResult, TestAppointmentID);

            case TestType.PracticalTest:
                return clsTestsDataLayer.UpdateTestResult((int)TestType.PracticalTest, TestResult, TestAppointmentID);

            default:
                return false;
        }
    }

    public static byte GetPassedTests(int LocalDrivingLiceseApplicationID)
    {
        return clsTestsDataLayer.GetLocalDrivingLicenseApplicationPassedTests(LocalDrivingLiceseApplicationID);
    }

    public static bool UpdateNotes(string Notes , int TestAppointmentID)
    {
        return clsTestsDataLayer.UpdateNotes(Notes, TestAppointmentID);
                
    }

}

