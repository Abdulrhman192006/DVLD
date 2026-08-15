using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Main;
using DVLD_Project.Users;
using System;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmLogin : Form
    {
        bool _IsSignIn = false;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void btnShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';

        }

        private void _AssignUserNamePasswordTextBoxes(object sender, int UserID)
        {
            clsCurrentUser.User = clsUsers.FindUserByID(UserID);

            txtUserName.Text = clsCurrentUser.User.UserName;
            txtPassword.Text = clsCurrentUser.User.Password;

            //here we will add this flag so we dont check again the same user 
            //that is signed in , because he is already added correctly
            _IsSignIn = true;


        }
        private void btnSignin_Click(object sender, EventArgs e)
        {
            frmAddEditUser addEdit = new frmAddEditUser();
            addEdit.DataBack += _AssignUserNamePasswordTextBoxes;
            addEdit.ShowDialog();
        }

        private bool CheckLogInInfo()
        {
            //If the user has signed in , we let him enter the system
            if (_IsSignIn)
                return true;

            clsCurrentUser.User = clsUsers.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            //User is not null then he is found
            if (clsCurrentUser.User != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private bool SaveCurrentUserInfo()
        {
            string UserInfo = $"{txtUserName.Text.Trim()}|{txtPassword.Text.Trim()}";

            if (clsUtil.WriteInFile("CurrentUser.txt", UserInfo))
            {
                return true;
            }
            else
                return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            if (CheckLogInInfo())
            {
                //If the user is not active , then he cannot continue to the system
                if (!clsCurrentUser.User.IsActive)
                {
                    MessageBox.Show("This User Is Not Active , Please Contact With The Suppourt Team", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chbRememberMe.Checked)
                {
                    if (!SaveCurrentUserInfo())
                    {
                        MessageBox.Show("Error Saving Remember Me User Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //we delete the file content for the current user id
                else
                {
                    if (!clsUtil.DeleteFileContent("CurrentUser.txt"))
                    {
                        MessageBox.Show("Error Deleting Remember Me User Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //we change the flag to false so the next time we return
                //back to the login form it does not enter the system with any username or password
                //so this is important
                _IsSignIn = false;

                this.Hide();
                frmMainMenu mainMenu = new frmMainMenu(this);
                mainMenu.ShowDialog();
            }

            else
            {
                MessageBox.Show("User Name or Password are not correct", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            txtUserName.Select();

            string[] UserInfo = null;
            if ((UserInfo = clsUtil.ReadOneLineFromFile("CurrentUser.txt")) != null)
            {
                txtUserName.Text = UserInfo[0];
                txtPassword.Text = UserInfo[1];
            }

        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
