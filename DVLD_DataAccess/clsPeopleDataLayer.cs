using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsPeopleDataConnetionLayer
{




    public static bool GetPersonByID(int PersonID, ref string NationalNumber, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref byte Gender,
      ref string email, ref string phone, ref string address, ref DateTime dateOfBirth, ref int countryID, ref string imagePath)
    {

        bool found = false;

        string Query = "Select * from People Where PersonID = @ID";


        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", PersonID);

                SqlDataReader Reader = command.ExecuteReader();

                //we will not add here while becuase we want to return just one record

                if (Reader.Read())
                {
                    found = true;


                    PersonID = (int)Reader["PersonID"];
                    NationalNumber = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = string.Empty;

                    LastName = (string)Reader["LastName"];
                    Gender = (byte)Reader["Gender"];
                    phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        email = (string)Reader["Email"];
                    else
                        email = string.Empty;

                    countryID = (int)Reader["NationalityCountryID"];
                    address = (string)Reader["Address"];
                    dateOfBirth = (DateTime)Reader["DateOfBirth"];

                    if (Reader["ImagePath"] != DBNull.Value)

                    {
                        imagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        imagePath = string.Empty;
                    }






                }
            }

        }


        catch (Exception ex)
        {
            //here you will not use console application in all time 
            //becuase it is class library so it could be used in more than one application
            //Console.WriteLine("Error :  " + ex.ToString());
        }

        return found;

    }



    public static bool GetPersonByNationalNo(ref int PersonID, string NationalNumber, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref byte Gender,
  ref string email, ref string phone, ref string address, ref DateTime dateOfBirth, ref int countryID, ref string imagePath)
    {

        bool found = false;

        string Query = "Select * from People Where NationalNo = @NationalNumber";


        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

                SqlDataReader Reader = command.ExecuteReader();

                //we will not add here while becuase we want to return just one record

                if (Reader.Read())
                {
                    found = true;


                    PersonID = (int)Reader["PersonID"];
                    NationalNumber = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = string.Empty;

                    LastName = (string)Reader["LastName"];
                    Gender = (byte)Reader["Gender"];
                    phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        email = (string)Reader["Email"];
                    else
                        email = string.Empty;

                    countryID = (int)Reader["NationalityCountryID"];
                    address = (string)Reader["Address"];
                    dateOfBirth = (DateTime)Reader["DateOfBirth"];

                    if (Reader["ImagePath"] != DBNull.Value)

                    {
                        imagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        imagePath = null;
                    }






                }
            }

        }


        catch (Exception ex)
        {
            //here you will not use console application in all time 
            //becuase it is class library so it could be used in more than one application
            //Console.WriteLine("Error :  " + ex.ToString());
        }

        return found;

    }


    public static int InsertPersonAndReturnID(string NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName, byte Gender,
       string email, string phone, string address, DateTime dateOfBirth, int countryID, string imagePath)
    {

        //if the Person is added we return the new Person ID and then add it the object in the 
        //Buisness logic

        string Query = @"INSERT INTO [dbo].[People]
           ([NationalNo]
           ,[FirstName]
           ,[SecondName]
           ,[ThirdName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Gender]
           ,[Address]
           ,[Phone]
           ,[Email]
           ,[NationalityCountryID]
           ,[ImagePath])
 VALUES
           (@NationalNo
           ,@FirstName
           ,@SecondName
           ,@ThirdName 
           ,@LastName 
           ,@DateOfBirth
           ,@Gender
           ,@Address 
           ,@Phone
           ,@Email
           ,@NationalityCountryID
           ,@ImagePath);
           select SCOPE_IDENTITY();";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@NationalNo", NationalNumber);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);

                command.Parameters.AddWithValue("@ThirdName",
                    (string.IsNullOrWhiteSpace(ThirdName)) ? DBNull.Value : (object)ThirdName);

                command.Parameters.AddWithValue("@LastName", LastName);

                command.Parameters.AddWithValue("@Email",
                    (string.IsNullOrWhiteSpace(email)) ? DBNull.Value : (object)email);

                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@NationalityCountryID", countryID);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                command.Parameters.AddWithValue("@ImagePath",
                    (string.IsNullOrWhiteSpace(imagePath)) ? DBNull.Value : (object)imagePath);


                object result = command.ExecuteScalar();


                int PersonID = -1;
                if (result != DBNull.Value && int.TryParse(result.ToString(), out PersonID))
                {
                    return PersonID;
                }

                else
                {
                    return -1;
                }
            }

        }


        catch (Exception ex)
        {
            //Console.WriteLine("Error :  " + ex.ToString());
            return -1;
        }
    }


    public static bool UpdatePersonWhereID(int PersonID, string NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName, byte Gender,
       string email, string phone, string address, DateTime dateOfBirth, int countryID, string imagePath)
    {



        string Query = @"
   UPDATE [dbo].[People]
   SET [NationalNo] =   @NationalNo ,
    [FirstName] =    @FirstName,
    [SecondName] =   @SecondName, 
    [ThirdName] = @ThirdName,
    [LastName] = @LastName, 
    [DateOfBirth] = @DateOfBirth,
    [Gender] = @Gender, 
    [Address] = @Address, 
    [Phone] = @Phone, 
    [Email] = @Email, 
    [NationalityCountryID] = @NationalityCountryID,
    [ImagePath] = @ImagePath
     WHERE PersonID = @PersonID;
";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@NationalNo", NationalNumber);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);

                command.Parameters.AddWithValue("@ThirdName",
                    (string.IsNullOrWhiteSpace(ThirdName)) ? DBNull.Value : (object)ThirdName);

                command.Parameters.AddWithValue("@LastName", LastName);

                command.Parameters.AddWithValue("@Email",
                    (string.IsNullOrWhiteSpace(email)) ? DBNull.Value : (object)email);

                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@NationalityCountryID", countryID);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                command.Parameters.AddWithValue("@ImagePath",
                    (string.IsNullOrWhiteSpace(imagePath)) ? DBNull.Value : (object)imagePath);


                int rowsaffected = command.ExecuteNonQuery();

                return (rowsaffected == 0 ? false : true);



            }

        }


        catch (Exception ex)
        {
            return false;
        }



    }

    public static bool DeletePersonByID(int ID)
    {



        string Query = @"
DELETE FROM People
      WHERE PersonID = @ID

 ";

        int rowsaffected = 0;

        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", ID);


                rowsaffected = command.ExecuteNonQuery();

                return (rowsaffected != 0);

            }

        }


        catch (Exception ex)
        {

            return false;

        }



    }


    public static DataTable GetAllPeopleSelectedColumns()
    {

        string Query = "Select * from PeopleManagmentInfo";

        DataTable dt = new DataTable();

        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Query, connection);

                SqlDataReader Reader = command.ExecuteReader();

                dt.Load(Reader);
            }
        }

        catch (Exception ex)
        {
            return null;
        }

        return dt;
    }
    public static DataTable GetAllPeople()
    {

        string Query = "Select * from People";

        DataTable dt = new DataTable();

        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Query, connection);

                SqlDataReader Reader = command.ExecuteReader();

                dt.Load(Reader);
            }
        }

        catch (Exception ex)
        {
            return null;
        }

        return dt;
    }

    public static bool IsExistPerson(int ID)
    {
        string Query = "select 1 from People where PersonID = @ID;";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                object result = command.ExecuteScalar();

                return result != null;
            }
        }

        catch (Exception ex)
        {
            return false;
        }



    }


    public static bool IsExistPerson(string NationalNumber)
    {
        string Query = "select 1 from People where NationalNo = @ID;";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", NationalNumber);

                object result = command.ExecuteScalar();

                return result != null;
            }
        }

        catch (Exception ex)
        {
            return false;
        }
    }



    public static int GetPersonIDByNationalNumber(string NationalNumber)
    {
        string Query = "\r\nSELECT PersonID\r\n FROM    " +
            " People\r\nwhere NationalNo = @NationalNo";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@NationalNo", NationalNumber);

                object result = command.ExecuteScalar();


                int PersonID = -1;
                if (result != DBNull.Value && int.TryParse(result.ToString(), out PersonID))
                {
                    return PersonID;
                }

                else
                {
                    return -1;
                }
            }
        }

        catch (Exception ex)
        {
            return -1;
        }



    }




    public static int GetPersonIDByDriverID(int DriverID)
    {
        string Query = "select PersonID from Drivers where DriverID = @ID;";

        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", DriverID);

                object result = command.ExecuteScalar();
                int PersonID = -1;

                if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out PersonID))
                {
                    return PersonID;
                }

                else
                {
                    return -1;
                }

            }
        }

        catch (Exception ex)
        {
            return -1;
        }



    }

}



