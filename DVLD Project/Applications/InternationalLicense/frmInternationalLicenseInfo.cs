using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.InternationalLicense
{
    public partial class frmInternationalLicenseInfo : Form
    {

        int _InternationalLicensID;
        public frmInternationalLicenseInfo(int InternationalLicensID)
        {
            InitializeComponent();

            _InternationalLicensID = InternationalLicensID;
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            cntrlInernationalLicensInfo1.LoadInternationalLicenseInfo(_InternationalLicensID);
        }
    }
}
