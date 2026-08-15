using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.LocalDrivingLicense
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;


        clsLocalDrivingLicenseApplications _LocalDrivingLicense;
        int _LocalDrivingLicenseID = -1;

        enum enMode
        {
            Add,
            Edit
        }

        enMode Mode;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            Mode = enMode.Add;

        }
        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            Mode = enMode.Edit;
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
        }


        private void _RefershLicenseClassComboBox()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClass();
            if (dt == null)
            {
                MessageBox.Show("Error in loading License Class");
                return;
            }
            cbLicenseClass.DataSource = dt;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
            
            
        }


       private void  _LoadLocalLicenseApplicationData()
        {

            cntrlPersonCardWithFilter2.LoadPerson(_LocalDrivingLicense.ApplicantPersonID);

            lbLocalAppID.Text = _LocalDrivingLicenseID.ToString();
            lbAppDate.Text = _LocalDrivingLicense.ApplicationDate.ToShortDateString();
            
            lbMadeByUser.Text =_LocalDrivingLicense.UserInfo.UserName;

            cbLicenseClass.SelectedValue = _LocalDrivingLicense.LicenseClassID.ToString();



        }
        private void _RefreshValues()
        {

            //Default Values

            _RefershLicenseClassComboBox();

            lbAppDate.Text = DateTime.Now.ToShortDateString();
            lbMadeByUser.Text = clsCurrentUser.User.UserName.ToString();

            //Here we make a query to get the New Local Driving License application fees
            decimal ApplicationTypeFee = 0;
            if (clsApplicationTypes.GetApplicationTypeFees((int)clsApplications.enApplicationType.NewInternationalLicense, ref ApplicationTypeFee))
            {
                lbAppFees.Text = ApplicationTypeFee.ToString() + " SAR ";
            }
            else
            {   //Incase the function returned false
                lbAppFees.Text = "[UNKOWN]";
            }

          //  txtMadeByUser.Text = clsCurrentUser.User.UserID.ToString();

            if (Mode == enMode.Add)
            {
                _LocalDrivingLicense = new clsLocalDrivingLicenseApplications();


                lbAddUpdate.Text = "Add New Local Driving License Application";

                return;
            }
            //////

            //Update Mode

            lbAddUpdate.Text = "Update Local Driving License Application";

            //Load Application
            _LocalDrivingLicense = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseID);

            //Check if someone has deleted it
            if (_LocalDrivingLicense == null)
            {
                MessageBox.Show("Application is deleted or not found , this page will be closed");
                this.Close();
                return;
            }

            //Load info
            _LoadLocalLicenseApplicationData();

        }


        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _RefreshValues();
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //Check if this person have an open or completed application for the same license class
            //Note: You must search by person id and license class , becuase you cannot search by local driving license
            //while you are adding the application , becuase you still don't have the local id which will be for now -1
            if(clsLocalDrivingLicenseApplications.IsApplicantHaveActiveLocalDrivingLicenseApplicationWithSameClass(
                cntrlPersonCardWithFilter2.PersonID, Convert.ToByte(cbLicenseClass.SelectedValue)))
            {
                MessageBox.Show("Cannot Make The Application Becuase This Person Have An Active Application For the Same License Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           // Check if the person has already completed this application and issuied a local license
            if (clsLocalDrivingLicenseApplications.IsApplicantHaveCompletedLocalDrivingLicenseApplicationWithSameClass(cntrlPersonCardWithFilter2.PersonID,
                Convert.ToByte(cbLicenseClass.SelectedValue)))
            {
                MessageBox.Show("Cannot Make The Application Becuase This Person Have Isuued  A Driving License For This Application:\n" +
                    " Issue A New Application ",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _LocalDrivingLicense.ApplicationDate = DateTime.Now;
            _LocalDrivingLicense.LastStatusDate = DateTime.Now;
            _LocalDrivingLicense.ApplicationStatus = clsApplications.enApplicationStatus.New;
            _LocalDrivingLicense.ApplicantPersonID = cntrlPersonCardWithFilter2.PersonID;
            _LocalDrivingLicense.ApplicationTypeID = (int)clsApplications.enApplicationType.NewDrivingLicense; //New Local Driving License Application
            _LocalDrivingLicense.CreatedByUserID = clsCurrentUser.User.UserID;
            _LocalDrivingLicense.LicenseClassID = Convert.ToByte(cbLicenseClass.SelectedValue);


            //Make sure that the Application is saved first , then we save the LocalDrivingLicense Application
            if (_LocalDrivingLicense.Save())
            {
                //store the App ID after it is saved in the LocalDrivingLicense Object
                lbLocalAppID.Text = _LocalDrivingLicense.LocalDrivingLicenseApplicationID.ToString();

                    MessageBox.Show("Application Saved Successfully ",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 
                    DataBack?.Invoke(this, _LocalDrivingLicense.LocalDrivingLicenseApplicationID);
            }
                else
                {
                    MessageBox.Show("Error Saving Local Driving License Application ",
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }


        }
    }

}



