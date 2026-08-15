using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_BuisnessLayer.clsInternationalLicenses;
using static DVLD_BuisnessLayer.clsLicenses;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BuisnessLayer
{
    public class clsInternationalLicenses
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; }


        private clsLicenses _License;

        public clsLicenses License
        {
            get 
            {
                if(_License == null)
                {
                    _License = clsLicenses.FindLicenseByID(LocalLicenseID);
                }
                return _License; 
            } 
        
        
        }

        private clsDrivers _Driver;

        public clsDrivers Driver
        {
            get
            {
                if (_Driver == null)
                {
                    _Driver = clsDrivers.FindDriverByID(DriverID);
                }
                return _Driver;
            }


        }
        enum enMode { Add = 0, Update = 1 }
        enMode Mode;

        public clsInternationalLicenses(int internationalLicenseID, int applicationID, int driverID, int localLicenseID, 
            DateTime issueDate, DateTime expirationDate, int createdByUserID, bool isActive)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LocalLicenseID = localLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            CreatedByUserID = createdByUserID;
            IsActive = isActive;
        }

        public clsInternationalLicenses()

        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            CreatedByUserID = -1;
            IsActive = false;
            Mode = enMode.Add;
        }

        public static clsInternationalLicenses FindInternationalLicenseByID(int InternationalLicenseID)
        {
            int applicationID = -1;
            int driverID = -1;
            int LocalLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;

            if (clsInternationalInternationalLicensesDataLayer.GetInternationalLicenseByID(InternationalLicenseID,ref applicationID, ref driverID, ref LocalLicenseID, ref issueDate,
          ref expirationDate, ref isActive, ref createdByUserID))

                return new clsInternationalLicenses(InternationalLicenseID,   applicationID,   driverID, LocalLicenseID, issueDate,
          expirationDate, createdByUserID, isActive);
            else
                return null;

        }

        public static clsInternationalLicenses FindInternationalLicenseByApplicationID(int applicationID)
        {
            int InternationalLicenseID = -1;
            int driverID = -1;
            int LocalLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;

            if (clsInternationalInternationalLicensesDataLayer.GetInternationalLicenseByApplicationID(ref InternationalLicenseID,  applicationID, ref driverID, ref LocalLicenseID, ref issueDate,
          ref expirationDate, ref isActive, ref createdByUserID))

                return new clsInternationalLicenses(InternationalLicenseID, applicationID, driverID, LocalLicenseID, issueDate,
          expirationDate, createdByUserID, isActive);
            else
                return null;

        }


        public static clsInternationalLicenses FindInternationalLicenseByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;
            int applicationID = -1;
            int LocalLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;

            if (clsInternationalInternationalLicensesDataLayer.GetInternationalLicenseByDriverID(ref InternationalLicenseID, ref applicationID, DriverID, ref LocalLicenseID, ref issueDate,
          ref expirationDate, ref isActive, ref createdByUserID))

                return new clsInternationalLicenses(InternationalLicenseID, applicationID, DriverID, LocalLicenseID, issueDate,
          expirationDate, createdByUserID, isActive);
            else
                return null;

        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalInternationalLicensesDataLayer.GetAllInternationalInternationalLicenses();
        }

        public static DataTable GetAllDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalInternationalLicensesDataLayer.GetAllDriverInternationalInternationalLicenses(DriverID);
        }

        private bool AddNewInternationalLicense()
        {

            this.InternationalLicenseID = clsInternationalInternationalLicensesDataLayer.InsertInternationalLicenseAndReturnID(
           ApplicationID,
           DriverID,
           LocalLicenseID,
            IssueDate,
            ExpirationDate,
            IsActive,
           CreatedByUserID
            );

            return (this.InternationalLicenseID != -1);

        }

        private bool UpdateInternationalLicense()
        {
            return clsInternationalInternationalLicensesDataLayer.UpdateInternationalLicenseWhereID(this.InternationalLicenseID, ApplicationID,
           DriverID,
           LocalLicenseID,
            IssueDate,
            ExpirationDate,
            IsActive,
           CreatedByUserID);

        }

        static public bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            return clsInternationalInternationalLicensesDataLayer.DeleteInternationalLicenseByID(InternationalLicenseID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (AddNewInternationalLicense())
                    {
                        //after the object is added the mode must change to update 
                        //because now the object is full
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return (UpdateInternationalLicense());

                default:
                    return false;
            }


        }

        static public bool IsInternationalLicenseExist(int InternationalLicenseID)
        {
            return clsInternationalInternationalLicensesDataLayer.IsExistInternationalLicense(InternationalLicenseID);
        }

        static public bool IsInternationalLicenseExistByLicenseID(int LicenseID)
        {
            return clsInternationalInternationalLicensesDataLayer.IsExistInternationalLicenseByLicenseID(LicenseID);
        }

    }
}
