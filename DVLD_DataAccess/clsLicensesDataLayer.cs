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
    public class clsLicensesDataLayer
    {

        public static bool GetLicenseByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
             ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive,ref byte IssueReason,ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from Licenses Where LicenseID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", LicenseID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        LicenseID = (int)Reader["LicenseID"];
                        ApplicationID = (int)Reader["ApplicationID"];
                        DriverID = (int)Reader["DriverID"];
                        LicenseClassID = (int)Reader["LicenseClass"];
                        IssueDate = (DateTime)Reader["IssueDate"];
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                        Notes = Reader["Notes"] != DBNull.Value ? (string)Reader["Notes"] : string.Empty;
                        PaidFees = (decimal)Reader["PaidFees"];
                        IsActive = (bool)Reader["IsActive"];
                        IssueReason = (byte)Reader["IssueReason"];
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

        public static bool GetLicenseByApplicationID(ref int LicenseID, int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
             ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from Licenses Where ApplicationID = @ID";


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


                        LicenseID = (int)Reader["LicenseID"];
                        ApplicationID = (int)Reader["ApplicationID"];
                        DriverID = (int)Reader["DriverID"];
                        LicenseClassID = (int)Reader["LicenseClass"];
                        IssueDate = (DateTime)Reader["IssueDate"];
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];

                        Notes = Reader["Notes"] != DBNull.Value ? (string)Reader["Notes"] : string.Empty;

                        PaidFees = (decimal)Reader["PaidFees"];
                        IsActive = (bool)Reader["IsActive"];
                        IssueReason = (byte)Reader["IssueReason"];
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
  
        public static int InsertLicenseAndReturnID(int ApplicationID,  int DriverID, int LicenseClassID, DateTime IssueDate,
              DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason,int CreatedByUserID)
        {

            //if the License is added we return the new License ID and then add it in the object in the 
            //Buisness logic

            string Query = @"INSERT INTO [dbo].[Licenses]
           ([ApplicationID]
           ,[DriverID]
           ,[LicenseClass]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[Notes]
           ,[PaidFees]
           ,[IsActive]
           ,[IssueReason]
           ,[CreatedByUserID])
 VALUES
           (@ApplicationID
           ,@DriverID
           ,@LicenseClassID
           ,@IssueDate
            ,@ExpirationDate
            ,@Notes
            ,@PaidFees
            ,@IsActive
            ,@IssueReason
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
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



                    object result = command.ExecuteScalar();


                    int LicenseID = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out LicenseID))
                    {
                        return LicenseID;
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

        public static bool UpdateLicenseWhereID(int LicenseID,int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
              DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {



            string Query = @"
UPDATE [dbo].[Licenses]
   SET [ApplicationID] =   @ApplicationID ,
    [DriverID] =    @DriverID,
    [LicenseClass] =   @LicenseClassID, 
    [IssueDate] = @IssueDate,
    [ExpirationDate] = @ExpirationDate,
    [Notes] = @Notes,
    [PaidFees] = @PaidFees,
    [IsActive] = @IsActive,
    [IssueReason] = @IssueReason,
    [CreatedByUserID] = @CreatedByUserID

     WHERE LicenseID = @LicenseID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        public static bool DeleteLicenseByID(int ID)
        {

            string Query = @"
DELETE FROM Licenses
      WHERE LicenseID = @ID

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

        public static DataTable GetAllLicenses()
        {
            
            string Query = "SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive " +
            " FROM Licenses INNER JOIN " +
                 " LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID";

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

        public static DataTable GetAllDriverLicenses(int DriverID)
        {

            string Query = "SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, " +
                " Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive\r\nFROM  " +
                "   Licenses INNER JOIN\r\n   " +
                "  LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN\r\n      " +
                "            Drivers ON Drivers.DriverID = Licenses.DriverID" +
                "           where Drivers.DriverID = @DriverID ";

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

        public static bool IsExistLicense(int ID)
        {
            string Query = "select 1 from Licenses where LicenseID = @ID;";


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

        public static bool IsExistLicenseByApplicationID(int ID)
        {
            string Query = "select 1 from Licenses where ApplicationID = @ID;";


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

        public static bool DoesApplicantHaveActiveIssuedLicenseBeforeWithClassIDAndApplicantID(int ApplicantID , int LicenseClassID)
        {
            //check if applicant was a driver and issued license for same class
            string query = @"SELECT        Licenses.LicenseID 
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID 
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass  
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PersonID", ApplicantID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);


                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }



        }

        public static bool IsLicenseActive(int ID)
        {
            string Query = "select 1 from Licenses where LicenseID = @ID and IsActive = 1;";



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

        public static bool UpdateLicenseActiveMode(int LicenseID,bool Active)
        {
            string Query = "Update Licenses " +
                "           set IsActive = @Active" +
                "            where LicenseID = @ID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", LicenseID);
                    command.Parameters.AddWithValue("@Active", Active);

                    int result = command.ExecuteNonQuery();

                    return result != 0;
                }
            }

            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
