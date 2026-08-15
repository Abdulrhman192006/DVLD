using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsTestTypesDataLayer
{
    public static bool GetTestTypeByID(int TestTypeID, ref string TestTitle,ref string TestTypeDescription ,ref decimal TestTypeFees)
    {

        bool found = false;

        string Query = "Select * from TestTypes Where TestTypeID = @ID";


        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", TestTypeID);

                SqlDataReader Reader = command.ExecuteReader();

                //we will not add here while becuase we want to return just one record

                if (Reader.Read())
                {
                    found = true;


                    TestTypeID = (int)Reader["TestTypeID"];
                    TestTitle = (string)Reader["TestTypeTitle"];
                    TestTypeDescription = (string)Reader["TestTypeDescription"];
                    TestTypeFees = (decimal)Reader["TestTypeFees"];
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

    public static bool UpdateTestTypeWhereID(int TestTypeID, string TestTitle, string TestTypeDescription, decimal TestTypeFees)
    {



        string Query = @"
UPDATE [dbo].[TestTypes]
   SET [TestTypeTitle] =   @TestTitle ,
        [TestTypeDescription] = @TestTypeDescription,
    [TestTypeFees] =  @TestTypeFees
     WHERE TestTypeID = @TestTypeID;
";



        try
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@TestTitle", TestTitle);
                command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

                int rowsaffected = command.ExecuteNonQuery();

                return (rowsaffected == 0 ? false : true);

            }

        }

        catch (Exception ex)
        {
            return false;
        }

    }

    public static DataTable GetAllTestTypes()
    {

        string Query = "Select * from TestTypes";

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



