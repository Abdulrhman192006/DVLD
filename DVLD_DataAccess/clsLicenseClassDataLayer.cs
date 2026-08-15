using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsLicenseClassesDataLayer
{
    public static bool GetLicenseClassByID(int LisenseClassID, ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge
        ,ref byte DefaultValidityLength ,ref decimal ClassFees)
    {

        bool found = false;

        string Query = "Select * from LicenseClasses Where LicenseClassID = @ID";


        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", LisenseClassID);

                SqlDataReader Reader = command.ExecuteReader();

                //we will not add here while becuase we want to return just one record

                if (Reader.Read())
                {
                    found = true;

                    LisenseClassID = (int)Reader["LicenseClassID"];
                    ClassName = (string)Reader["ClassName"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinimumAllowedAge = (byte)Reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)Reader["DefaultValidityLength"];
                    ClassFees = (decimal)Reader["ClassFees"];

                }
            }

        }


        catch (Exception ex)
        {
            //here you will not use console Test in all time 
            //becuase it is class library so it could be used in more than one Test
            //Console.WriteLine("Error :  " + ex.ToString());
            return false;
        }

        return found;

    }

    public static bool UpdateLicenseClassWhereID(int LisenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge
        ,  byte DefaultValidityLength, decimal ClassFees)
    {



        string Query = @"
         UPDATE [dbo].[LicenseClasses]
         SET [ClassName] =   @ClassName ,
        [ClassDescription] = @ClassDescription,
        [MinimumAllowedAge] =  @MinimumAllowedAge,
 [DefaultValidityLength] =  @DefaultValidityLength,
 [ClassFees] =  @ClassFees
        WHERE LicenseClassID = @LicenseClassID;
";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@LicenseClassID", LisenseClassID);
                command.Parameters.AddWithValue("@ClassName", ClassName);
                command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                command.Parameters.AddWithValue("@ClassFees", ClassFees);

                int rowsaffected = command.ExecuteNonQuery();

                return (rowsaffected == 0 ? false : true);

            }

        }

        catch (Exception ex)
        {
            return false;
        }

    }

    public static DataTable GetAllLicenseClasses()
    {

        string Query = "Select * from LicenseClasses";

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

}



