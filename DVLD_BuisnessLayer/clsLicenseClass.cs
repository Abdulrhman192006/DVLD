using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class clsLicenseClasses
{
    public int LicenseClassID { get; set; }
    public string ClassName { get; set; }
    public string ClassDescription { get; set; }
    public byte MinimumAllowedAge { get; set; }
    public byte DefaultValidityLength { get; set; }
    public decimal ClassFees { get; set; }

    public clsLicenseClasses(int licenseClassID, string className, string classDescription, byte minimumAllowedAge, byte defaultValidityLength, decimal classFees)
    {
        LicenseClassID = licenseClassID;
        ClassName = className;
        ClassDescription = classDescription;
        MinimumAllowedAge = minimumAllowedAge;
        DefaultValidityLength = defaultValidityLength;
        ClassFees = classFees;
    }

    public clsLicenseClasses()
    {
        LicenseClassID = -1;
        ClassName = string.Empty;
        ClassDescription = string.Empty;
        MinimumAllowedAge = 0;
        DefaultValidityLength = 0;
        ClassFees = 0;
    }

    public static clsLicenseClasses Find(int LicenseClassID)
    {
        string ClassName = string.Empty;
        string ClassDescription = string.Empty;
        byte MinimumAllowedAge = 0;
        byte DefaultValidityLength = 0;
        decimal ClassFees = 0;


        if (clsLicenseClassesDataLayer.GetLicenseClassByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge,
          ref DefaultValidityLength,ref ClassFees))
            return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge,
                DefaultValidityLength, ClassFees);
        else
            return null;
    }
    public bool Update()
    {
        return clsLicenseClassesDataLayer.UpdateLicenseClassWhereID(this.LicenseClassID, this.ClassName, this.ClassDescription,
            this.MinimumAllowedAge,this.DefaultValidityLength,this.ClassFees);
    }

    public static DataTable GetAllLicenseClass()
    {
        return clsLicenseClassesDataLayer.GetAllLicenseClasses();
    }
}

