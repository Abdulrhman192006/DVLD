using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentsDataLayer
    {

        public static bool GetTestAppointmentByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID,
            ref DateTime AppointmentDate, ref decimal PaidFees,
            ref int RetakeTestApplicationID, ref int CreatedByUserID,ref bool IsLocked)
        {

            bool found = false;

            string Query = "Select * from TestAppointments Where TestAppointmentID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", TestAppointmentID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        TestAppointmentID = (int)Reader["TestAppointmentID"];
                        TestTypeID = (int)Reader["TestTypeID"];
                        LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                        AppointmentDate = (DateTime)Reader["AppointmentDate"];

                        RetakeTestApplicationID =  (object)Reader["RetakeTestApplicationID"] == DBNull.Value ? -1:
                            (int)Reader["RetakeTestApplicationID"];

                        IsLocked = (bool)Reader["IsLocked"];
                        PaidFees = (decimal)Reader["PaidFees"];
                        CreatedByUserID = (int)Reader["CreatedByUserID"];

                    }
                }

            }


            catch (Exception ex)
            {
                //here you will not use console TestAppointment in all time 
                //becuase it is class library so it could be used in more than one TestAppointment
                //Console.WriteLine("Error :  " + ex.ToString());
                found = false;
            }

            return found;

        }


        public static int InsertTestAppointmentAndReturnID(  int TestTypeID,   int LocalDrivingLicenseApplicationID,
              DateTime AppointmentDate,   decimal PaidFees,
            int RetakeTestApplicationID, int CreatedByUserID, bool IsLocked)
        {

            //if the TestAppointment is added we return the new TestAppointment ID and then add it in the object in the 
            //Buisness logic

            string Query = @"INSERT INTO [dbo].[TestAppointments]
           ([TestTypeID]
           ,[LocalDrivingLicenseApplicationID]
           ,[AppointmentDate]
           ,[PaidFees]
            ,[RetakeTestApplicationID]
            ,[CreatedByUserID]
            ,[IsLocked])

 VALUES
           (@TestTypeID
           ,@LocalDrivingLicenseApplicationID
           ,@AppointmentDate
           ,@PaidFees
            ,@RetakeTestApplicationID
            ,@CreatedByUserID
            ,@IsLocked);
           select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);


                    object result = command.ExecuteScalar();


                    int TestAppointmentID = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out TestAppointmentID))
                    {
                        return TestAppointmentID;
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


        public static bool UpdateTestAppointmentWhereID(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
              DateTime AppointmentDate, decimal PaidFees,
            int RetakeTestApplicationID, int CreatedByUserID, bool IsLocked)
        {



            string Query = @"
UPDATE [dbo].[TestAppointments]
   SET 
    [TestTypeID] =    @TestTypeID,
    [LocalDrivingLicenseApplicationID] =   @LocalDrivingLicenseApplicationID, 
    [IsLocked] = @IsLocked,
[AppointmentDate] =   @AppointmentDate, 
[RetakeTestApplicationID] =   @RetakeTestApplicationID, 
[PaidFees] =   @PaidFees, 
[CreatedByUserID] =   @CreatedByUserID
     WHERE TestAppointmentID = @TestAppointmentID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);

                    int rowsaffected = command.ExecuteNonQuery();

                    return (rowsaffected == 0 ? false : true);


                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool DeleteTestAppointmentByID(int ID)
        {



            string Query = @"
DELETE FROM TestAppointments
      WHERE TestAppointmentID = @ID

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


        public static DataTable GetAllTestAppointments()
        {

            string Query = "SELECT * From TestAppointments " +
                "order by TestAppointmentID desc";

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

        public static DataTable GetTestAppointmentByTestTypeID(int TestTypeID , int LocalLicenseID)
        {

            string Query = "SELECT * From TestAppointments " +
                "where TestTypeID = @TestType and LocalDrivingLicenseApplicationID = @LocalID " +
                " order by TestAppointmentID desc";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@LocalID", LocalLicenseID);
                    command.Parameters.AddWithValue("@TestType", TestTypeID);


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

        public static bool IsExistTestAppointment(int ID)
        {
            string Query = "select 1 from TestAppointments where TestAppointmentID = @ID;";



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

        public static bool IsTestAppointmentLocked()
        {
            string Query = "select 1 from TestAppointments where IsLocked = 1;";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }



        }

        public static bool LockTestAppointment(int TestAppointmentID)
        {



            string Query = @"
UPDATE [dbo].[TestAppointments]
   SET [IsLocked] = 1 
     WHERE TestAppointmentID = @TestAppointmentID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    int rowsaffected = command.ExecuteNonQuery();

                    return (rowsaffected == 0 ? false : true);


                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsApplicantHaveFailedTest(int TestTypeID, int TestLocalDrivingLicenseApplicationID)
        {
            //Check if Applicant have failed the same test when issuing a new test for the same test type

            string Query = "SELECT 1 \r\nFROM   TestAppointments INNER JOIN\r\n   " +
                "Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n  " +
                "where TestAppointments.LocalDrivingLicenseApplicationID = @LocalID and TestAppointments.TestTypeID = @TypeID\r\n  and Tests.TestResult = 0;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.Parameters.AddWithValue("@LocalID", TestLocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TypeID", TestTypeID);


                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }



        }

        public static int GetTestTrials(int TestTypeID, int TestLocalDrivingLicenseApplicationID , byte TestResult)
        {

            string Query = "SELECT count(*) \r\nFROM   TestAppointments INNER JOIN\r\n   " +
                "Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n  " +
                "where TestAppointments.LocalDrivingLicenseApplicationID = @LocalID and TestAppointments.TestTypeID = @TypeID\r\n  and Tests.TestResult = @Result;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.Parameters.AddWithValue("@LocalID", TestLocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TypeID", TestTypeID);
                    command.Parameters.AddWithValue("@Result", TestResult);



                    object result = command.ExecuteScalar();


                    int Trials = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out Trials))
                    {
                        return Trials;
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

        public static bool IsApplicantHaveAnAciveAppointment(int TestLocalDrivingLicenseApplicationID , int TestTypeID)
        {
            string Query = "SELECT Found = 1 " +
                " FROM TestAppointments " +
                " where LocalDrivingLicenseApplicationID = @LocalID and IsLocked = 0 and TestTypeID = @TypeID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.Parameters.AddWithValue("@LocalID", TestLocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TypeID", TestTypeID);


                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }

            catch (Exception ex)
            {
                return false;
            }


        }


        public static bool IsApplicantHavePassedTestByTestType(int TestLocalDrivingLicenseApplicationID, int TestTypeID)
        {

            //if the query returns 1 then he passed , if 0 then he failed
            string Query = @"   SELECT top 1 TestResult 
                     FROM LocalDrivingLicenseApplications INNER JOIN
                          TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", TestLocalDrivingLicenseApplicationID);



                    object result = command.ExecuteScalar();


                    bool Result = false;
                    if (result != DBNull.Value && result != null && bool.TryParse(result.ToString(), out Result))
                    {
                        return Result;
                    }

                    else
                    {
                        return false;
                    }
                }

            }


            catch (Exception ex)
            {
                //Console.WriteLine("Error :  " + ex.ToString());
                return false;
            }

        }


        public static int GetPassedTestsTotal( int TestLocalDrivingLicenseApplicationID)
        {

            string Query = "     SELECT PassedTests = Count(*) " +
                            " FROM Tests INNER JOIN " + 
                 " TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID and Tests.TestResult = 1 " +
                  " where TestAppointments.LocalDrivingLicenseApplicationID = @LocalID; ";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.Parameters.AddWithValue("@LocalID", TestLocalDrivingLicenseApplicationID);

                    object result = command.ExecuteScalar();


                    int Trials = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out Trials))
                    {
                        return Trials;
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
}
