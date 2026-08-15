using DVLD_BuisnessLayer;
using DVLD_Project.Applications;
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

namespace DVLD_Project.Drivers
{
    public partial class cntrlFindDriverInfo : UserControl
    {
        public event Action<int> OnLicenseselected;

        public cntrlFindDriverInfo()
        {
            InitializeComponent();
        }



        public clsLicenses LicenseInfo
        {
            get
            {
                return cntrlDriverInfo1.License;
            }
        }

        public bool EnableLicenseInfo
        {
            set
            {
                this.Enabled = value;
            }

            get
            {
                return this.Enabled;
            }
        }


        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void cntrlFindDriverInfo_Load(object sender, EventArgs e)
        {
            clsUtil.FilterdItemsCB[] FilterCB = {new clsUtil.FilterdItemsCB ("License ID", "LicenseID","Enter License ID",Resources.card),
                                            new clsUtil.FilterdItemsCB ("Application ID", "ApplicationID","Enter Application ID",Resources.card)};

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

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
       {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

            if (cbFilter.SelectedValue == "ApplicationID" || cbFilter.SelectedValue == "LicenseID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            cntrlDriverInfo1.LoadLicenseInfo(LicenseID);
            txtFilter.Text = LicenseID.ToString();

            if (cntrlDriverInfo1.LicenseID != -1)
                OnLicenseselected?.Invoke(cntrlDriverInfo1.LicenseID);
        }


        public void LoadLicenseInfoByApplicationID(int ApplicationID)
        {
            cntrlDriverInfo1.LoadLicenseInfo(ApplicationID);
            txtFilter.Text = ApplicationID.ToString();

            if (cntrlDriverInfo1.LicenseID != -1)
                OnLicenseselected?.Invoke(cntrlDriverInfo1.LicenseID);

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are required, please fill them");
                return;
            }
           

            if (!string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                if (cbFilter.SelectedValue == "LicenseID")
                {
                    LoadLicenseInfo(Convert.ToInt16(txtFilter.Text.Trim()));

                }

                else if (cbFilter.SelectedValue == "ApplicationID")
                {
                    LoadLicenseInfoByApplicationID(Convert.ToInt16(txtFilter.Text.Trim()));
                }

    
            }
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                errorProvider1.SetError(txtFilter, "This field is required");
                e.Cancel = true;
                return;
            }
        }


    }

}
