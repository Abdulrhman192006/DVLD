using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project.Licenses
{
    public partial class frmDriversInfo : Form
    {
        public frmDriversInfo(int LicenseID)
        {
            InitializeComponent();

            cntrlDriverInfo1.LoadLicenseInfo(LicenseID);


        }
        public frmDriversInfo(clsApplications Application)

        {
            InitializeComponent();

            cntrlDriverInfo1.LoadLicenseInfoByApplcaitonID(Application.ApplicationID);

        }


    }
}
