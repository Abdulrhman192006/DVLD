using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsCountriesDataAccessLayer
{
    public static bool GetCountryByID(int CountryID, ref string CountryName)
    {

        bool found = false;

        string Query = "Select * from Countries Where CountryID = @ID";


        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", CountryID);

                SqlDataReader Reader = command.ExecuteReader();

                //we will not add here while becuase we want to return just one record

                if (Reader.Read())
                {
                    found = true;


                    CountryID = (int)Reader["CountryID"];
                    CountryName = (string)Reader["CountryName"];
                   





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

    public static DataTable GetAllCountry()
    {

        string Query = "Select * from Countries";

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



