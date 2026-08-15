using DVLD_BuisnessLayer;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static clsApplications;
using static System.Net.Mime.MediaTypeNames;


public class clsLocalDrivingLicenseApplications : clsApplications //inheritance
{
    public int LocalDrivingLicenseApplicationID { get; set; }
    public int LicenseClassID { get; set; }
    enum enMode { Add = 0, Update = 1 }
    enMode Mode;

    private clsLicenseClasses _LicenseClass;
    public clsLicenseClasses LicenseClass
    {
        get
        {
            if (_LicenseClass == null)
                _LicenseClass = clsLicenseClasses.Find(LicenseClassID);

            return _LicenseClass;
        }
    }

    //int applicationID, int applicantPersonID,int applicationTypeID, DateTime applicationDate,
    //enApplicationStatus applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserI
    public clsLocalDrivingLicenseApplications(
        int localDrivingLicenseApplicationID, int applicationID, int licenseClassID,
         int applicantPersonID, int applicationTypeID, DateTime applicationDate,
    enApplicationStatus applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        : base(applicationTypeID, applicantPersonID, applicationTypeID, applicationDate, applicationStatus, lastStatusDate, paidFees, createdByUserID)

    {
        ApplicationID = applicationID;
        ApplicantPersonID = applicantPersonID;
        ApplicationTypeID = applicationTypeID;
        ApplicationDate = applicationDate;
        ApplicationStatus = applicationStatus;
        LastStatusDate = lastStatusDate;
        PaidFees = paidFees;
        CreatedByUserID = createdByUserID;
        LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        LicenseClassID = licenseClassID;
        Mode = enMode.Update;

    }

    public clsLocalDrivingLicenseApplications()
    {
        ApplicantPersonID = -1;
        ApplicationTypeID = -1;
        ApplicationDate = DateTime.Now;
        ApplicationStatus = enApplicationStatus.New;
        LastStatusDate = DateTime.Now;
        PaidFees = 0;
        CreatedByUserID = -1;
        LocalDrivingLicenseApplicationID = -1;
        ApplicationID = -1;
        LicenseClassID = -1;
        Mode = enMode.Add;
    }


    public static clsLocalDrivingLicenseApplications FindLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID)
    {
        int ApplicationID = -1;
        int LicenseClassID = -1;

        //we check first if the load of the locallicense is successfully and after that we load the application object
        if (clsLocalDrivingLicenseApplicationsDataLayer.GetLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
        {
            clsApplications Application = clsApplications.FindApplicationByID(ApplicationID);

            if (Application != null)
            {
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID, Application.ApplicantPersonID,
                    Application.ApplicationTypeID, Application.ApplicationDate, Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees
                    , Application.CreatedByUserID);
            }
            return null;

        }
        return null;

    }

    public static clsLocalDrivingLicenseApplications FindLocalDrivingLicenseApplicationByApplicationID(int ApplicationID)
    {
        int LocalDrivingLicenseApplicationID = -1;
        int LicenseClassID = -1;


        //we check first if the load of the locallicense is successfully and after that we load the application object
        if (clsLocalDrivingLicenseApplicationsDataLayer.GetLocalDrivingLicenseApplicationByApplicationID(ref LocalDrivingLicenseApplicationID, ApplicationID, ref LicenseClassID))
        {
            clsApplications Application = clsApplications.FindApplicationByID(ApplicationID);

            if (Application != null)
            {
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID, Application.ApplicantPersonID,
                    Application.ApplicationTypeID, Application.ApplicationDate, Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees
                    , Application.CreatedByUserID);
            }
            return null;

        }
        return null;

    }
    public static DataTable GetAllLocalDrivingLicenseApplications()
    {
        return clsLocalDrivingLicenseApplicationsDataLayer.GetAllLocalDrivingLicenseApplications();
    }

    private bool AddNewLocalDrivingLicenseApplication()
    {

        this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataLayer.InsertLocalDrivingLicenseApplicationAndReturnID(this.ApplicationID, this.LicenseClassID);

        return (this.LocalDrivingLicenseApplicationID != -1);

    }

    private bool UpdateLocalDrivingLicenseApplication()
    {
        return clsLocalDrivingLicenseApplicationsDataLayer.UpdateLocalDrivingLicenseApplicationWhereID(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);

    }

    static public bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
    {
        //first delete base application , if success delete the local driving license application
        int ApplicationID = clsLocalDrivingLicenseApplicationsDataLayer.GetApplicationIDByLocalApplicationID(LocalDrivingLicenseApplicationID);

        if (clsLocalDrivingLicenseApplicationsDataLayer.DeleteLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID))
            return DeleteApplication(ApplicationID);
        else
            return false;
    }

    public new bool Save()
    {
        //becuase we inherinted application , we must use the save method in the base to either add or update 
        if (!base.Save())
            return false;

        switch (Mode)
        {
            case enMode.Add:
                if (AddNewLocalDrivingLicenseApplication())
                {
                    //after the object is added the mode must change to update 
                    //because now the object is full
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            case enMode.Update:
                return (UpdateLocalDrivingLicenseApplication());

            default:
                return false;
        }




    }

    static public bool IsApplicantHaveActiveLocalDrivingLicenseApplicationWithSameClass(int ApplicantID, int LicenseClassID)
    {
        //We check if the applicant have already an active license local application with same class
        return clsLocalDrivingLicenseApplicationsDataLayer.IsApplicantHaveLocalDrivingLicenseApplicationWithStatusAndLicenseClassID(ApplicantID, LicenseClassID,(byte)enApplicationStatus.New);
    }

    static public bool IsApplicantHaveCompletedLocalDrivingLicenseApplicationWithSameClass(int ApplicantID, int LicenseClassID)
    {
        //We check if the applicant have already an active license local application with same class
        return clsLocalDrivingLicenseApplicationsDataLayer.IsApplicantHaveLocalDrivingLicenseApplicationWithStatusAndLicenseClassID(ApplicantID, LicenseClassID, (byte)enApplicationStatus.Completed);
    }

    static public bool IsLocalDrivingLicenseApplicationActive(int LocalLicenseID)
    {
        return clsLocalDrivingLicenseApplicationsDataLayer.IsLocalDrivingLicenseApplicationStatus(LocalLicenseID, (byte)enApplicationStatus.New);
    }
    static public bool IsLocalDrivingLicenseApplicationCancelled(int LocalLicenseID)
    {
        return clsLocalDrivingLicenseApplicationsDataLayer.IsLocalDrivingLicenseApplicationStatus(LocalLicenseID, (byte)enApplicationStatus.Cancelled);
    }
    static public bool IsLocalDrivingLicenseApplicationCompleted(int LocalLicenseID)
    {
        return clsLocalDrivingLicenseApplicationsDataLayer.IsLocalDrivingLicenseApplicationStatus(LocalLicenseID, (byte)enApplicationStatus.Completed);
    }

    static public bool CancelApplicationByLocalID(int LocalDLID)
    {

        return clsLocalDrivingLicenseApplicationsDataLayer.UpdateApplicationStatus(LocalDLID, (byte)enApplicationStatus.Cancelled);
    }

    private void SetComplete()
    {
        clsApplicationsDataLayer.UpdateApplicationStatus(this.ApplicationID,(byte)enApplicationStatus.Completed);
    }


    public  bool DoesApplicantHaveIssuedLicenseBefore()
    {
        return clsLicenses.DoesApplicantHaveIssuedLicenseBeforeWithApplicantIDAndLicenseClassID(this.ApplicantPersonID, this.LicenseClassID);
    }


    private clsLicenses _License = new clsLicenses();

    private clsDrivers _Driver;

    enum enDriverMode { AddNew = 1, Exists = 2 }
    enDriverMode _DriverMode;
    private bool CheckIfApplicantIsConnectedToDriver()
    {
        _Driver = clsDrivers.FindDriverByPersonID(this.ApplicantPersonID);

        if (_Driver != null)
        {
            _DriverMode = enDriverMode.Exists;
            return true;
        }
        else
        {
            _DriverMode = enDriverMode.AddNew;
            return false;
        }
    }
    private bool _HandleDriver(int UserID)
    {
        if (!CheckIfApplicantIsConnectedToDriver())
        {
            _Driver = new clsDrivers();

            _Driver.PersonID = this.ApplicantPersonID;
            _Driver.CreatedByUserID = UserID;
            _Driver.CreatedDate = DateTime.Now;

            if (_Driver.Save())
            {
                _License.DriverID = _Driver.DriverID;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            _License.DriverID = _Driver.DriverID;
            return true;

        }

    }

    public int IssueLicenseForFirstTime(string Notes, int CurrentUserID)
    {
        //We must check if applicant is driver or not , if he is not a driver we make a new driver and 
        //connect it with this applicant and all Licenses will be connected to this driver
        if (!_HandleDriver(CurrentUserID))
            return -1;

        //after the driver is handeled , we make now the license object

        _License.ApplicationID = this.ApplicationID;
        _License.PaidFees = this.LicenseClass.ClassFees;

        //The Expiration Date Is Adding the years of validy lenght of the license class to the Date Now
        _License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.DefaultValidityLength);

        _License.IssueDate = DateTime.Now;
        _License.Notes = Notes;
        _License.IssueReason = clsLicenses.IssueReasons.FirstTime;
        _License.IsActive = true;
        _License.CreatedByUserID = CurrentUserID;
        _License.LicenseClassID = this.LicenseClassID;

        if (_License.Save())
        {

            SetComplete();
            return _License.LicenseID;

        }
        else
        {
            return -1;
        }
    }

}

