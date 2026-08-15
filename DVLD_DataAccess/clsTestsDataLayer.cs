using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsTestsDataLayer
    {
        public static bool GetTestsByID(int TestID, ref int TestAppointmentID, ref bool TestResult,
            ref string Notes , ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from Tests Where TestID = @ID";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", TestID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;

                        TestID = (int)Reader["TestID"];
                        TestAppointmentID = (int)Reader["TestAppointmentID"];
                        TestResult = (bool)Reader["TestResult"];

                        if (Reader["Notes"] != DBNull.Value)
                            Notes = (string)Reader["Notes"];
                        else
                            Notes = string.Empty;
                        
                        CreatedByUserID = (int)Reader["CreatedByUserID"];

                    }
                }

            }


            catch (Exception ex)
            {
                //here you will not use console Tests in all time 
                //becuase it is class library so it could be used in more than one Tests
                //Console.WriteLine("Error :  " + ex.ToString());
                found = false;
            }

            return found;

        }
        public static bool GetTestsByTestAppointmentID(ref int TestID, int TestAppointmentID, ref bool TestResult,
        ref string Notes, ref int CreatedByUserID)
        {

            bool found = false;

            string Query = "Select * from Tests Where TestAppointmentID = @ID";


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

                        TestID = (int)Reader["TestID"];
                        TestAppointmentID = (int)Reader["TestAppointmentID"];
                        TestResult = (bool)Reader["TestResult"];

                        if (Reader["Notes"] != DBNull.Value)
                            Notes = (string)Reader["Notes"];
                        else
                            Notes = string.Empty; 
                        
                        CreatedByUserID = (int)Reader["CreatedByUserID"];

                    }
                }

            }


            catch (Exception ex)
            {
                //here you will not use console Tests in all time 
                //becuase it is class library so it could be used in more than one Tests
                //Console.WriteLine("Error :  " + ex.ToString());
                found = false;
            }

            return found;

        }

        public static int InsertTestsAndReturnID(int TestAppointmentID, bool TestResult,
         string Notes,  int CreatedByUserID)
        {

            //if the Tests is added we return the new Tests ID and then add it in the object in the 
            //Buisness logic

            string Query = @"INSERT INTO [dbo].[Tests]
           ([TestAppointmentID]
           ,[TestResult]
           ,[Notes]
           ,[CreatedByUserID])

         VALUES
           (@TestAppointmentID
           ,@TestResult
           ,@Notes
           ,@CreatedByUserID);
           select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    command.Parameters.AddWithValue("@Notes",string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    object result = command.ExecuteScalar();


                    int TestID = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out TestID))
                    {
                        return TestID;
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

        public static bool UpdateTestsWhereID(int TestID, int TestAppointmentID, bool TestResult,
         string Notes, int CreatedByUserID)
        {


            string Query = @"
UPDATE [dbo].[Tests]
   SET 
    [TestAppointmentID] =    @TestAppointmentID,
    [TestResult] =   @TestResult, 
    [Notes] = @Notes, 
[CreatedByUserID] =   @CreatedByUserID
     WHERE TestID = @TestID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    command.Parameters.AddWithValue("@Notes", Notes);
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

        public static bool DeleteTestsByID(int ID)
        {



            string Query = @"
DELETE FROM Tests
      WHERE TestID = @ID

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

        public static DataTable GetAllTests()
        {

            string Query = "SELECT * From Tests " +
                "order by TestID desc";

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

        public static bool IsExistTests(int ID)
        {
            string Query = "select 1 from Tests where TestID = @ID;";



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

        public static byte GetLocalDrivingLicenseApplicationPassedTests(int LocalDrivingLicenseID)
        {

            string Query = " SELECT COUNT(*) AS PassedTestCount \r\n FROM dbo.Tests INNER JOIN \r\n  dbo.TestAppointments " +
                "ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID \r\n  " +
                " WHERE dbo.TestAppointments.LocalDrivingLicenseApplicationID = @ID AND dbo.Tests.TestResult = 1\r\n;";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", LocalDrivingLicenseID);

                    object result = command.ExecuteScalar();




                    byte PassedTests = 0;
                    if (result != DBNull.Value && byte.TryParse(result.ToString(), out PassedTests))
                    {
                        return PassedTests;
                    }

                    else
                    {
                        return 0;
                    }
                }
            }

            catch (Exception ex)
            {
                return 0;
            }




        }

        public static bool UpdateTestResult(int TestTypeID, byte TestResult,int TestAppointmentID)
        {

            string Query = @"Update Tests
                set TestResult = @Result
                from Tests
                  where TestTypeID = @TestType and TestAppointmentID = @AppointmentID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.Parameters.AddWithValue("@TestType", TestTypeID);
                    command.Parameters.AddWithValue("@Result", TestResult);
                    command.Parameters.AddWithValue("@AppointmentID", TestAppointmentID);


                    int rowsaffected = command.ExecuteNonQuery();

                    return (rowsaffected == 0 ? false : true);


                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateNotes(string Notes, int TestAppointmentID)
        {

            string Query = @"Update Tests
                set Notes = @Notes
                from Tests
                  where TestAppointmentID = @AppointmentID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@AppointmentID", TestAppointmentID);


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
