using DVLD_BuisnessLayer;
using DVLD_DataAccess;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using static clsDetainedLicenses;
using static System.Net.Mime.MediaTypeNames;


public class clsDetainedLicenses
{
    public enum enDetainedLicenseType
    {
        NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
        ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
    };
    public int DetainID { get; set; }
    public int LicenseID { get; set; }
    public DateTime DetainDate { get; set; }
    public decimal FineFees { get; set; }
    public int CreatedByUserID {  get; set; }
    public bool IsReleased { get; set; }

    public DateTime? ReleaseDate { get ; set; }
    public int ReleaseByUserID { get; set; }

    public int ReleaseApplicationID { get; set; }

    private clsLicenses _License;
    public clsLicenses LicenseInfo
    {
        get
        {
            if (_License == null)
                _License = clsLicenses.FindLicenseByID(LicenseID);

            return _License;
        }
    }

    private enum enMode : byte { AddNew = 0, Update = 1 }
    enMode Mode;

    public clsDetainedLicenses()
    {

        DetainID = -1;
        LicenseID = -1;
        DetainDate = DateTime.Now;
        FineFees = 0;
        CreatedByUserID = -1;
        IsReleased = false;
        ReleaseDate = null;
        ReleaseByUserID = -1;
        CreatedByUserID = -1;
        ReleaseApplicationID = -1;
        Mode = enMode.AddNew;
    }

    public clsDetainedLicenses(int detainID, int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID,
        bool isReleased, DateTime? releaseDate, int releaseByUserID, int releaseApplicationID)
    {
        DetainID = detainID;
        LicenseID = licenseID;
        DetainDate = detainDate;
        FineFees = fineFees;
        CreatedByUserID = createdByUserID;
        IsReleased = isReleased;
        ReleaseDate = releaseDate;
        ReleaseByUserID = releaseByUserID;
        ReleaseApplicationID = releaseApplicationID;
        Mode = enMode.Update;

    }

    public static clsDetainedLicenses FindDetainedLicenseByID(int DetainedLicenseID)
    {
        int licenseID = -1;
        DateTime detainDate = DateTime.MinValue;
        decimal fineFees = 0;            //this will be converted to enum when making a new object
        int createdByUserID = -1;
        bool isReleased = false;
        DateTime? releaseDate = DateTime.MinValue;
        int releaseByUserID = -1;
        int releaseApplicationID = -1;


        if (clsDetainedLicensesDataLayer.GetDetainedLicenseByID(DetainedLicenseID, ref licenseID, ref detainDate, ref fineFees,
            ref createdByUserID,
      ref isReleased, ref releaseDate, ref releaseByUserID , ref releaseApplicationID))

            return new clsDetainedLicenses(DetainedLicenseID,   licenseID,   detainDate,   fineFees,
              createdByUserID,
        isReleased,   releaseDate,   releaseByUserID,   releaseApplicationID);
        else
            return null;


    }


    public static clsDetainedLicenses FindDetainedLicenseByLicenseID(int licenseID)
    {
        int DetainID = -1;
        DateTime detainDate = DateTime.MinValue;
        decimal fineFees = 0;            //this will be converted to enum when making a new object
        int createdByUserID = -1;
        bool isReleased = false;
        DateTime? releaseDate = DateTime.MinValue;
        int releaseByUserID = -1;
        int releaseApplicationID = -1;


        if (clsDetainedLicensesDataLayer.GetDetainedLicenseByLicenseID(ref DetainID, licenseID, ref detainDate, ref fineFees,
            ref createdByUserID,
      ref isReleased, ref releaseDate, ref releaseByUserID, ref releaseApplicationID))

            return new clsDetainedLicenses(DetainID, licenseID, detainDate, fineFees,
              createdByUserID,
        isReleased, releaseDate, releaseByUserID, releaseApplicationID);
        else
            return null;

    }


    public static DataTable GetAllDetainedLicensesSelectedColumns()
    {
        return clsDetainedLicensesDataLayer.GetAllDetainedLicenses();
    }

    private bool AddNewDetainedLicense()
    {

        this.DetainID = clsDetainedLicensesDataLayer.InsertDetainedLicenseAndReturnID(LicenseID, DetainDate, FineFees, 
            CreatedByUserID,
       IsReleased, ReleaseDate, ReleaseByUserID,ReleaseApplicationID);

        return (this.DetainID != -1);

    }

    private bool UpdateDetainedLicense()
    {
        return clsDetainedLicensesDataLayer.UpdateDetainedLicenseWhereID(DetainID,LicenseID, DetainDate, FineFees,
            CreatedByUserID,
       IsReleased, ReleaseDate, ReleaseByUserID, ReleaseApplicationID);

    }

    static public bool DeleteDetainedLicense(int DetainedLicenseID)
    {
        return clsDetainedLicensesDataLayer.DeleteDetainedLicenseByID(DetainedLicenseID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (AddNewDetainedLicense())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            case enMode.Update:
                if (UpdateDetainedLicense())
                    return true;
                else
                    return false;

            default:
                return false;
        }


    }


    public static bool IsLicensaeDetained(int LicensaeID) 
    {
    
        return clsDetainedLicensesDataLayer.IsLicenseDetained(LicensaeID);
    }


}

