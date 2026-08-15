using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class clsApplicationTypes
{
    public int ApplicationTypeID { get; set; }
    public string ApplicationTypeTitle { get; set; }
    public decimal ApplicationTypeFees { get; set; }


    public clsApplicationTypes()
    {
        ApplicationTypeID = 0;
        ApplicationTypeTitle = string.Empty;
        ApplicationTypeFees = 0;

    }

    //make this private so you force every one to make the object by using the find method
    private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypTitle, decimal ApplicatonFees)
    {
        this.ApplicationTypeID = ApplicationTypeID;
       this.ApplicationTypeTitle = ApplicationTypTitle;
        this.ApplicationTypeFees = ApplicatonFees;

    }

    public static clsApplicationTypes Find(int ID)
    {
        string ApplicationTypeTitle = string.Empty;
        decimal ApplicationTypeFees = 0;

        if (clsApplicationTypesDataLayer.GetApplicationTypeByID(ID, ref ApplicationTypeTitle, ref ApplicationTypeFees))
            return new clsApplicationTypes(ID, ApplicationTypeTitle, ApplicationTypeFees);
        else
            return null;
    }
    public bool Update()
    {
         return clsApplicationTypesDataLayer.UpdateApplicationTypeWhereID(this.ApplicationTypeID,this.ApplicationTypeTitle, this.ApplicationTypeFees);
    }

    public static bool GetApplicationTypeFees(int ID , ref decimal Fees)
    {
        return clsApplicationTypesDataLayer.GetApplicationTypeFeesByID(ID , ref Fees);
    }
    public static DataTable GetAllApplicationType()
    {
        return clsApplicationTypesDataLayer.GetAllApplicationTypes();
    }
}

