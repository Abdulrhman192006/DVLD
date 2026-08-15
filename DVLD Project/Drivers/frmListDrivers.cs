using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Licenses;
using DVLD_Project.People;
using DVLD_Project.Properties;
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

namespace DVLD_Project.Drivers
{
    public partial class frmListDrivers : Form
    {

        DataTable dtDrivers;
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void _LoadDataGridViewDrivers()
        {
            lbNoRecords.Visible = false;

            dtDrivers = clsDrivers.GetAllDrivers();
            dgvDrivers.DataSource = dtDrivers;

            //we check if there is record , becuase if there is not 
            //and we did not check it will give run time error
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].HeaderText = "Active Licenses";

            }

            else
            {
                lbNoRecords.Visible = true;

            }
            dgvDrivers.EnableHeadersVisualStyles = false;

            dgvDrivers.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvDrivers.ColumnHeadersDefaultCellStyle.BackColor;

            dgvDrivers.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvDrivers.ColumnHeadersDefaultCellStyle.ForeColor;


        }

        private void _LoadComboBoxFilter()
        {

            //Set the source data for the filterd combo box
            clsUtil.FilterdItemsCB[] CBItemsArr = {new  clsUtil.FilterdItemsCB("None" , "None","",null),new  clsUtil.FilterdItemsCB("Driver ID" , "DriverID","Enter Driver ID", Resources.card),
                new clsUtil.FilterdItemsCB("Person ID" , "PersonID","Enter Person ID", Resources.card) ,
             new clsUtil.FilterdItemsCB("Full Name" , "FullName","Enter Full Name", Resources.person_boy) ,  new clsUtil.FilterdItemsCB("National No" , "NationalNo","Enter National Number", Resources.geography__1_)};


            cbFilter.DataSource = CBItemsArr;
            cbFilter.DisplayMember = "Name";
            cbFilter.ValueMember = "ColumnName";


            cbFilter.SelectedIndex = 0;
        }


        private void frmManageUsers_Load(object sender, EventArgs e)
        {

        }



        private void cmsUsers_Opening(object sender, CancelEventArgs e)
        {

        }




        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userCard = new frmUserInfo((int)dgvDrivers.CurrentRow.Cells["UserID"].Value);
            userCard.ShowDialog();

        }

        private void _FilterComboBox()
        {
            string FilterText = txtFilter.Text.Trim();


            if (string.IsNullOrWhiteSpace(FilterText) || cbFilter.SelectedValue == "None")
            {

                //If the text box filter empty or the cb is none we just reset the 
                //row filter to restore back all data from the data grid view
                dtDrivers.DefaultView.RowFilter = "";
                return;
            }

            if (cbFilter.SelectedValue == "PersonID" ||
               cbFilter.SelectedValue == "DriverID")
            {
                dtDrivers.DefaultView.RowFilter = $"{cbFilter.SelectedValue} = {FilterText}";
                return;

            }

            dtDrivers.DefaultView.RowFilter = $"{cbFilter.SelectedValue} like '{FilterText}%'";
        }



        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilter.SelectedValue == "PersonID" || cbFilter.SelectedValue == "DriverID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }


        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _LoadDataGridViewDrivers();
            _LoadComboBoxFilter();
        }

        private void txtFilter_TextChanged_1(object sender, EventArgs e)
        {
            _FilterComboBox();

        }

        private void cbFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            txtFilter.Visible = true;

            if (cbFilter.SelectedIndex == 0) //None
            {
                txtFilter.Visible = false;
                return;
            }

            //We convert the selected item in the combo box after connecting it to the array to class filter item , and then use all the propreties
            clsUtil.FilterdItemsCB FilterItem = (clsUtil.FilterdItemsCB)cbFilter.SelectedItem;
            txtFilter.PlaceholderText = FilterItem.PlaceHolderText;
            txtFilter.IconLeft = FilterItem.TextBoxIcon;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            txtFilter.Visible = false;

            cbFilter.SelectedIndex = 0;
        }

        private void tsmPersonInfo_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells["PersonID"].Value;

            frmPersonCard frmPersonCard = new frmPersonCard(PersonID);
            frmPersonCard.ShowDialog();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells["PersonID"].Value;

            frmLicensesHistory frmLicensesHistory = new frmLicensesHistory(PersonID);
            frmLicensesHistory.ShowDialog();
        }
    }
}
