using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.LocalDrivingLisence
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        public frmLocalDrivingLicenseApplicationInfo(int LocalID)
        {
            InitializeComponent();

            cntrlDivingLicneseApplicationInfo1.LoadDrivingLicenseApplicationInfo(LocalID);
        }
    }
}
