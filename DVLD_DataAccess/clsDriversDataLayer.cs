using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsDriversDataConnetionLayer
{


    public static bool GetDriverByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
    {

        bool found = false;

        string Query = "Select * from Drivers Where DriverID = @ID";

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


                    DriverID = (int)Reader["DriverID"];
                    PersonID = (int)Reader["PersonID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];


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

    public static bool GetDriverByPersonID(ref int DriverID,  int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
    {

        bool found = false;

        string Query = "Select * from Drivers Where PersonID = @PersonID";


        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                SqlDataReader Reader = command.ExecuteReader();

                //we will not add here while becuase we want to return just one record

                if (Reader.Read())
                {
                    found = true;


                    DriverID = (int)Reader["DriverID"];
                    PersonID = (int)Reader["PersonID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];

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

    public static int InsertDriverAndReturnID( int PersonID,   int CreatedByUserID,   DateTime CreatedDate)
    {

        //if the Driver is added we return the new Driver ID and then add it the object in the 
        //Buisness logic

        string Query = @"INSERT INTO [dbo].[Drivers]
           ([PersonID]
           ,[CreatedByUserID]
           ,[CreatedDate])
 VALUES
           (@PersonID
           ,@CreatedByUserID
           ,@CreatedDate);
           select SCOPE_IDENTITY();";

        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate", CreatedDate);


                object result = command.ExecuteScalar();


                int DriverID = -1;
                if (result != DBNull.Value && int.TryParse(result.ToString(), out DriverID))
                {
                    return DriverID;
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

    public static bool UpdateDriverWhereID(  int DriverID, int PersonID,   int CreatedByUserID,   DateTime CreatedDate)
    {



        string Query = @"
UPDATE [dbo].[Drivers]
   SET
    [PersonID] =    @PersonID,
    [CreatedByUserID] = @CreatedByUserID, 
    [CreatedDate] = @CreatedDate
     WHERE DriverID = @DriverID;
";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate", CreatedDate);



                int rowsaffected = command.ExecuteNonQuery();

                return (rowsaffected == 0 ? false : true);



            }

        }


        catch (Exception ex)
        {
            return false;
        }



    }

    public static bool DeleteDriverByID(int ID)
    {



        string Query = @"
DELETE FROM Drivers
      WHERE DriverID = @ID

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

    public static DataTable GetAllDrivers()
    {

        string Query = "Select * from DriversView";

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

    public static bool IsExistDriver(int ID)
    {
        string Query = "select 1 from Drivers where DriverID = @ID;";



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

    public static int GetDriverIDByPersonID(int PersonID)
    {
        string Query = "select DriverID from Drivers where PersonID = @ID;";

        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", PersonID);

                object result = command.ExecuteScalar();
                int DriverID = -1;

                if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out DriverID))
                {
                    return DriverID;
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



    public static int GetDriverIDByLocalDrivingApplciaitonID(int LocalDrivingLicenseApplicationID)
    {

        string Query = "SELECT Found = Licenses.DriverID\r\nFROM     LocalDrivingLicenseApplications INNER JOIN\r\n    " +
            "  Licenses ON LocalDrivingLicenseApplications.ApplicationID = Licenses.ApplicationID\r\n " +
            "   where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


                object result = command.ExecuteScalar();


                int DriverID = -1;
                if (result != DBNull.Value && int.TryParse(result.ToString(), out DriverID))
                {
                    return DriverID;
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



}



