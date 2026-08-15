using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BuisnessLayer
{
    public class clsUsers
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }

        enum enMode { Add = 0 , Update = 1 }
        enMode Mode;
        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            Password = null;
            UserName = null;
            IsActive = false;
            Mode = enMode.Add;
        }

        //make this private so you force every one to make the object by using the find method
        private clsUsers(int userID, int personID, string password, string userName, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            Password = password;
            UserName = userName;
            IsActive = isActive;
            Mode = enMode.Update;
        }

        public static clsUsers FindUserByID(int UserID)
        {
            int PersonID = -1;
            string password = null;
            string userName = null;
            bool isActive = false;

            if (clsUsersDataLayer.GetUserByID(UserID, ref PersonID, ref userName, ref password, ref isActive))

                return new clsUsers(UserID, PersonID, password, userName, isActive);
            else
                return null;


        }

        public static clsUsers FindUserByUserName(string UserName)
        {
            int UserID = -1;
            int PersonID = -1;
            string password = null;
            bool isActive = false;

            if (clsUsersDataLayer.GetUserByUserName(ref UserID, ref PersonID,  UserName, ref password, ref isActive))

                return new clsUsers(UserID, PersonID, password, UserName, isActive);
            else
                return null;

        }

        public static clsUsers FindUserByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool isActive = false;

            if (clsUsersDataLayer.GetUserByUserNameAndPassword(ref UserID, ref PersonID, UserName, Password, ref isActive))

                return new clsUsers(UserID, PersonID, Password, UserName, isActive);
            else
                return null;

        }

        public static DataTable GetAllUsers()
        {
            return clsUsersDataLayer.GetAllUsers();
        }

        private bool AddNewUser()
        {

            this.UserID = clsUsersDataLayer.InsertUserAndReturnID(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);

        }

        private bool UpdateUser()
        {
            return clsUsersDataLayer.UpdateUserWhereID(this.UserID,this.PersonID, this.UserName, this.Password, this.IsActive);

        }

        static public bool DeleteUser(int UserID)
        {
            return clsUsersDataLayer.DeleteUserByID(UserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (AddNewUser())
                    {
                        //after the object is added the mode must change to update 
                        //because now the object is full
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return (UpdateUser());

                default:
                    return false;
            }




        }

        static public bool IsUserExist(int UserID)
        {
            return clsUsersDataLayer.IsExistUser(UserID);
        }
        static public bool IsUserExist(string UserName)
        {
            return clsUsersDataLayer.IsExistUser(UserName);
        }

        static public bool IsUserActive(int UserID)
        {
            return clsUsersDataLayer.IsUserActive(UserID);
        }

        static public bool IsUserExistByPersonID(int PersonID)
        {
            return clsUsersDataLayer.IsUserConncetedWithAPerson(PersonID);
        }



    }
}
