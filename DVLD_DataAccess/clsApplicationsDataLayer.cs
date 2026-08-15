using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationsDataLayer
    {

        public static bool GetApplicationByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref byte ApplicationStatus ,
            ref DateTime LastStatusDate,ref decimal PaidFees ,ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from Applications Where ApplicationID = @ID";


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


                        ApplicationID = (int)Reader["ApplicationID"];
                        ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                        ApplicationDate = (DateTime)Reader["ApplicationDate"];
                        ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                        ApplicationStatus = (byte)Reader["ApplicationStatus"];
                        LastStatusDate = (DateTime)Reader["LastStatusDate"];
                        PaidFees = (decimal)Reader["PaidFees"];
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

        public static bool GetApplicationByPersonID(ref int ApplicationID, int ApplicantPersonID, ref DateTime ApplicationDate,
             ref int ApplicationTypeID, ref byte ApplicationStatus,
             ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from Applications Where ApplicantPersonID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", ApplicantPersonID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        ApplicationID = (int)Reader["ApplicationID"];
                        ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                        ApplicationDate = (DateTime)Reader["ApplicationDate"];
                        ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                        ApplicationStatus = (byte)Reader["ApplicationStatus"];
                        LastStatusDate = (DateTime)Reader["LastStatusDate"];
                        PaidFees = (decimal)Reader["PaidFees"];
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


        public static int InsertApplicationAndReturnID( int ApplicantPersonID,   DateTime ApplicationDate,
               int ApplicationTypeID,   byte ApplicationStatus,
               DateTime LastStatusDate,   decimal PaidFees,   int CreatedByUserID)
        {

            //if the Application is added we return the new Application ID and then add it in the object in the 
            //Buisness logic

            string Query = @"INSERT INTO [dbo].[Applications]
           ([ApplicantPersonID]
           ,[ApplicationDate]
           ,[ApplicationTypeID]
           ,[ApplicationStatus]
            ,[LastStatusDate]
            ,[PaidFees]
            ,[CreatedByUserID])

 VALUES
           (@ApplicantPersonID
           ,@ApplicationDate
           ,@ApplicationTypeID
           ,@ApplicationStatus
            ,@LastStatusDate
            ,@PaidFees
            ,@CreatedByUserID);
           select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    object result = command.ExecuteScalar();


                    int ApplicationID = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out ApplicationID))
                    {
                        return ApplicationID;
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


        public static bool UpdateApplicationWhereID(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
               int ApplicationTypeID, byte ApplicationStatus,
               DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {



            string Query = @"
UPDATE [dbo].[Applications]
   SET 
    [ApplicantPersonID] =    @ApplicantPersonID,
    [ApplicationDate] =   @ApplicationDate, 
    [ApplicationTypeID] = @ApplicationTypeID,
[ApplicationStatus] =   @ApplicationStatus, 
[LastStatusDate] =   @LastStatusDate, 
[PaidFees] =   @PaidFees, 
[CreatedByUserID] =   @CreatedByUserID
     WHERE ApplicationID = @ApplicationID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
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

        
        public static bool DeleteApplicationByID(int ID)
        {



            string Query = @"
DELETE FROM Applications
      WHERE ApplicationID = @ID

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


        public static DataTable GetAllApplications()
        {

            string Query = "SELECT * From Applications";

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

        public static bool IsExistApplication(int ID)
        {
            string Query = "select 1 from Applications where ApplicationID = @ID;";



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


        public static bool IsExistApplicationByPersonID(int PersonID)
        {
            string Query = "select 1 from Applications where ApplicantPersonID  = @ID;";



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

        public static bool IsPersonHaveActiveApplication(int PersonID , int ApplicationTypeID)

            // this is a general method to check if the person have an active application in etihter international or detained and so on,
            //but the local license application is a special case becuase it contains the licese class id which is better to make the method
            //in the locallicense data layer
        {
            string Query = "select 1 from Applications where ApplicantPersonID  = @ID and ApplicationTypeID = @TypeID and ApplicationStatus = 1;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", PersonID);
                    command.Parameters.AddWithValue(" @TypeID", ApplicationTypeID);


                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }


        }

        public static bool UpdateApplicationStatus(int ApplicationID, byte Status)
        {



            string Query = @"
UPDATE [dbo].[Applications]
   SET [ApplicationStatus] = @ApplicationStatus 
     WHERE ApplicationID = @ApplicationID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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
