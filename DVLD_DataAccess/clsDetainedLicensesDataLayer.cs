using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDetainedLicensesDataLayer
    {

        public static bool GetDetainedLicenseByID(int DetainID, ref int LicenseID, ref DateTime DetainDate,
            ref decimal FineFees, ref int CreatedByUserID,
            ref bool IsReleased,ref DateTime? ReleaseDate ,ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {

            bool found = false;

            string Query = "Select * from DetainedLicenses Where DetainID = @ID  order by DetainID desc";


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", DetainID);

                    SqlDataReader Reader = command.ExecuteReader();

                    //we will not add here while becuase we want to return just one record

                    if (Reader.Read())
                    {
                        found = true;


                        DetainID = (int)Reader["DetainID"];
                        LicenseID = (int)Reader["LicenseID"];
                        DetainDate = (DateTime)Reader["DetainDate"];
                        FineFees = (decimal)Reader["FineFees"];
                        IsReleased = (bool)Reader["IsReleased"];

                        ReleaseDate = (object)Reader["ReleaseDate"] == DBNull.Value ? null :
                          (DateTime?)Reader["ReleaseDate"];

                        ReleasedByUserID = Reader["ReleasedByUserID"] == DBNull.Value ? -1
                            : (int)Reader["ReleasedByUserID"];

                        CreatedByUserID = (int)Reader["CreatedByUserID"];

                        ReleaseApplicationID = Reader["ReleaseApplicationID"] == DBNull.Value ? -1:
                            (int)Reader["ReleaseApplicationID"];


                    }
                }

            }


            catch (Exception ex)
            {
                //here you will not use console DetainedLicense in all time 
                //becuase it is class library so it could be used in more than one DetainedLicense
                //Console.WriteLine("Error :  " + ex.ToString());
                found = false;
            }

            return found;

        }

        public static bool GetDetainedLicenseByLicenseID(ref int DetainID, int LicenseID, ref DateTime DetainDate,
            ref decimal FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime? ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {

            bool found = false;

            string Query = "Select * from DetainedLicenses Where LicenseID = @ID order by DetainID desc ";


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


                        DetainID = (int)Reader["DetainID"];
                        LicenseID = (int)Reader["LicenseID"];
                        DetainDate = (DateTime)Reader["DetainDate"];
                        FineFees = (decimal)Reader["FineFees"];
                        IsReleased = (bool)Reader["IsReleased"];

                        ReleaseDate = (object)Reader["ReleaseDate"] == DBNull.Value ? null :
                          (DateTime?)Reader["ReleaseDate"];

                        ReleasedByUserID = Reader["ReleasedByUserID"] == DBNull.Value ? -1
                            : (int)Reader["ReleasedByUserID"];

                        CreatedByUserID = (int)Reader["CreatedByUserID"];

                        ReleaseApplicationID = Reader["ReleaseApplicationID"] == DBNull.Value ? -1 :
                            (int)Reader["ReleaseApplicationID"];

                    }
                }

            }


            catch (Exception ex)
            {
                //here you will not use console DetainedLicense in all time 
                //becuase it is class library so it could be used in more than one DetainedLicense
                //Console.WriteLine("Error :  " + ex.ToString());
                found = false;
            }

            return found;

        }


        public static int InsertDetainedLicenseAndReturnID(int LicenseID,  DateTime DetainDate,
             decimal FineFees,  int CreatedByUserID,
             bool IsReleased,  DateTime? ReleaseDate,  int ReleasedByUserID,  int ReleaseApplicationID)
        {

            //if the DetainedLicense is added we return the new DetainedLicense ID and then add it in the object in the 
            //Buisness logic

            string Query = @"INSERT INTO [dbo].[DetainedLicenses]
           ([LicenseID]
           ,[DetainDate]
           ,[FineFees]
           ,[CreatedByUserID]
            ,[IsReleased]
            ,[ReleaseDate]
            ,[ReleasedByUserID]
            ,[ReleaseApplicationID])

 VALUES
           (@LicenseID
           ,@DetainDate
           ,@FineFees
           ,@CreatedByUserID
            ,@IsReleased
            ,@ReleaseDate
            ,@ReleasedByUserID
            ,@ReleaseApplicationID);
           select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);

                    command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate == null ?
                        DBNull.Value : (object)ReleaseDate);

                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID == -1 ?
                        DBNull.Value : (object)ReleasedByUserID);

                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID == -1 ?
                        DBNull.Value : (object)ReleaseApplicationID);


                    object result = command.ExecuteScalar();


                    int DetainedLicenseID = -1;
                    if (result != DBNull.Value && int.TryParse(result.ToString(), out DetainedLicenseID))
                    {
                        return DetainedLicenseID;
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


        public static bool UpdateDetainedLicenseWhereID(int DetainID , int LicenseID, DateTime DetainDate,
             decimal FineFees, int CreatedByUserID,
             bool IsReleased, DateTime? ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {



            string Query = @"
UPDATE [dbo].[DetainedLicenses]
   SET 
    [LicenseID] =    @LicenseID,
    [DetainDate] =   @DetainDate, 
    [FineFees] = @FineFees,
[CreatedByUserID] =   @CreatedByUserID, 
[IsReleased] =   @IsReleased, 
[ReleaseDate] =   @ReleaseDate, 
[ReleasedByUserID] =   @ReleasedByUserID,
[ReleaseApplicationID] =   @ReleaseApplicationID
     WHERE DetainID = @DetainID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);
                    command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                    int rowsaffected = command.ExecuteNonQuery();

                    return (rowsaffected == 0 ? false : true);


                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteDetainedLicenseByID(int ID)
        {



            string Query = @"
DELETE FROM DetainedLicenses
      WHERE DetainID = @ID

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

        public static DataTable GetAllDetainedLicenses()
        {

            string Query = "select * from DetainLicenseView  order by DetainID desc";

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



        public static bool IsLicenseDetained(int LicenseID)
        {


            string Query = "SELECT top 1 LicenseDetained = 1  From DetainedLicenses" +
                " where LicenseID = @ID and IsReleased = 0 order by DetainID desc";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", LicenseID);

                    object result = command.ExecuteScalar();



                    return result != null;
                }

            }


            catch (Exception ex)
            {
                //Console.WriteLine("Error :  " + ex.ToString());
                return false;
            }
        }




        public static bool ReleaseDetainedLicense(int DetainID,DateTime? ReleaseDate, 
            int ReleasedByUserID, int ReleaseApplicationID)
        {



            string Query = @"
UPDATE [dbo].[DetainedLicenses]
   SET 
[IsReleased] =   1, 
[ReleaseDate] =   @ReleaseDate, 
[ReleasedByUserID] =   @ReleasedByUserID,
[ReleaseApplicationID] =   @ReleaseApplicationID
     WHERE DetainID = @DetainID;
";



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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
