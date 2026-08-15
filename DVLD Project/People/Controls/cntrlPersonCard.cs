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
using System.Web.Configuration;
using System.Windows.Forms;


namespace DVLD_Project.Controls
{
    public partial class cntrlPersonCard : UserControl
    {
        private clsPeople _Person;

        private int _PersonID = -1;

        public int PersonID
        { 
            get {
                return _PersonID;
               } 
        }


        bool _IsEditFormClosed = false;

       public bool _IsEditFormSaved = false;
        
    
        
        public cntrlPersonCard()
        {

            InitializeComponent();
        }



        private void ChangeGenderTextBoxColor(string Gender)
        {
            

            switch (Gender)
            {
                case "Male":
                    btnMale.FillColor = Color.FromArgb(255, 193, 7);
                    btnMale.ForeColor = Color.White;
                    btnMale.BorderColor = Color.FromArgb(255, 193, 7);
                    btnFemale.FillColor = Color.White;
                    btnFemale.ForeColor = Color.FromArgb(33, 37, 57);
                    btnFemale.BorderColor = Color.FromArgb(217, 222, 229);
                    break;

                case "Female":
                    btnFemale.FillColor = Color.FromArgb(255, 193, 7);
                    btnFemale.ForeColor = Color.White;
                    btnFemale.BorderColor = Color.FromArgb(255, 193, 7);
                    btnMale.FillColor = Color.White;
                    btnMale.ForeColor = Color.FromArgb(33, 37, 57);
                    btnMale.BorderColor = Color.FromArgb(217, 222, 229);
                    break;

            }
        }
        private void btnMale_Click(object sender, EventArgs e)
        {
            ChangeGenderTextBoxColor(btnMale.Tag.ToString());
        }

        private void btnFemale_Click(object sender, EventArgs e)
        {
            ChangeGenderTextBoxColor(btnFemale.Tag.ToString());

        }



        private void btnFemale_Click_1(object sender, EventArgs e)
        {
            ChangeGenderTextBoxColor(btnFemale.Tag.ToString());

        }


        public void LoadPersonCardByPersonID(int PersonID)
        {
            _Person = clsPeople.FindPersonByID(PersonID);

            if (_Person == null)
            {
                _PersonID = -1;
                MessageBox.Show("The ID for this perons" + PersonID + " is not found ", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RefreshPersonCard();


        }



        public void LoadPersonCardByPersonNationalNo(string NationaNumber)
        {


            _Person = clsPeople.FindPersonByNationalNo(NationaNumber);

            if (_Person == null)
            {
                MessageBox.Show("The National Number for this person " + NationaNumber + " is not found ","NOT FOUND",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            RefreshPersonCard();

        }

        private void RefershCoutnryComboBox()
        {
            DataTable dt = clsCountries.GetAllCountry();
            if (dt == null)
            {
                MessageBox.Show("Error in loading countries");
                return;
            }
            cbCountry.DataSource = dt;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
        }
        private void RefreshPersonCard()
        {

            _PersonID = _Person.PersonID;

            llEdit.Enabled = true; 

            lbPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName.ToString();
            txtSeconName.Text = _Person.SecondName.ToString();

            if (!string.IsNullOrEmpty(_Person.ThirdName))
            {
                txtThirdName.Text = _Person.ThirdName.ToString();
            }
            else
            {
                txtThirdName.Text = " ";
            }

            txtLastName.Text = _Person.LastName.ToString();
            txtNationalNumber.Text = _Person.NationalNumber;

            if (_Person.Gender == clsPeople.enGender.Male)
            {
                btnMale.DisabledState.FillColor = Color.FromArgb(255, 193, 7);
                btnMale.DisabledState.ForeColor = Color.White;
                btnMale.DisabledState.BorderColor = Color.FromArgb(255, 193, 7);
            }

            if (_Person.Gender == clsPeople.enGender.Female)
            {

                btnFemale.DisabledState.FillColor = Color.FromArgb(255, 193, 7);
                btnFemale.DisabledState.ForeColor = Color.White;
                btnFemale.DisabledState.BorderColor = Color.FromArgb(255, 193, 7);
            }

            if (!string.IsNullOrEmpty(_Person.Email))
            {
                txtEmail.Text = _Person.Email.ToString();
            }
            else
            {
                txtEmail.Text = " ";
            }

            txtAddress.Text = _Person.Address.ToString();
            txtPhone.Text = _Person.PhoneNumber.ToString();
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            RefershCoutnryComboBox();

            cbCountry.SelectedValue = _Person.CountryID;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                try
                {
                    if (System.IO.File.Exists(_Person.ImagePath))
                        pbPersonPhoto.ImageLocation = _Person.ImagePath;
                }
                catch
                {
                    MessageBox.Show("Error Displaying Image", "Error Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                pbPersonPhoto.Image = Resources.user_camera_3356_512;
        }

        private void cntrlPersonCard_Load(object sender, EventArgs e)
        {

        }



        private void _EditPersonFormClosed()
        {


            //This Function Will Execute when the event of the FormEditClose is fired
            MessageBox.Show("Data Is Not Saved", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _IsEditFormClosed = true;
        }

        private void llRemovePhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Refersh the flag
            _IsEditFormClosed = false;
 

            frmAddEdit Add = new frmAddEdit(_PersonID);

            //Subscribe to the event  
            Add.CancelEditPerson += _EditPersonFormClosed;

            Add.ShowDialog();

            if (Add.DialogResult == DialogResult.OK)
            {
                _IsEditFormSaved = true;
            }
            else
                _IsEditFormSaved = false;

            //If the user closed the form without editing it will not refersh
            if (!_IsEditFormClosed)
                LoadPersonCardByPersonID(_PersonID);
        }

        private void pbPersonPhoto_Click(object sender, EventArgs e)
        {

        }
    }
}
