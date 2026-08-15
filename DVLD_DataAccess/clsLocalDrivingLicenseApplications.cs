using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationsDataLayer
    {

        public static bool GetLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {

            bool found = false;

            string Query = "Select * from LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", LocalDrivingLicenseApplicationID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;

                        LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                        ApplicationID = (int)Reader["ApplicationID"];
                        LicenseClassID = (int)Reader["LicenseClassID"];

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

        public static int GetApplicationIDByLocalApplicationID(int LocalApplicationID)
        {



            string Query = @" select ApplicationID from LocalDrivingLicenseApplications " +
           "where LocalDrivingLicenseApplicationID = @ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", LocalApplicationID);

                    object result = command.ExecuteScalar();


                    if (result != DBNull.Value && int.TryParse(result.ToString(), out LocalApplicationID))
                    {
                        return LocalApplicationID;
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

        public static bool GetLocalDrivingLicenseApplicationByApplicationID(ref int LocalDrivingLicenseApplicationID, int ApplicationID, ref int LicenseClassID)
        {

            bool found = false;

            string Query = "Select * from LocalDrivingLicenseApplications Where ApplicationID = @ID";


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

                        LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                        ApplicationID = (int)Reader["ApplicationID"];
                        LicenseClassID = (int)Reader["LicenseClassID"];
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
        public static int InsertLocalDrivingLicenseApplicationAndReturnID(int ApplicationID, int LicenseClassID)
        {

            //if the LocalDrivingLicenseApplication is added we return the new LocalDrivingLicenseApplication ID and then add it in the object in the 
            //Buisness logic

            string Query = @"INSERT INTO [dbo].[LocalDrivingLicenseApplications]
           ([ApplicationID]
           ,[LicenseClassID])
 VALUES
           (@ApplicationID
           ,@LicenseClassID);
           select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    object result = command.ExecuteScalar();


                    int LocalDrivingLicenseApplicationID = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out LocalDrivingLicenseApplicationID))
                    {
                        return LocalDrivingLicenseApplicationID;
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

        public static bool UpdateLocalDrivingLicenseApplicationWhereID(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {



            string Query = @"
   UPDATE [dbo].[LocalDrivingLicenseApplications]
   SET [ApplicationID] =   @ApplicationID ,
   [LicenseClassID] =    @LicenseClassID
    WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    int rowsaffected = command.ExecuteNonQuery();

                    return (rowsaffected == 0 ? false : true);


                }

            }

            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool DeleteLocalDrivingLicenseApplicationByID(int ID)
        {



            string Query = @"
DELETE FROM LocalDrivingLicenseApplications
      WHERE LocalDrivingLicenseApplicationID = @ID

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


        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            //This query will gets all the info of the Local Application + The PassedTestsResult 
            string Query = "Select * from LocalDrivingLicenseApplication_View";

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

        public static bool IsApplicantHaveLocalDrivingLicenseApplicationWithStatusAndLicenseClassID(int PersonID, int LicenseClassID,byte Status)
        {
            string Query = "SELECT 1 " +                                        
                   " FROM  Applications INNER JOIN\n" + 
                 "LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID\n" +
                  "where Applications.ApplicantPersonID = @ID and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID and Applications.ApplicationStatus = @Status";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@Status", Status);


                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }



        }

        public static bool IsLocalDrivingLicenseApplicationStatus(int ID , byte status)
        {
            string Query = " select 1 from LocalDrivingLicenseApplications \r\n " +
                " join Applications on Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID\r\n\r\n     " +
                " where LocalDrivingLicenseApplicationID = @ID and ApplicationStatus = @status";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@status", status);


                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }



        }

        public static bool GetLocalDrivingLicenseApplicationStatus(string ID , byte status)
        {
            string Query = " select ApplicationStatus from LocalDrivingLicenseApplications \r\n " +
        " join Applications on Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID\r\n\r\n     " +
        " where LocalDrivingLicenseApplicationID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", ID);

                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && byte.TryParse(result.ToString(), out status))
                    {
                        return result != null;
                    }

                    else
                    {
                        return false;
                    }

                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateApplicationStatus(int ID, byte Status)
        {



            string Query = @"Update Applications
set Applications.ApplicationStatus = @ApplicationStatus
from LocalDrivingLicenseApplications INNER JOIN
                  Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                  where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @ApplicationID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", ID);
                    command.Parameters.AddWithValue("@ApplicationStatus", Status);

                    int rowsaffected = command.ExecuteNonQuery();

                    return (rowsaffected == 0 ? false : true);


                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
