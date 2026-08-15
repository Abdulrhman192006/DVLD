using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Licenses;
using DVLD_Project.People;
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

namespace DVLD_Project.Applications.InternationalLicense
{
    public partial class frmListInternationalLicenses : Form
    {
        DataTable dtInternationalLicense;

        public frmListInternationalLicenses()
        {
            InitializeComponent();
        }


        private void _LoadInternationalLicenseGridView()
        {
            dtInternationalLicense = clsInternationalLicenses.GetAllInternationalLicenses();
            dgvInternationalLicense.DataSource = dtInternationalLicense;

            dgvInternationalLicense.EnableHeadersVisualStyles = false;

            dgvInternationalLicense.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvInternationalLicense.ColumnHeadersDefaultCellStyle.BackColor;

            dgvInternationalLicense.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvInternationalLicense.ColumnHeadersDefaultCellStyle.ForeColor;

            if (dgvInternationalLicense.Rows.Count > 0)
            {
                dgvInternationalLicense.Columns[0].HeaderText = "International License ID";
                dgvInternationalLicense.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicense.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicense.Columns[3].HeaderText = "Local License ID";
                dgvInternationalLicense.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvInternationalLicense.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicense.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvInternationalLicense.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicense.Columns[6].HeaderText = "Is Active";

            }
        }


        private void _LoadComboBoxFilter()
        {
            //Set the source data for the filterd combo box
            clsUtil.FilterdItemsCB[] CBItemsArr = {new  clsUtil.FilterdItemsCB("None" , "None","",null),new  clsUtil.FilterdItemsCB("International License ID" , "InternationalLicenseID","Enter ID", Resources.card),
                new clsUtil.FilterdItemsCB("Driver ID" , "DriverID","Enter ID", Resources.card) ,new clsUtil.FilterdItemsCB("Is Active", "IsActive","",null) ,
             new clsUtil.FilterdItemsCB("Application ID" , "ApplicationID","Enter ID", Resources.person_boy)};


            cbFilter.DataSource = CBItemsArr;
            cbFilter.DisplayMember = "Name";
            cbFilter.ValueMember = "ColumnName";


            cbFilter.SelectedIndex = 0;
        }

        private void frmListInternationalLicenses_Load(object sender, EventArgs e)
        {
            _LoadInternationalLicenseGridView();
            _LoadComboBoxFilter();


        }


        private void cbFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            txtFilter.Visible = true;
            cbActiveUser.Visible = false;

            if (cbFilter.SelectedIndex == 0) //None
            {
                txtFilter.Visible = false;
                return;
            }

            if (cbFilter.SelectedValue == "IsActive")
            {
                txtFilter.Visible = false;
                cbActiveUser.Visible = true;
                return;
            }

            //We convert the selected item in the combo box after connecting it to the array to class filter item , and then use all the propreties
            clsUtil.FilterdItemsCB FilterItem = (clsUtil.FilterdItemsCB)cbFilter.SelectedItem;
            txtFilter.PlaceholderText = FilterItem.PlaceHolderText;
            txtFilter.IconLeft = FilterItem.TextBoxIcon;
        }

        private void cbActiveUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterActiveComboBox();

        }


        private void _FilterComboBox()
        {
            string FilterText = txtFilter.Text.Trim();


            if (string.IsNullOrWhiteSpace(FilterText) || cbFilter.SelectedValue == "None")
            {

                //If the text box filter empty or the cb is none we just reset the 
                //row filter to restore back all data from the data grid view
                dtInternationalLicense.DefaultView.RowFilter = "";
                return;
            }

            dtInternationalLicense.DefaultView.RowFilter = $"{cbFilter.SelectedValue} = {FilterText}";
            return;



        }


        private void _FilterActiveComboBox()
        {
            string FilterItem = "IsActive";


            //Index 0 = Yes
            if (cbActiveUser.SelectedIndex == 0)
            {
                dtInternationalLicense.DefaultView.RowFilter = $"{FilterItem} = 1";
                return;
            }

            //Index 1 = No
            if (cbActiveUser.SelectedIndex == 1)
            {
                dtInternationalLicense.DefaultView.RowFilter = $"{FilterItem} = 0";
                return;
            }

            //Index 2 = All
            dtInternationalLicense.DefaultView.RowFilter = "";
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterComboBox();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            txtFilter.Visible = false;
            cbActiveUser.Visible = false;

            cbFilter.SelectedIndex = 0;
            cbActiveUser.SelectedIndex = 2;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilter.SelectedValue == "InternationalLicenseID" || cbFilter.SelectedValue == "DriverID"
                        || cbFilter.SelectedValue == "IssuedUsingLocalLicenseID" || cbFilter.SelectedValue == "ApplicationID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddIssueInternationalLicenses_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense InternationalLicenes = new frmIssueInternationalLicense();
            InternationalLicenes.ShowDialog();
            _LoadInternationalLicenseGridView();
        }

        private void licenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicense.CurrentRow.Cells["InternationalLicenseID"].Value;

            frmInternationalLicenseInfo internationalLicenseInfo = new frmInternationalLicenseInfo(InternationalLicenseID);
            internationalLicenseInfo.ShowDialog();
        }

        private void tsmPersonInfo_Click(object sender, EventArgs e)
        {
            int PersonID = clsPeople.GetPersonIDByDriverID((int)dgvInternationalLicense.CurrentRow.Cells["DriverID"].Value);

            frmPersonCard PersonCard = new frmPersonCard(PersonID);
            PersonCard.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPeople.GetPersonIDByDriverID((int)dgvInternationalLicense.CurrentRow.Cells["DriverID"].Value);

            frmLicensesHistory LicenseHistory = new frmLicensesHistory(PersonID);
            LicenseHistory.ShowDialog();
        }
    }
}
