using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_BuisnessLayer.clsLicenses;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BuisnessLayer
{
    public class clsLicenses
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public enum IssueReasons { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacmentForLost = 4 }

        public IssueReasons IssueReason;

        public string IssueReasonString
        {
            get
            {
                switch (IssueReason)
                {
                    case IssueReasons.FirstTime:
                        return "First Time";

                    case IssueReasons.Renew:
                        return "Renew";

                    case IssueReasons.ReplacementForDamaged:
                        return "Replcement For Damaged";

                    case IssueReasons.ReplacmentForLost:
                        return "Replcement For Lost";

                    default:
                        return "UNKOWN";
                }
            }
        }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; }

        public bool IsDetained
        {
            get
            {

                return IsLicenseDetained();
            }
        }

        private clsApplications _ApplicationInfo;

        public clsApplications ApplicationInfo
        {
            get
            {
                if (_ApplicationInfo == null)
                {
                    _ApplicationInfo = clsApplications.FindApplicationByID(ApplicationID);
                }
                return _ApplicationInfo;
            }


        }


        private clsLicenseClasses _LicenseClassInfo;

        public clsLicenseClasses LicenseClassInfo
        {
            get
            {
                if (_LicenseClassInfo == null)
                {
                    _LicenseClassInfo = clsLicenseClasses.Find(LicenseClassID);
                }
                return _LicenseClassInfo;
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



        private clsLicenses(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate,
            DateTime expirationDate, string notes, decimal paidFees, byte issueReason, int createdByUserID, bool isActive)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IssueReason = (IssueReasons)issueReason;
            CreatedByUserID = createdByUserID;
            IsActive = isActive;
            Mode = enMode.Update;
        }

        public clsLicenses()

        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IssueReason = 0;
            CreatedByUserID = -1;
            IsActive = false;
            Mode = enMode.Add;
        }

        public static clsLicenses FindLicenseByID(int LicenseID)
        {
            int applicationID = -1;
            int driverID = -1;
            int PersonID = -1;
            int licenseClassID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            string notes = string.Empty;
            decimal paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;
            int createdByUserID = -1;

            if (clsLicensesDataLayer.GetLicenseByID(LicenseID, ref applicationID, ref driverID, ref licenseClassID, ref issueDate,
          ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID))

                return new clsLicenses(LicenseID, applicationID, driverID, licenseClassID, issueDate,
          expirationDate, notes, paidFees, issueReason, createdByUserID, isActive);
            else
                return null;

        }

        public static clsLicenses FindLicenseByApplicationID(int applicationID)
        {
            int LicenseID = -1;
            int driverID = -1;
            int PersonID = -1;
            int licenseClassID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            string notes = string.Empty;
            decimal paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;
            int createdByUserID = -1;

            if (clsLicensesDataLayer.GetLicenseByApplicationID(ref LicenseID, applicationID, ref driverID, ref licenseClassID, ref issueDate,
          ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID))

                return new clsLicenses(LicenseID, applicationID, driverID, licenseClassID, issueDate,
          expirationDate, notes, paidFees, issueReason, createdByUserID, isActive);
            else
                return null;

        }


        public static DataTable GetAllLicenses()
        {
            return clsLicensesDataLayer.GetAllLicenses();
        }

        private bool AddNewLicense()
        {

            this.LicenseID = clsLicensesDataLayer.InsertLicenseAndReturnID(
           ApplicationID,
           DriverID,
           LicenseClassID,
            IssueDate,
            ExpirationDate,
            Notes,
            PaidFees,
            IsActive,
           (byte)IssueReason,
           CreatedByUserID
            );

            return (this.LicenseID != -1);

        }

        private bool UpdateLicense()
        {
            return clsLicensesDataLayer.UpdateLicenseWhereID(this.LicenseID, ApplicationID,
           DriverID,
           LicenseClassID,
            IssueDate,
            ExpirationDate,
            Notes,
            PaidFees,
            IsActive,
           (byte)IssueReason,
           CreatedByUserID);

        }

        static public bool DeleteLicense(int LicenseID)
        {
            return clsLicensesDataLayer.DeleteLicenseByID(LicenseID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (AddNewLicense())
                    {
                        //after the object is added the mode must change to update 
                        //because now the object is full
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return (UpdateLicense());

                default:
                    return false;
            }


        }

        static public bool IsLicenseExist(int LicenseID)
        {
            return clsLicensesDataLayer.IsExistLicense(LicenseID);
        }

        static public bool IsLicenseExistByApplicationID(int AppkicationID)
        {
            return clsLicensesDataLayer.IsExistLicenseByApplicationID(AppkicationID);
        }

        private bool IsLicenseDetained()
        {
            return clsDetainedLicensesDataLayer.IsLicenseDetained(this.LicenseID);
        }


        static public bool DoesApplicantHaveIssuedLicenseBeforeWithApplicantIDAndLicenseClassID(int ApplicantID, int LicenseClassID)
        {
            return clsLicensesDataLayer.DoesApplicantHaveActiveIssuedLicenseBeforeWithClassIDAndApplicantID(ApplicantID, LicenseClassID);
        }


        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicensesDataLayer.GetAllDriverLicenses(DriverID);
        }

        private void Disable()
        {
            clsLicensesDataLayer.UpdateLicenseActiveMode(this.LicenseID, false);
        }


        private int IssueNewApplication(int UserID, clsApplications.enApplicationType ApplicationType)
        {
            clsApplications Application = new clsApplications();

            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;//the time we issue the application the license will be issued
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicantPersonID = this.ApplicationInfo.ApplicantPersonID;
            Application.ApplicationTypeID = (byte)ApplicationType;
            Application.CreatedByUserID = UserID;

            decimal fees = 0;
            if (clsApplicationTypes.GetApplicationTypeFees((byte)ApplicationType, ref fees))
            {
                Application.PaidFees = fees;
            }

            if (Application.Save())
            {
                return Application.ApplicationID;
            }
            else
            {
                return -1;
            }
        }

        public clsLicenses RenewLicense(string Notes, int UserID)
        {

            //issue new renew application 
            int RenewApplicationID = IssueNewApplication(UserID, clsApplications.enApplicationType.RenewDrivingLicense);
            if (RenewApplicationID == -1)
            {
                return null;
            }

            clsLicenses RenewedLicense = new clsLicenses();

            RenewedLicense.Notes = Notes;
            RenewedLicense.PaidFees = this.PaidFees;
            RenewedLicense.CreatedByUserID = UserID;
            RenewedLicense.DriverID = this.DriverID;
            RenewedLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            RenewedLicense.IssueDate = DateTime.Now;
            RenewedLicense.IssueReason = IssueReasons.Renew;
            RenewedLicense.ApplicationID = RenewApplicationID;
            RenewedLicense.LicenseClassID = this.LicenseClassID;
            RenewedLicense.IsActive = true;

            if (RenewedLicense.Save())
            {
                //disbale old license
                Disable();

                return RenewedLicense;

            }
            else
            {
                //in case the save of renew license is failed then we delete the application so it not connected to nothing
                clsApplications.DeleteApplication(RenewApplicationID);
                return null;
            }

        }


        public clsLicenses Replace(IssueReasons ReplacementFor, int UserID)
        {
            //issue new Replace application 
            int ReplaceLostApplicationID = ReplacementFor == IssueReasons.ReplacementForDamaged ?
                IssueNewApplication(UserID, clsApplications.enApplicationType.ReplaceDamagedDrivingLicense) :
                 IssueNewApplication(UserID, clsApplications.enApplicationType.ReplaceLostDrivingLicense);

            if (ReplaceLostApplicationID == -1)
            {
                return null;
            }

            clsLicenses ReplacedLicense = new clsLicenses();

            ReplacedLicense.Notes = Notes;
            ReplacedLicense.PaidFees = 0;//the fees is 0 because we are replacing the license
            ReplacedLicense.CreatedByUserID = UserID;
            ReplacedLicense.DriverID = this.DriverID;
            ReplacedLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            ReplacedLicense.IssueDate = DateTime.Now;
            ReplacedLicense.IssueReason = ReplacementFor;
            ReplacedLicense.ApplicationID = ReplaceLostApplicationID;
            ReplacedLicense.LicenseClassID = this.LicenseClassID;
            ReplacedLicense.IsActive = true;

            if (ReplacedLicense.Save())
            {
                //disbale old license
                Disable();

                return ReplacedLicense;

            }
            else
            {
                //in case the save of license is failed then we delete the application so it not connected to nothing
                clsApplications.DeleteApplication(ReplaceLostApplicationID);
                return null;
            }

        }



        public int Detain(decimal FineFees, int UserID)
        {


            //In Detain There is no application to be issued.

            clsDetainedLicenses DetianedLicenseInfo = new clsDetainedLicenses();


            DetianedLicenseInfo.DetainDate = DateTime.Now;
            DetianedLicenseInfo.FineFees = FineFees;
            DetianedLicenseInfo.CreatedByUserID = UserID;
            DetianedLicenseInfo.IsReleased = false;
            DetianedLicenseInfo.LicenseID = this.LicenseID;

            if (DetianedLicenseInfo.Save())
            {
                return DetianedLicenseInfo.DetainID;

            }
            else
            {
                return -1;
            }

        }



        private bool SetLicenseRelease(int DetainID, DateTime? ReleaseDate, int ReleaseByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicensesDataLayer.ReleaseDetainedLicense(DetainID, ReleaseDate, ReleaseByUserID, ReleaseApplicationID);
        }


        public int Release(int UserID, int DetainID)
        {
            //issue new Release application 
            int ReleaseApplicationID = IssueNewApplication(UserID, clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense);

            if (ReleaseApplicationID == -1)
            {
                return -1;
            }

            bool IsLicenseReleased = SetLicenseRelease(DetainID, DateTime.Now, UserID, ReleaseApplicationID);

            if (IsLicenseReleased)
            {

                return ReleaseApplicationID;

            }
            else
            {
                //in case the save of release license is failed then we delete the application so it not connected to nothing
                clsApplications.DeleteApplication(ReleaseApplicationID);
                return -1;
            }

        }


        public clsInternationalLicenses IssueInternationalLicense(int UserID)
        {


            //issue new Intetnational License application 
            int InternationalLicenseApplicaitonID = IssueNewApplication(UserID, clsApplications.enApplicationType.NewInternationalLicense);
            if (InternationalLicenseApplicaitonID == -1)
            {
                return null;
            }

            clsInternationalLicenses InternationalLicense = new clsInternationalLicenses();

            InternationalLicense.LocalLicenseID = this.LicenseID;
            InternationalLicense.CreatedByUserID = UserID;
            InternationalLicense.DriverID = this.DriverID;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ApplicationID = InternationalLicenseApplicaitonID;
            InternationalLicense.IsActive = true;

            if (InternationalLicense.Save())
            {
                //disbale old license
                //Disable();

                return InternationalLicense;

            }
            else
            {
                //in case the save of renew license is failed then we delete the application so it not connected to nothing
                clsApplications.DeleteApplication(InternationalLicenseApplicaitonID);
                return null;
            }

        }


    }
}
