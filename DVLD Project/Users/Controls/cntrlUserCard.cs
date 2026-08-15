using DVLD_BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Users.Controls
{
    public partial class cntrlUserCard : UserControl
    {

        clsUsers _Users;
        public cntrlUserCard()
        {
            InitializeComponent();
        }

        
        public void _LoadUserInfo(int UserID)
        {
            _Users = clsUsers.FindUserByID(UserID);

            if (_Users == null)
            {
                MessageBox.Show("Error : User Is Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cntrlPersonCard2.LoadPersonCardByPersonID(_Users.PersonID);

            lbUserID.Text = UserID.ToString();
            txtPassword.Text = _Users.Password.ToString();
            txtUserName.Text = _Users.UserName.ToString();

            if (_Users.IsActive)
                tsActive.Checked = true;
            else
                tsActive.Checked = false;


        }

        public void _LoadCurrentUserInfo(clsUsers User)
        {
            _Users = User;

            if (_Users == null)
            {
                MessageBox.Show("Error : User Is Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cntrlPersonCard2.LoadPersonCardByPersonID(_Users.PersonID);

            lbUserID.Text = _Users.UserID.ToString();
            txtPassword.Text = _Users.Password.ToString();
            txtUserName.Text = _Users.UserName.ToString();

            if (_Users.IsActive)
                tsActive.Checked = true;
            else
                tsActive.Checked = false;


        }
        private void cntrlUserCard_Load(object sender, EventArgs e)
        {




        }

        private void tsActive_MouseDown(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;

        }
    }
}
