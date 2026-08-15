using DVLD_Project.Controls;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_Project
{

    public partial class frmAddEdit : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        //Declare an event that is fired when the user press close without editing no data
        public event Action CancelEditPerson;

        //Declare an event that is fired when the user press save after he edited the info for the person
        public event Action SaveEditPerson;

        clsPeople _Person;
        int _PersonID = -1;

        string _OldFilePath;
        enum enMode
        {
            Add,
            Edit
        }

        enMode Mode;

        public frmAddEdit()
        {
            InitializeComponent();

            Mode = enMode.Add;

        }
        public frmAddEdit(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            Mode = enMode.Edit;

        }

        private void _ChangeGenderButtonColor(string Gender)
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
                    btnMale.DisabledState.FillColor = Color.FromArgb(255, 193, 7);
                    btnMale.DisabledState.ForeColor = Color.White;
                    btnMale.DisabledState.BorderColor = Color.FromArgb(255, 193, 7);
                    break;

                case "Female":
                    btnFemale.FillColor = Color.FromArgb(255, 193, 7);
                    btnFemale.ForeColor = Color.White;
                    btnFemale.BorderColor = Color.FromArgb(255, 193, 7);
                    btnMale.FillColor = Color.White;
                    btnMale.ForeColor = Color.FromArgb(33, 37, 57);
                    btnMale.BorderColor = Color.FromArgb(217, 222, 229);
                    btnFemale.DisabledState.FillColor = Color.FromArgb(255, 193, 7);
                    btnFemale.DisabledState.ForeColor = Color.White;
                    btnFemale.DisabledState.BorderColor = Color.FromArgb(255, 193, 7);
                    break;

            }
        }

        private void _RefershCoutnryComboBox()
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

        private void _LoadPersonData()
        {


            lbPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName.ToString();
            txtSeconName.Text = _Person.SecondName.ToString();

            if (!string.IsNullOrEmpty(_Person.ThirdName))
            {
                txtThirdName.Text = _Person.ThirdName.ToString();
            }
            else
            {
                txtThirdName.Text = string.Empty;
            }

            txtLastName.Text = _Person.LastName.ToString();
            txtNationalNumber.Text = _Person.NationalNumber;

            //If male change color of the button 
            if (_Person.Gender == clsPeople.enGender.Male)
            {
                btnMale.PerformClick();
            }

            //If female change color of the button
            if (_Person.Gender == clsPeople.enGender.Female)
            {
                btnFemale.PerformClick();
            }

            if (!string.IsNullOrEmpty(_Person.Email))
            {
                txtEmail.Text = _Person.Email.ToString();
            }
            else
            {
                txtEmail.Text = string.Empty;
            }

            txtAddress.Text = _Person.Address.ToString();
            txtPhone.Text = _Person.PhoneNumber.ToString();
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            cbCountry.SelectedValue = _Person.CountryID;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                //if it does not exist in the computer we add the default image
                try
                {
                    if (System.IO.File.Exists(_Person.ImagePath))
                        pbPersonPhoto.ImageLocation = _Person.ImagePath;
                }
                catch
                {
                    //If the file does not exist it will load the default image

                }

            }

            llRemovePhoto.Visible = (pbPersonPhoto.ImageLocation != null);
        }

        private void _RefreshValues()
        {

            //Default Values

            _RefershCoutnryComboBox();

            //cannot exceed age more than 100
            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-100);
            //cannot add age less than 18
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;


            if (Mode == enMode.Add)
            {
                _Person = new clsPeople();

                lbAddEdit.Text = "Add Person";

                //to enable it we must check if there exist an image or not
                llRemovePhoto.Visible = (pbPersonPhoto.ImageLocation != null);


                //Default country is Saudi Arabia
                cbCountry.SelectedIndex = cbCountry.FindStringExact("Jordan");


                //The default gender is Male
                btnMale.PerformClick();

                return;
            }
            //////



            lbAddEdit.Text = "Edit Person";

            //Load person
            _Person = clsPeople.FindPersonByID(_PersonID);

            //Check if someone has deleted this person
            if (_Person == null)
            {
                MessageBox.Show("Person is deleted or not found , this page will be closed");
                this.Close();
                return;
            }

            //Load person info
            _LoadPersonData();

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }




        private void cntrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void frmAddEdit_Load(object sender, EventArgs e)
        {
            _RefreshValues();
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            _ChangeGenderButtonColor(btnMale.Tag.ToString());
            _Person.Gender = clsPeople.enGender.Male;
        }

        private void btnFemale_Click(object sender, EventArgs e)
        {
            _ChangeGenderButtonColor(btnFemale.Tag.ToString());
            _Person.Gender = clsPeople.enGender.Female;
        }

        private bool _HandlePersonImage()
        {

            //We check if the photo is changed or not
            if (pbPersonPhoto.ImageLocation != _Person.ImagePath)
            {


                //Here we check if we did not remove the photo so we can copy the image to the new file
                if (pbPersonPhoto.ImageLocation != null)
                {
                    string SourceFile = pbPersonPhoto.ImageLocation;

                    if (!clsUtil.CopyFilePathToNewDestination(ref SourceFile))
                        return false;


                    pbPersonPhoto.ImageLocation = SourceFile;
                }

                //Finally we delete the old image
                if (_Person.ImagePath != null)
                {
                    try
                    {
                        System.IO.File.Delete(_Person.ImagePath);

                    }

                    catch
                    {
                        return false;
                    }
                }

                return true;

            }

            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Must fill all the info correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
            {
                MessageBox.Show("Error Copying File To New Destination", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSeconName.Text.Trim();
            _Person.ThirdName = string.IsNullOrWhiteSpace(txtThirdName.Text) ? null : txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.NationalNumber = txtNationalNumber.Text.Trim();
            _Person.PhoneNumber = txtPhone.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.CountryID = (int)cbCountry.SelectedValue;
            // Person Gender is already known from clicking the male and female buttons



            if (!string.IsNullOrEmpty(pbPersonPhoto.ImageLocation))
            {
                _Person.ImagePath = pbPersonPhoto.ImageLocation;
            }
            else
            {
                _Person.ImagePath = null;
            }


            if (_Person.Save())
            {
                lbPersonID.Text = _Person.PersonID.ToString();
                MessageBox.Show("Person saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lbAddEdit.Text = "Edit Person";

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Person.PersonID);

                //Trigger the event to notify the PersonCardForm that the user has changed the 
                //info of the person , so it Call the refersh person card function
                SaveEditPerson?.Invoke();

                DialogResult = DialogResult.OK;

                this.Close();


            }

            else
            {
                MessageBox.Show("Error in saving person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();

            FileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            FileDialog.FilterIndex = 1;
            FileDialog.RestoreDirectory = true;

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                //Here we will save the old file path to copy it to the new location and save the new path in the database

                // Process the selected file
                string selectedFilePath = FileDialog.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);
                pbPersonPhoto.ImageLocation = selectedFilePath;
                llRemovePhoto.Visible = true;

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llRemovePhoto.Visible = false;
            pbPersonPhoto.ImageLocation = null;
            pbPersonPhoto.Image = Resources.person_man;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;

            CancelEditPerson?.Invoke();
           
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            //This validates all the text boxes that must not allow empty values

            //here we change the sender which started this event to text box to use it's properties
            Guna2TextBox textBox = (Guna2TextBox)sender;


            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "This Field Is Required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }


        }


        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNumber.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNumber, "National Number Must Not Be Empty");
                return;
            }

            //check it exits and is not for the same person
            if (clsPeople.IsPersonExist(txtNationalNumber.Text.Trim()) && _Person.NationalNumber != txtNationalNumber.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNumber, "National Number Is Used For Another Person!");
                return;
            }

            //this is not efficeint way and it costs to many memory space and time 
            //DataTable dt = clsPeople.GetAllPeople();

            //foreach (DataRow p in dt.Rows)
            //{
            //    //here we check the case if the same person we are editing  does not accure error 
            //    if (p["NationalNo"].ToString() == txtNationalNumber.Text
            //        && Convert.ToInt32(p["PersonID"]) != _PersonID)
            //    {

            //        e.Cancel = true;
            //        errorProvider1.SetError(txtNationalNumber, "National Number is used for another person!");
            //        return;
            //    }

            //}

            e.Cancel = false;
            errorProvider1.SetError(txtNationalNumber, "");


        }

        private void btnMale_Enter(object sender, EventArgs e)
        {
            btnMale.BorderThickness = 2;
            btnMale.BorderColor = Color.FromArgb(255, 193, 7);
        }

        private void btnMale_Leave(object sender, EventArgs e)
        {
            btnMale.BorderThickness = 1;
            btnMale.BorderColor = Color.FromArgb(217, 222, 229);
        }

        private void btnFemale_Enter(object sender, EventArgs e)
        {
            btnFemale.BorderThickness = 2;
            btnFemale.BorderColor = Color.FromArgb(255, 193, 7);
        }

        private void btnFemale_Leave(object sender, EventArgs e)
        {
            btnFemale.BorderThickness = 1;
            btnFemale.BorderColor = Color.FromArgb(217, 222, 229);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return;

            if (!clsValidations.ValidateEmailFormat(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Format");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtSeconName_Validating(object sender, CancelEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
