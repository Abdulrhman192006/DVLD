using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsInternationalInternationalLicensesDataLayer
    {

        public static bool GetInternationalLicenseByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int LocalLicenseID, ref DateTime IssueDate,
             ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from InternationalLicenses Where InternationalLicenseID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", InternationalLicenseID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        InternationalLicenseID = (int)Reader["InternationalLicenseID"];
                        ApplicationID = (int)Reader["ApplicationID"];
                        DriverID = (int)Reader["DriverID"];
                        IssueDate = (DateTime)Reader["IssueDate"];
                        LocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                        IsActive = (bool)Reader["IsActive"];
                        CreatedByUserID = (int)Reader["CreatedByUserID"];

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

        public static bool GetInternationalLicenseByApplicationID(ref int InternationalLicenseID,  int ApplicationID, ref int DriverID, ref int LocalLicenseID, ref DateTime IssueDate,
             ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from InternationalLicenses Where ApplicationID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", ApplicationID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        InternationalLicenseID = (int)Reader["InternationalLicenseID"];
                        ApplicationID = (int)Reader["ApplicationID"];
                        DriverID = (int)Reader["DriverID"];
                        IssueDate = (DateTime)Reader["IssueDate"];
                        LocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                        IsActive = (bool)Reader["IsActive"];
                        CreatedByUserID = (int)Reader["CreatedByUserID"];
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

        public static bool GetInternationalLicenseByDriverID(ref int InternationalLicenseID, ref int ApplicationID, int DriverID, ref int LocalLicenseID, ref DateTime IssueDate,
     ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from InternationalLicenses Where DriverID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", DriverID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        InternationalLicenseID = (int)Reader["InternationalLicenseID"];
                        ApplicationID = (int)Reader["ApplicationID"];
                        DriverID = (int)Reader["DriverID"];
                        IssueDate = (DateTime)Reader["IssueDate"];
                        LocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                        IsActive = (bool)Reader["IsActive"];
                        CreatedByUserID = (int)Reader["CreatedByUserID"];
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


        public static int InsertInternationalLicenseAndReturnID(int ApplicationID, int DriverID, int LocalLicenseID,   DateTime IssueDate,
       DateTime ExpirationDate,   bool IsActive,   int CreatedByUserID)
        {

            //if the InternationalLicense is added we return the new InternationalLicense ID and then add it in the object in the 
            //Buisness logic

            string Query = @"


                Update InternationalLicenses 
                set IsActive = 0
                where DriverID = @DriverID;


INSERT INTO [dbo].[InternationalLicenses]
           ([ApplicationID]
           ,[DriverID]
           ,[IssuedUsingLocalLicenseID]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[IsActive]
           ,[CreatedByUserID])
 VALUES
           (@ApplicationID
           ,@DriverID
           ,@IssuedUsingLocalLicenseID
           ,@IssueDate
            ,@ExpirationDate
            ,@IsActive
            ,@CreatedByUserID);
           select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



                    object result = command.ExecuteScalar();


                    int InternationalLicenseID = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out InternationalLicenseID))
                    {
                        return InternationalLicenseID;
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

        public static bool UpdateInternationalLicenseWhereID(  int InternationalLicenseID,   int ApplicationID, int DriverID,   int LocalLicenseID,   DateTime IssueDate,
       DateTime ExpirationDate,   bool IsActive,   int CreatedByUserID)
        {



            string Query = @"
UPDATE [dbo].[InternationalInternationalLicenses]
   SET [ApplicationID] =   @ApplicationID ,
    [DriverID] =    @DriverID,
    [IssuedUsingLocalLicenseID] =   @IssuedUsingLocalLicenseID, 
    [IssueDate] = @IssueDate,
    [ExpirationDate] = @ExpirationDate,
    [IsActive] = @IsActive,
    [CreatedByUserID] = @CreatedByUserID

     WHERE InternationalLicenseID = @InternationalLicenseID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    int rowsaffected = command.ExecuteNonQuery();

                    return (rowsaffected == 0 ? false : true);


                }

            }


            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool DeleteInternationalLicenseByID(int ID)
        {

            string Query = @"
DELETE FROM InternationalInternationalLicenses
      WHERE InternationalLicenseID = @ID

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


        public static DataTable GetAllInternationalInternationalLicenses()
        {

            string Query = "SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive\r\n " +
                "         FROM  InternationalLicenses";

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

        public static DataTable GetAllDriverInternationalInternationalLicenses(int DriverID)
        {

            string Query = "SELECT InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive\r\n " +
                "FROM     InternationalLicenses where DriverID = @DriverID";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.Parameters.AddWithValue("@DriverID", DriverID);

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

        public static DataTable GetAllDriverInternationalInternationalLicensesByPersonID(int PersonID)
        {

            string Query = "SELECT InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive\r\n " +
                "FROM     InternationalLicenses where PersonID = @PersonID";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.Parameters.AddWithValue("@PersonID", PersonID);

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



        public static bool IsExistInternationalLicense(int ID)
        {
            string Query = "select 1 from InternationalLicenses where InternationalLicenseID = @ID  and  " +
                "     GetDate() between IssueDate and ExpirationDate;";


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


        public static bool IsExistInternationalLicenseByLicenseID(int ID)
        {
            string Query = "select 1 from InternationalLicenses where IssuedUsingLocalLicenseID = @ID and " +
                "       GetDate() between IssueDate and ExpirationDate;";


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


    }
}
