using DVLD_BuisnessLayer;
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

namespace DVLD_Project.Users
{
    public partial class frmUserInfo : Form
    {
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            cntrlUserCard1._LoadUserInfo(UserID);
        }
        

        //Pass the current user 
        //without finding the user in the database
        public frmUserInfo(clsUsers User)
        {
            InitializeComponent();
            cntrlUserCard1._LoadCurrentUserInfo(User);
        }

        private void cntrlUserCard1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
