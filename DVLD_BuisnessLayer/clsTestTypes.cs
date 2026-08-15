using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class clsTestTypes
{
    public enum TestType { VisionTest = 1, WrittenTest = 2, PracticalTest = 3 }

    public TestType ID { get; set; }
    public string TestTypeTitle { get; set; }
    public string TestTypeDescription { get; set; }
    public decimal TestTypeFees { get; set; }


    
    public clsTestTypes()
    {
        ID = TestType.VisionTest;
        TestTypeTitle = string.Empty;
        TestTypeDescription = string.Empty;
        TestTypeFees = 0;

    }

    public clsTestTypes(TestType TestTypeID, string TestTypTitle,string TestTypeDescription, decimal ApplicatonFees)
    {
        this.ID = TestTypeID;
        this.TestTypeTitle = TestTypTitle;
        this.TestTypeDescription = TestTypeDescription;
        this.TestTypeFees = ApplicatonFees;

    }

    public static clsTestTypes Find(TestType ID)
    {
        string TestTypeTitle = string.Empty;
        decimal TestTypeFees = 0;
        string TestTypeDescription = string.Empty ;

        if (clsTestTypesDataLayer.GetTestTypeByID((int)(ID), ref TestTypeTitle,ref TestTypeDescription, ref TestTypeFees))
            return new clsTestTypes(ID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        else
            return null;
    }
    public bool Update()
    {
        return clsTestTypesDataLayer.UpdateTestTypeWhereID((int)this.ID, this.TestTypeTitle, TestTypeDescription, this.TestTypeFees);
    }

    public static DataTable GetAllTestType()
    {
        return clsTestTypesDataLayer.GetAllTestTypes();
    }
}

