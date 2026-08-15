using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class clsCountries
{

    public int CountryID { get; set; }
   
    public string CountryName { get; set; }

    public clsCountries()
    {
        CountryID = 0;
        CountryName = string.Empty;
        
    }

    public clsCountries(int countryID, string countryName)
    {
        CountryID = countryID;
        CountryName = countryName;
      
    }


    public static clsCountries FindCountryByID(int CountryID)
    {
        string CountryName = string.Empty;
       



        if (clsCountriesDataAccessLayer.GetCountryByID(CountryID, ref CountryName))

            return new clsCountries(CountryID, CountryName);
        else
            return null;


    }

    public static DataTable GetAllCountry()
    {
        return clsCountriesDataAccessLayer.GetAllCountry();
    }
}

