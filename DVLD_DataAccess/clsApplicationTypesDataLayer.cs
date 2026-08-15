using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsApplicationTypesDataLayer
{
    public static bool GetApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTitle, ref decimal ApplicationFees)
    {

        bool found = false;

        string Query = "Select * from ApplicationTypes Where ApplicationTypeID = @ID";


        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", ApplicationTypeID);

                SqlDataReader Reader = command.ExecuteReader();

                //we will not add here while becuase we want to return just one record

                if (Reader.Read())
                {
                    found = true;


                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    ApplicationTitle = (string)Reader["ApplicationTypeTitle"];
                    ApplicationFees = (decimal)Reader["ApplicationFees"];
                }
            }

        }


        catch (Exception ex)
        {
            //here you will not use console application in all time 
            //becuase it is class library so it could be used in more than one application
            //Console.WriteLine("Error :  " + ex.ToString());
            return false;
        }

        return found;

    }

    public static bool UpdateApplicationTypeWhereID(int ApplicationTypeID, string ApplicationTitle, decimal ApplicationFees)
    {



        string Query = @"
UPDATE [dbo].[ApplicationTypes]
   SET [ApplicationTypeTitle] =   @ApplicationTitle ,
    [ApplicationFees] =    @ApplicationFees
     WHERE ApplicationTypeID = @ApplicationTypeID;
";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationTitle", ApplicationTitle);
                command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

                int rowsaffected = command.ExecuteNonQuery();

                return (rowsaffected == 0 ? false : true);

            }

        }

        catch (Exception ex)
        {
            return false;
        }

    }


    public static bool GetApplicationTypeFeesByID(int ApplicationTypeID , ref decimal Fees)
    {

        bool found = false;

        string Query = "Select ApplicationFees from ApplicationTypes Where ApplicationTypeID = @ID";


        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", ApplicationTypeID);


                object result = command.ExecuteScalar();


                
                if (result != DBNull.Value && result != null && decimal.TryParse(result.ToString(), out Fees))
                {
                    Fees = (decimal)result;
                    return true;
                }

                else
                {
                    return false;
                }


            }

        }


        catch (Exception ex)
        {
            //here you will not use console application in all time 
            //becuase it is class library so it could be used in more than one application
            //Console.WriteLine("Error :  " + ex.ToString());
            return false;
        }

        return false;

    }

    public static DataTable GetAllApplicationTypes()
    {

        string Query = "Select * from ApplicationTypes";

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



