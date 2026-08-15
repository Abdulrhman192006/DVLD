using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Users;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;


namespace DVLD_Project.Users
{
    public partial class frmAddEditUser : Form
    {
        clsUsers _User;
        int _UserID;
        enum Mode { Add , Update , CurrentUserUpdate}
        Mode _enMode;

        public delegate void DataBackEventHandler(object sender, int UserID);

        public event DataBackEventHandler DataBack;

        public frmAddEditUser()
        {
            //if this contstrucotr is used then it means
            //that we will add a user
            InitializeComponent();

            _enMode = Mode.Add;
        }
        public frmAddEditUser(int UserID)
        {
            //if this constructor is used
            //then it will pass the user ID to update it
            InitializeComponent();

            _UserID = UserID;
            _enMode = Mode.Update;

        }
        public frmAddEditUser(clsUsers CurrentUser)
        {
                 //if this constructor is used
                 //then it will pass the Current User to update it
                InitializeComponent();

                _User = CurrentUser;
                _enMode = Mode.CurrentUserUpdate;

        }


        private void  _DisableEditingPasswordTextBoxes()
        {
            txtPassWord.Enabled = false;
            txtAnotherPassword.Visible = false;

            lbConfirmPassword.Visible = false;

        }

        private void _LoadUser()
        {
            lbAddUpdate.Text = "Update User";

            //Disable Editing Password text box
            _DisableEditingPasswordTextBoxes();
           //and enabling the label link for changing the password
           llChangePassword.Visible = true;
           llChangePassword.Enabled = true;

            //Load Person Card and Disable The Filter Control So No one can change it
            cntrlPersonCardWithFilter2.LoadPerson(_User.PersonID);
            cntrlPersonCardWithFilter2.EnablePersonCardWithFilter = false;

            lbUserID.Text = _User.UserID.ToString();

            txtUserName.Text = _User.UserName;
            txtPassWord.Text = _User.Password;

            txtAnotherPassword.Text = _User.Password;

            if(_User.IsActive)
                chbActive.Checked = true;
            else
                chbActive.Checked = false;

        }
        private void _LoadDefaultValues()
        {
            cntrlPersonCardWithFilter2.EnablePersonCardWithFilter = true;

            lbAddUpdate.Text = "Add User";
            chbActive.Checked = false;

        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            //Here we just pass the current user to update 
            //without finding the user in the database
            if(_enMode == Mode.CurrentUserUpdate)
            {
                if (_User == null)
                {
                    MessageBox.Show("Error Loading Form : User Is Not Found, the form will be closed", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                _LoadUser();
                return;
            }

            if (_enMode == Mode.Add)
            {
                _User = new clsUsers();
                _LoadDefaultValues();
            }
            //Edit Mode
            else
            {
                _User = clsUsers.FindUserByID(_UserID);
                if( _User == null)
                {
                    MessageBox.Show("Error Loading Form : User Is Not Found, the form will be closed","Error"
                        ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                _LoadUser();
            }

        }


        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (cntrlPersonCardWithFilter2.PersonID == -1)
            {
                MessageBox.Show($"No Person Have Been Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check is the founded person in add mode is not connected by another user
            if (clsUsers.IsUserExistByPersonID(cntrlPersonCardWithFilter2.PersonID) && _enMode == Mode.Add)
            {
                MessageBox.Show($"Person with Person ID [{cntrlPersonCardWithFilter2.PersonID}] Is Connected by another user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            pnlUserLoginInfo.Enabled = true;
            tcUsers.SelectTab(1);
        }



        private void ValidatingEmptyTextBox(object sender, CancelEventArgs e)
        {

            //This validates all the text boxes that must not allow empty values

            //here we change the sender which started this event to text box to use it's properties
            Guna2TextBox textBox = (Guna2TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                    errorProvider1.SetError(textBox, $"{textBox.Tag} Field Is Required!");
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }
        }



        private void txtAnotherPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnotherPassword.Text))
            {
                errorProvider1.SetError(txtAnotherPassword, $"This Field Is Required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAnotherPassword, "");

            }

            if (txtPassWord.Text != txtAnotherPassword.Text)
            {
                errorProvider1.SetError(txtAnotherPassword, $"Password Does Not Match");
            }
            else
            {
                errorProvider1.SetError(txtAnotherPassword, "");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //trigger for all the text boxes to validate it self
            if (!this.ValidateChildren())
            {
                MessageBox.Show("You Must Fill All The Required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //loop all over the text boxes to see if it have error providers set on it or no
            if (!clsValidations.ValidateTextBoxesErrorProviders(pnlUserLoginInfo, errorProvider1))
            {
                MessageBox.Show("You Must Fill All The Required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.UserName = txtUserName.Text.Trim();
            _User.PersonID = cntrlPersonCardWithFilter2.PersonID;
            _User.IsActive = chbActive.Checked;

            if (chbApplyPassword.Checked)
            {
                
                if (!_ValidateChangePassword())
                {
                    MessageBox.Show("Error : Change Password Fileds Are Not Correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //loop all over the text boxes to see if it have error providers set on it or no
                if (!clsValidations.ValidateTextBoxesErrorProviders(pnChangePassword, errorProvider1))
                    
                {
                    MessageBox.Show("Error : Change Password Fileds Are Not Correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }


            _User.Password = chbApplyPassword.Checked ?
                txtConfirmPassword.Text : txtPassWord.Text;

            if (_User.Save())
            {
                lbAddUpdate.Text = "Update User";
                lbUserID.Text = _User.UserID.ToString();

                //Saving the changes on the current user
                if(_User.UserID == clsCurrentUser.User.UserID)
                clsCurrentUser.User = _User;

                MessageBox.Show("User Saved Successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _User.UserID);

                this.Close();
            }
            else
            {
                MessageBox.Show("Error: User Is Not Saved ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void llChangPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnChangePassword.Visible = !pnChangePassword.Visible;

        }
        private bool _ValidateChangePassword()
        {

            if (txtCurrentPassword.Text != _User.Password)
            {
                errorProvider1.SetError(txtCurrentPassword, $"Paassword is not correct!");
                return false;

            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, $"Password Does Not Match");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }

            return true;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, $"User Name Field Must Not Be Empty");
                return;

            }
                                                        //if he re-enters the same user name for the same current user it is permessible
            if (clsUsers.IsUserExist(_User.UserName) && txtUserName.Text.Trim() != _User.UserName)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, $"User Name Is Used By Another User");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(txtUserName, "");
        }

        //hide or show password button
        private void btnShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassWord.PasswordChar = '\0';
            txtAnotherPassword.PasswordChar = '\0';
        }

        private void btnShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassWord.PasswordChar = '*';
            txtAnotherPassword.PasswordChar = '*';


        }
    }
}
