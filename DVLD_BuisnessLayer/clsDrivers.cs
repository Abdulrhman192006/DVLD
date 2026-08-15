using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public class clsDrivers
{
    public int DriverID { get; set; }
    public int CreatedByUserID { get; set; }
    public DateTime CreatedDate { get; set; }
    public int PersonID { get; set; }



    private clsPeople _Person;

    public clsPeople PersonInfo
    {
        get
        {
            if (_Person == null)
            _Person = clsPeople.FindPersonByID(PersonID);

            return _Person;
        }
    }
    private enum enMode : byte { AddNew = 0, Update = 1 }
    enMode Mode;

    public clsDrivers()
    {
        DriverID = -1;
        PersonID = -1;
        CreatedByUserID = -1;
        CreatedDate = DateTime.Now;
        Mode = enMode.AddNew;
    }

    protected clsDrivers(int driverID,int createdByUserID, DateTime createdDate,int personID)
    {
        DriverID = driverID;
        PersonID = personID;
        CreatedByUserID = createdByUserID;
        CreatedDate = createdDate;
        Mode = enMode.Update;

    }

    public static clsDrivers FindDriverByID(int DriverID)
    {
        int PersonID = -1;
        int createdbyuserid = -1;
        DateTime CreatedDate =DateTime.Now;


        if (clsDriversDataConnetionLayer.GetDriverByID(DriverID, ref PersonID,ref createdbyuserid, ref CreatedDate))
        {
           return new clsDrivers(DriverID, createdbyuserid, CreatedDate, PersonID);
        }
        else
            return null;


    }

    public static clsDrivers FindDriverByPersonID(int PersonID)
    {
        int DriverID = -1;
        int createdbyuserid = -1;
        DateTime CreatedDate = DateTime.Now;


        if (clsDriversDataConnetionLayer.GetDriverByPersonID(ref DriverID, PersonID, ref createdbyuserid, ref CreatedDate))
        {
            
          return new clsDrivers(DriverID, createdbyuserid, CreatedDate, PersonID);

        }
        else
            return null;


    }


    public static DataTable GetAllDrivers()
    {
        return clsDriversDataConnetionLayer.GetAllDrivers();
    }

    private bool AddNewDriver()
    {

        this.DriverID = clsDriversDataConnetionLayer.InsertDriverAndReturnID(this.PersonID, this.CreatedByUserID, this.CreatedDate);

        return (this.DriverID != -1);

    }

    private bool UpdateDriver()
    {
        return clsDriversDataConnetionLayer.UpdateDriverWhereID(this.DriverID,this.PersonID, this.CreatedByUserID, this.CreatedDate);

    }

    static public bool DeleteDriver(int DriverID)
    {
        return clsDriversDataConnetionLayer.DeleteDriverByID(DriverID);
    }

    public bool Save()
    {

        switch (Mode)
        {
            case enMode.AddNew:
                if (AddNewDriver())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            case enMode.Update:
                if (UpdateDriver())
                    return true;
                else
                    return false;

            default:
                return false;
        }
    }


    static public bool IsDriverExist(int DriverID)
    {
        return clsDriversDataConnetionLayer.IsExistDriver(DriverID);
    }


    static public int GetDriverIDByPersonID(int PersonID)
    {
        return clsDriversDataConnetionLayer.GetDriverIDByPersonID(PersonID);
    }

    static public int GetDriverIDByLocalDrivingApplciaitonID(int LocalDrvingLicenseApplicationID)
    {
        return clsDriversDataConnetionLayer.GetDriverIDByLocalDrivingApplciaitonID(LocalDrvingLicenseApplicationID);
    }

}

