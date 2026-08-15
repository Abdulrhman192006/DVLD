using DVLD_Project.Application;
using DVLD_Project.Applications.LocalDrivingLisence;
using DVLD_Project.Drivers;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Main.ApplicationPanels;
using DVLD_Project.People;
using DVLD_Project.Test;
using DVLD_Project.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clsTestTypes;

namespace DVLD_Project.Main
{
    public partial class frmMainMenu : Form
    {
        frmLogin _FrmLogin;
        public frmMainMenu(frmLogin login)
        {
            InitializeComponent();

            guna2ContextMenuStrip1.Items[0].ImageAlign = ContentAlignment.TopRight;

            //here we save the login form , so at any time we sign out , the info of 
            //the login form is saved 
            _FrmLogin = login;

            this.AutoScaleMode = AutoScaleMode.None;

        }



        bool isApplicationClicked = false;
        private void btnApplications_Click(object sender, EventArgs e)
        {
            PanelApplications PanelApplication = new PanelApplications();
            PanelApplication.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(PanelApplication);

            PanelApplication.Show();

            //if (!isApplicationClicked)
            //{
            //    pnlApplications.Height = 244;
            //    isApplicationClicked = true;
            //}
            //else
            //{
            //    pnlApplications.Height = 0;
            //    isApplicationClicked = false;
            //}


        }


        private void btnPeople_Click(object sender, EventArgs e)
        {
            cntrlManagePeople managePeopleControl = new cntrlManagePeople();
            managePeopleControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(managePeopleControl);
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            frmManageUsers MainMenuUsers = new frmManageUsers();
            MainMenuUsers.Dock = DockStyle.Fill;
            MainMenuUsers.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(MainMenuUsers);

            MainMenuUsers.Show();
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Pass the current logged in user
            frmUserInfo UserCard = new frmUserInfo(clsCurrentUser.User);
            UserCard.ShowDialog();


        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(btnCurrentUser,0,btnCurrentUser.Height);
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditUser UserEdit = new frmAddEditUser(clsCurrentUser.User);
            UserEdit.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            _FrmLogin.Show();
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            _FrmLogin.Show();
            this.Close();
        }

        private void btnManageApplicationTypes_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes applicationTypes = new frmListApplicationTypes();
            applicationTypes.Dock = DockStyle.Fill;
            applicationTypes.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(applicationTypes);
            applicationTypes.Show();
        }

        private void btnManageTestTypes_Click(object sender, EventArgs e)
        {
            frmListTestTypes testTypes = new frmListTestTypes();
            testTypes.Dock = DockStyle.Fill;
            testTypes.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(testTypes);
            testTypes.Show();

            
        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            frmListDrivers frmListDrivers = new frmListDrivers();

            frmListDrivers.Dock = DockStyle.Fill;
            frmListDrivers.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frmListDrivers);
            frmListDrivers.Show();

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            PanelDetainLicense panelDetainLicense = new PanelDetainLicense();
            panelDetainLicense.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(panelDetainLicense);

            panelDetainLicense.Show();
        }
    }
}
