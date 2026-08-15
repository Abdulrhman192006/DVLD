using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsUsersDataLayer
    {

        public static bool GetUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {

            bool found = false;

            string Query = "Select * from Users Where UserID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", UserID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        UserID = (int)Reader["UserID"];
                        PersonID = (int)Reader["PersonID"];
                        UserName = (string)Reader["UserName"];
                        Password = (string)Reader["Password"];
                        IsActive = (bool)Reader["IsActive"];
                    }
                }

            }


            catch (Exception ex)
            {
                //here you will not use console application in all time 
                //becuase it is class library so it could be used in more than one application
                //Console.WriteLine("Error :  " + ex.ToString());
                found = false;
            }

            return found;

        }

        public static bool GetUserByUserName(ref int UserID, ref int PersonID,  string UserName, ref string Password,ref  bool IsActive)
        {

            bool found = false;

            string Query = "Select * from Users Where UserName = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", UserName);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        UserID = (int)Reader["UserID"];
                        PersonID = (int)Reader["PersonID"];
                        UserName = (string)Reader["UserName"];
                        Password = (string)Reader["Password"];
                        IsActive = (bool)Reader["IsActive"];
                    }
                }

            }


            catch (Exception ex)
            {
                //here you will not use console application in all time 
                //becuase it is class library so it could be used in more than one application
                //Console.WriteLine("Error :  " + ex.ToString());
                found = false;
            }

            return found;

        }

        public static bool GetUserByUserNameAndPassword(ref int UserID, ref int PersonID, string UserName,  string Password, ref bool IsActive)
        {

            bool found = false;

            string Query = "Select * from Users where UserName = @ID and Password = @Password";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        UserID = (int)Reader["UserID"];
                        PersonID = (int)Reader["PersonID"];
                        UserName = (string)Reader["UserName"];
                        Password = (string)Reader["Password"];
                        IsActive = (bool)Reader["IsActive"];
                    }
                }

            }


            catch (Exception ex)
            {
                //here you will not use console application in all time 
                //becuase it is class library so it could be used in more than one application
                //Console.WriteLine("Error :  " + ex.ToString());
                found = false;
            }

            return found;

        }



        public static int InsertUserAndReturnID( int PersonID,   string UserName,   string Password,   bool IsActive)
        {

            //if the User is added we return the new User ID and then add it in the object in the 
            //Buisness logic

            string Query = @"INSERT INTO [dbo].[Users]
           ([PersonID]
           ,[UserName]
           ,[Password]
           ,[IsActive])
 VALUES
           (@PersonID
           ,@UserName
           ,@Password
           ,@IsActive);
           select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    object result = command.ExecuteScalar();


                    int UserID = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out UserID))
                    {
                        return UserID;
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


        public static bool UpdateUserWhereID(int UserID,int PersonID, string UserName, string Password, bool IsActive)
        {



            string Query = @"
UPDATE [dbo].[Users]
   SET [PersonID] =   @PersonID ,
    [UserName] =    @UserName,
    [Password] =   @Password, 
    [IsActive] = @IsActive
     WHERE UserID = @UserID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);


                    int rowsaffected = command.ExecuteNonQuery();

                    return (rowsaffected == 0 ? false : true);


                }

            }


            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool DeleteUserByID(int ID)
        {



            string Query = @"
DELETE FROM Users
      WHERE UserID = @ID

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


        public static DataTable GetAllUsers()
        {

            string Query = "SELECT Users.UserID, Users.PersonID, Users.UserName,FullName = CONCAT(People.FirstName,' ', People.SecondName, ' ' ,People.ThirdName,' ' , People.LastName) ,Users.IsActive FROM  People INNER JOIN " +
                            "Users ON People.PersonID = Users.PersonID";

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

        public static bool IsExistUser(int ID)
        {
            string Query = "select 1 from Users where UserID = @ID;";



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


        public static bool IsExistUser(string UserName)
        {
            string Query = "select 1 from Users where UserName = @ID;";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", UserName);

                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }



        }



        public static bool IsUserActive(int ID)
        {
            string Query = "select 1 from Users where UserID = @ID and IsActive = 1;";



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

        public static bool IsUserExistWithUserNameAndPassword(string UserName , string password)
        {
            string Query = "select UserID from Users where UserName = @ID and Password = @Password";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", UserName);
                    command.Parameters.AddWithValue("@Password", password);


                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }



        }

        public static bool IsUserConncetedWithAPerson(int PersonID)
        {
            string Query = "select 1 from Users where PersonID = @ID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", PersonID);

                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }



        }

    }
}
