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



    public class clsPeople
    {
    // int PersonID, ref string NationalNumber, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref byte Gender,
    // ref string email, ref string phone, ref string address, ref DateTime dateOfBirth, ref int countryID, ref string imagePath


    public int PersonID { get; set; }
    public string NationalNumber { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string ThirdName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public enum  enGender : byte { Male = 0 , Female = 1}
    public enGender Gender;
    public DateTime DateOfBirth {  get; set; }
    public int CountryID { get; set; }
    public string ImagePath { get; set; }

    public string FullName
    {
        get
        {
            return FirstName + " " + SecondName + " "+ ThirdName +  " " + LastName;
        }
    }
    private enum enMode : byte { AddNew = 0 , Update = 1 }
    enMode Mode;


    public clsPeople()
    {
        PersonID = 0;
        NationalNumber = string.Empty;
        FirstName = string.Empty;
        SecondName = string.Empty;
        ThirdName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Address = string.Empty;
        PhoneNumber = string.Empty;
        DateOfBirth = DateTime.Now;
        CountryID = 0;
        ImagePath = null;
        Mode = enMode.AddNew;
    }
    //make this private so you force every one to make the object by using the find method

    protected clsPeople(int personID, string nationalNumber, string firstName, string secondName, string thirdName, string lastName,
        string email, string address, string phoneNumber,  DateTime dateOfBirth,
        int countryID, string imagePath , enGender genderType)
    {
        PersonID = personID;
        NationalNumber = nationalNumber;
        FirstName = firstName;
        SecondName = secondName;
        ThirdName = thirdName;
        LastName = lastName;
        Email = email;
        Address = address;
        PhoneNumber = phoneNumber;
        Gender =genderType;
        DateOfBirth = dateOfBirth;
        CountryID = countryID;
        ImagePath = imagePath;
        Mode = enMode.Update;
       
    }


    public  static clsPeople FindPersonByID(int PersonID)
    {
        string NationalNumber = string.Empty;
        string FirstName = string.Empty;
        string SecondName = string.Empty;
        string ThirdName = string.Empty;
        string LastName = string.Empty;
        string Email = string.Empty;
        string Address = string.Empty;
        string PhoneNumber = string.Empty;
        DateTime dateTime = DateTime.Now;
        byte GenderType = 0;
        int CountryID = 0;
        string ImagePath = string.Empty;



        if (clsPeopleDataConnetionLayer.GetPersonByID( PersonID, ref  NationalNumber, ref  FirstName, ref  SecondName, ref  ThirdName, ref  LastName, ref  GenderType,
      ref  Email, ref  PhoneNumber, ref  Address, ref  dateTime, ref  CountryID, ref  ImagePath))

            return new clsPeople(PersonID, NationalNumber, FirstName, SecondName, ThirdName, LastName, Email, Address, PhoneNumber,
              dateTime, CountryID, ImagePath, (enGender)GenderType);
        else
            return null;


    }


    public static clsPeople FindPersonByNationalNo(string NationalNumber)
    {
        int PersonID = 0;
        string FirstName = string.Empty;
        string SecondName = string.Empty;
        string ThirdName = string.Empty;
        string LastName = string.Empty;
        string Email = string.Empty;
        string Address = string.Empty;
        string PhoneNumber = string.Empty;
        DateTime dateTime = DateTime.Now;
        enGender Gender = enGender.Male;
        byte GenderType = (byte)Gender;
        int CountryID = 0;
        string ImagePath = string.Empty;



        if (clsPeopleDataConnetionLayer.GetPersonByNationalNo(ref PersonID,  NationalNumber, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref GenderType,
      ref Email, ref PhoneNumber, ref Address, ref dateTime, ref CountryID, ref ImagePath))

            return new clsPeople(PersonID, NationalNumber, FirstName, SecondName, ThirdName, LastName, Email, Address, PhoneNumber,
              dateTime, CountryID, ImagePath, Gender);
        else
            return null;


    }


    public static DataTable GetAllPeopleSelectedColumns()
    {
        return clsPeopleDataConnetionLayer.GetAllPeopleSelectedColumns();
    }
    public static DataTable GetAllPeople()
    {
        return clsPeopleDataConnetionLayer.GetAllPeople();
    }

    private bool AddNewPerson()
    {

         this.PersonID = clsPeopleDataConnetionLayer.InsertPersonAndReturnID(this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, (byte)this.Gender, this.Email, this.PhoneNumber, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

        return (this.PersonID != -1);
        
    }

    private bool UpdatePerson()
    {
        return clsPeopleDataConnetionLayer.UpdatePersonWhereID(this.PersonID, this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, (byte)this.Gender, this.Email, this.PhoneNumber, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

    }

   static public bool DeletePerson(int PersonID)
    {
        return clsPeopleDataConnetionLayer.DeletePersonByID(PersonID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (AddNewPerson())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            case enMode.Update:
                if (UpdatePerson())
                    return true;
                else
                    return false;

            default:
                return false;
        }




    }


    static public bool IsPersonExist(int PersonID)
    {
        return clsPeopleDataConnetionLayer.IsExistPerson(PersonID);
    }

    static public bool IsPersonExist(string NationalNumber)
    {
        return clsPeopleDataConnetionLayer.IsExistPerson(NationalNumber);
    }

    static public int GetPersonIDByNationalNumber(string NationalNumber) 
    {

        return clsPeopleDataConnetionLayer.GetPersonIDByNationalNumber(NationalNumber);
    }


    static public int GetPersonIDByDriverID(int DriverID)
    {
        return clsPeopleDataConnetionLayer.GetPersonIDByDriverID(DriverID);
    }
}

