using DVLD_BuisnessLayer;
using DVLD_Project.Applications.DetainLicense;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Licenses;
using DVLD_Project.People;
using DVLD_Project.Properties;
using GumroadLicensing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Replace_License
{
    public partial class frmListDetainedLicenses : Form
    {
        DataTable dtDetainedLicenses;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterComboBox();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            txtFilter.Visible = false;
            cbIsReleased.Visible = false;

            cbFilter.SelectedIndex = 0;
            cbIsReleased.SelectedIndex = 2;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            txtFilter.Visible = true;
            cbIsReleased.Visible = false;

            if (cbFilter.SelectedIndex == 0) //None
            {
                txtFilter.Visible = false;
                return;
            }

            if (cbFilter.SelectedValue == "IsReleased")
            {
                txtFilter.Visible = false;
                cbIsReleased.Visible = true;
                return;
            }

            //We convert the selected item in the combo box after connecting it to the array to class filter item , and then use all the propreties
            clsUtil.FilterdItemsCB FilterItem = (clsUtil.FilterdItemsCB)cbFilter.SelectedItem;
            txtFilter.PlaceholderText = FilterItem.PlaceHolderText;
            txtFilter.IconLeft = FilterItem.TextBoxIcon;
        }
        

        private void _LoadDataGridView()
        {


            lbNoRecords.Visible = false;

            dtDetainedLicenses = clsDetainedLicenses.GetAllDetainedLicensesSelectedColumns();
            dgvDetainedLicenses.DataSource = dtDetainedLicenses;

            //we check if there is record , becuase if there is not 
            //and we did not check it will give run time error
            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "Detained ID";
                dgvDetainedLicenses.Columns[1].HeaderText = "License ID";
                dgvDetainedLicenses.Columns[2].HeaderText = "Detained Date";
                dgvDetainedLicenses.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDetainedLicenses.Columns[4].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDetainedLicenses.Columns[3].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDetainedLicenses.Columns[6].HeaderText = "National No";
                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDetainedLicenses.Columns[8].HeaderText = "Release Application ID";
                dgvDetainedLicenses.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



            }

            else
            {
                lbNoRecords.Visible = true;

            }
            dgvDetainedLicenses.EnableHeadersVisualStyles = false;

            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.BackColor;

            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.ForeColor;

        }


        private void _LoadComboBoxFilter()
        {
            //Set the source data for the filterd combo box
            clsUtil.FilterdItemsCB[] CBItemsArr = {new  clsUtil.FilterdItemsCB("None" , "None","",null),new  clsUtil.FilterdItemsCB("Detain ID" , "DetainID","Enter Detain ID", Resources.card),
                new clsUtil.FilterdItemsCB("National Number" , "NationalNo","Enter National Number", Resources.card) ,new clsUtil.FilterdItemsCB("Is Released", "IsReleased","",null) ,
             new clsUtil.FilterdItemsCB("Full Name" , "FullName","Enter Full Name", Resources.person_boy) ,  new clsUtil.FilterdItemsCB("Release Application ID" , "ReleaseApplicationID","Enter Release Application ID", Resources.geography__1_)};


            cbFilter.DataSource = CBItemsArr;
            cbFilter.DisplayMember = "Name";
            cbFilter.ValueMember = "ColumnName";


            cbFilter.SelectedIndex = 0;
        }
        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {

            _LoadDataGridView();
            _LoadComboBoxFilter();

          

        }


        private void _FilterComboBox()
        {
            string FilterText = txtFilter.Text.Trim();


            if (string.IsNullOrWhiteSpace(FilterText) || cbFilter.SelectedValue == "None")
            {

                //If the text box filter empty or the cb is none we just reset the 
                //row filter to restore back all data from the data grid view
                dtDetainedLicenses.DefaultView.RowFilter = "";
                return;
            }

            if (cbFilter.SelectedValue == "DetainID" ||
               cbFilter.SelectedValue == "ReleaseApplicationID")
            {
                dtDetainedLicenses.DefaultView.RowFilter = $"{cbFilter.SelectedValue} = {FilterText}";
                return;

            }

            dtDetainedLicenses.DefaultView.RowFilter = $"{cbFilter.SelectedValue} like '{FilterText}%'";
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterIsReleasedComboBox();
        }

        private void _FilterIsReleasedComboBox()
        {
            string FilterItem = "IsReleased";


            //Index 0 = All
            if (cbIsReleased.SelectedIndex == 0)
            {
                dtDetainedLicenses.DefaultView.RowFilter = "";
                return;
            }

            //Index 1 = Yes
            if (cbIsReleased.SelectedIndex == 1)
            {
                dtDetainedLicenses.DefaultView.RowFilter = $"{FilterItem} = 1";
                return;
            }

            //Index 2 = No
            dtDetainedLicenses.DefaultView.RowFilter = $"{FilterItem} = 0";
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilter.SelectedValue == "DetainID" || cbFilter.SelectedValue == "ReleaseApplicationID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void tsmPersonInfo_Click(object sender, EventArgs e)
        {
            string NationalNumber = (string)dgvDetainedLicenses.CurrentRow.Cells["NationalNo"].Value;

            frmPersonCard frmPersonCard = new frmPersonCard(NationalNumber);
            frmPersonCard.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPeople.GetPersonIDByNationalNumber((string)dgvDetainedLicenses.CurrentRow.Cells["NationalNo"].Value);

            frmLicensesHistory frmLicensesHistory = new frmLicensesHistory(PersonID);
            frmLicensesHistory.ShowDialog();
        }

        private void licenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value;

            frmDriversInfo DriverInfo = new frmDriversInfo(LicenseID);
            DriverInfo.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();

            detainLicense.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            detainLicense.StartPosition = FormStartPosition.CenterScreen;

            detainLicense.ShowDialog();
            _LoadDataGridView();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value;

            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense(LicenseID);

            releaseDetainedLicense.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            releaseDetainedLicense.StartPosition = FormStartPosition.CenterScreen;
            releaseDetainedLicense.ShowDialog();
            _LoadDataGridView();

        }

        private void dgvDetainedLicenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
           btnRelease.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells["IsReleased"].Value;

        }
    }
}
