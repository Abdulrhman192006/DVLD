using DVLD_BuisnessLayer;
using DVLD_DataAccess;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using static clsApplications;
using static System.Net.Mime.MediaTypeNames;


public class clsApplications
{
    public enum enApplicationType
    {
        NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
        ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
    };
    public int ApplicationID { get; set; }
    public int ApplicantPersonID { get; set; }
    public int ApplicationTypeID { get; set; }
    public DateTime ApplicationDate { get; set; }
    public enum enApplicationStatus { New = 1 , Cancelled = 2 , Completed = 3}
    public enApplicationStatus ApplicationStatus { get; set; }

    private clsPeople _person;

    public void RefereshPerson() //use this method in case the person has been edited and we want the object to be refershed becuase of the lazy loading
    {
        _person = null;
    }
    public clsPeople PersonInfo
    {
        get
        {
            if(_person == null)
                _person = clsPeople.FindPersonByID(ApplicantPersonID);

            return _person;
        }
    }

    //make this proprety to store the text of the status , so when you want to use it in a control info or anything you already have it
    //better than making switch case every time in the form when you need the status text
    public string StatusText { 
            get
            {
            switch (ApplicationStatus)
            {
                case enApplicationStatus.New:
                    return "New";
                    case enApplicationStatus.Cancelled:
                    return "Cancelled";
                    case enApplicationStatus.Completed:
                    return "Completed";
                default:
                    return "Unknown";

            }
             } 
    }  

    public DateTime LastStatusDate { get; set; }
    public decimal PaidFees { get; set; }
    public int CreatedByUserID { get; set; }

    private clsUsers _users;
    public clsUsers UserInfo
    {
        get
        {
            if (_users == null)
                _users = clsUsers.FindUserByID(CreatedByUserID);

            return _users;
        }
    }

    private clsApplicationTypes _ApplicationType;
    public clsApplicationTypes ApplicationType
    {
        get
        {
            if (_ApplicationType == null)
                _ApplicationType = clsApplicationTypes.Find(ApplicationTypeID);

            return _ApplicationType;

        }
    }

    private enum enMode : byte { AddNew = 0, Update = 1 }
    enMode Mode;

    public clsApplications()
    {

        ApplicationID = -1;
        ApplicantPersonID = -1;
        ApplicationTypeID = -1;
        ApplicationDate = DateTime.MinValue;
        ApplicationStatus = enApplicationStatus.New;
        LastStatusDate = DateTime.MinValue;
        PaidFees = 0;
        CreatedByUserID = -1;
        Mode = enMode.AddNew;
    }

    //make this private so you force every one to make the object by using the find method
    protected clsApplications(int applicationID, int applicantPersonID,int applicationTypeID, DateTime applicationDate,
        enApplicationStatus applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
    {
        ApplicationID = applicationID;
        ApplicantPersonID = applicantPersonID;
        ApplicationTypeID = applicationTypeID;
        ApplicationDate = applicationDate;
        ApplicationStatus = applicationStatus;
        LastStatusDate = lastStatusDate;
        PaidFees = paidFees;
        CreatedByUserID = createdByUserID;
        Mode  = enMode.Update;
    }

    public static clsApplications FindApplicationByID(int ApplicationID)
    {
        int ApplicantPersonID = -1;
       DateTime ApplicationDate = DateTime.MinValue;
        int ApplicationTypeID = -1;
       byte ApplicationStatus = 0;            //this will be converted to enum when making a new object
        DateTime LastStatusDate = DateTime.MinValue;
       decimal PaidFees = 0;
       int CreatedByUserID = -1;

        if (clsApplicationsDataLayer.GetApplicationByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
      ref LastStatusDate, ref PaidFees, ref CreatedByUserID))

            return new clsApplications(ApplicationID,  ApplicantPersonID, ApplicationTypeID, ApplicationDate,(enApplicationStatus)ApplicationStatus,
       LastStatusDate,  PaidFees,  CreatedByUserID);
        else
            return null;


    }


    public static clsApplications FindApplicationByPersonID(int PersonID)
    {
        int ApplicactionID = -1;
        DateTime ApplicationDate = DateTime.MinValue;
        int ApplicationTypeID = -1;
        byte ApplicationStatus =0;      //this will be converted to enum when making a new object
        DateTime LastStatusDate = DateTime.MinValue;
        decimal PaidFees = 0;
        int CreatedByUserID = -1;

        if (clsApplicationsDataLayer.GetApplicationByPersonID(ref ApplicactionID, PersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
      ref LastStatusDate, ref PaidFees, ref CreatedByUserID))

            return new clsApplications(ApplicactionID, PersonID, ApplicationTypeID, ApplicationDate, (enApplicationStatus)ApplicationStatus,
       LastStatusDate, PaidFees, CreatedByUserID);
        else
            return null;


    }


    public static DataTable GetAllApplicationsSelectedColumns()
    {
        return clsApplicationsDataLayer.GetAllApplications();
    }

    private bool AddNewApplication()
    {

        this.ApplicationID = clsApplicationsDataLayer.InsertApplicationAndReturnID(ApplicantPersonID, ApplicationDate, ApplicationTypeID,(byte)ApplicationStatus,
       LastStatusDate,  PaidFees, CreatedByUserID);

        return (this.ApplicationID != -1);

    }

    private bool UpdateApplication()
    {
        return clsApplicationsDataLayer.UpdateApplicationWhereID(ApplicationID,ApplicantPersonID, ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus,
       LastStatusDate, PaidFees, CreatedByUserID);

    }

    static public bool DeleteApplication(int ApplicationID)
    {
        return clsApplicationsDataLayer.DeleteApplicationByID(ApplicationID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (AddNewApplication())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            case enMode.Update:
                if (UpdateApplication())
                    return true;
                else
                    return false;

            default:
                return false;
        }




    }


    static public bool IsApplicationExist(int ApplicationID)
    {
        return clsApplicationsDataLayer.IsExistApplication(ApplicationID);
    }

    static public bool IsApplicationExistByPersonID(int PersonID)
    {
        return clsApplicationsDataLayer.IsExistApplication(PersonID);
    }

    static public bool IsPersonHaveActiveApplication(int personid , int TypeID) 
    {
        return clsApplicationsDataLayer.IsPersonHaveActiveApplication(personid , TypeID);
    }

    static public bool CancelApplication(int ApplicationID, byte status)
    {

        return clsLocalDrivingLicenseApplicationsDataLayer.UpdateApplicationStatus(ApplicationID, status);
    }
}

