using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Properties;
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
    public partial class cntrlFindDrivingLicenseApplication : UserControl
    {
        public cntrlFindDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        public clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication
        {
            get
            {
                return cntrlDivingLicneseApplicationInfo1.LocalDrivingLicense;
            }
        }

        public bool EnableViewLicenseInfoButton
        {
            set
            {
                cntrlDivingLicneseApplicationInfo1.EnableViewLicenseInfoButton= value;
            }
        }


        private void cntrlFindDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            clsUtil.FilterdItemsCB[] FilterCB = {new clsUtil.FilterdItemsCB ("L.D.L Application ID", "LocalDrivingLicenseApplicationID","Enter ID",Resources.card),
                                            new clsUtil.FilterdItemsCB ("Application ID", "ApplicationID","Enter ID",Resources.card)};

            cbFilter.DataSource = FilterCB;
            cbFilter.DisplayMember = "Name";
            cbFilter.ValueMember = "ColumnName";

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            clsUtil.FilterdItemsCB FilterItem = (clsUtil.FilterdItemsCB)cbFilter.SelectedItem;
            txtFilter.PlaceholderText = FilterItem.PlaceHolderText;
            txtFilter.IconLeft = FilterItem.TextBoxIcon;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                if (cbFilter.SelectedValue == "LocalDrivingLicenseApplicationID")
                {
                    cntrlDivingLicneseApplicationInfo1.LoadDrivingLicenseApplicationInfo(Convert.ToInt16(txtFilter.Text.Trim()));
                    return;
                }

                if (cbFilter.SelectedValue == "ApplicationID")
                {
                    cntrlDivingLicneseApplicationInfo1.LoadDrivingLicenseApplicationInfo(Convert.ToInt16(txtFilter.Text.Trim()));
                    return;
                }

            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

            if (cbFilter.SelectedValue == "ApplicationID" || cbFilter.SelectedValue == "LocalDrivingLicenseApplicationID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnIssueLicenseFirstTime_Click(object sender, EventArgs e)
        {

        }
    }
}
