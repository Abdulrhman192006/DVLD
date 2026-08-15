using DVLD_BuisnessLayer;
using DVLD_Project.Applications.LocalDrivingLicense;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Licenses;
using DVLD_Project.People;
using DVLD_Project.Properties;
using DVLD_Project.Test.ManageSchedultTests;
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

namespace DVLD_Project.Applications.LocalDrivingLisence
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        DataTable dtLocalLicenseApplication;
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication locallicense = new frmAddUpdateLocalDrivingLicenseApplication();
            locallicense.ShowDialog();

            _RefereshLocalLicenseDataGridView();
        }

        private void _RefereshLocalLicenseDataGridView()
        {
            dtLocalLicenseApplication = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
            dgvLocalLicenseApplication.DataSource = dtLocalLicenseApplication;

            dgvLocalLicenseApplication.EnableHeadersVisualStyles = false;

            dgvLocalLicenseApplication.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvLocalLicenseApplication.ColumnHeadersDefaultCellStyle.BackColor;

            dgvLocalLicenseApplication.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvLocalLicenseApplication.ColumnHeadersDefaultCellStyle.ForeColor;



            if (dgvLocalLicenseApplication.Rows.Count > 0)
            {
                dgvLocalLicenseApplication.Columns[0].HeaderText = "L.D.L ID";
                dgvLocalLicenseApplication.Columns[1].HeaderText = "Driving License Class";
                dgvLocalLicenseApplication.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLocalLicenseApplication.Columns[2].HeaderText = "National No";
                dgvLocalLicenseApplication.Columns[3].HeaderText = "Full Name";
                dgvLocalLicenseApplication.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLocalLicenseApplication.Columns[4].HeaderText = "Application Date";
                dgvLocalLicenseApplication.Columns[5].HeaderText = "Passed Tests";
                dgvLocalLicenseApplication.Columns[6].HeaderText = "Status";

            }
        }
        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefereshLocalLicenseDataGridView();
            _LoadComboBoxFilter();
        }


        private void _LoadComboBoxFilter()
        {

            //Set the source data for the filterd combo box
            clsUtil.FilterdItemsCB[] CBItemsArr = {new  clsUtil.FilterdItemsCB("None" , "None","",null),new  clsUtil.FilterdItemsCB("Local D.L ID" , "LocalDrivingLicenseApplicationID","Enter ID", Resources.card),
                new clsUtil.FilterdItemsCB("Full Name" , "FullName","Enter Name", Resources.person_boy) ,new clsUtil.FilterdItemsCB("National Number", "NationalNo","Enter National Number",Resources.card) ,
             new clsUtil.FilterdItemsCB("Status" , "ApplicationStatus","Enter Application Status", Resources.person_boy)};


            cbFilter.DataSource = CBItemsArr;
            cbFilter.DisplayMember = "Name";
            cbFilter.ValueMember = "ColumnName";

            cbFilter.SelectedIndex = 0;
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmAddUpdateLocalDrivingLicenseApplication LocalUpdate =
                new frmAddUpdateLocalDrivingLicenseApplication((int)dgvLocalLicenseApplication.CurrentRow.Cells[0].Value);
            LocalUpdate.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this Application ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (clsLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplication((int)dgvLocalLicenseApplication.CurrentRow.Cells[0].Value))
                {

                    MessageBox.Show("Application Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Application Data Is Connected To Another Components", "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }


            //Cancel delete
            else
                return;

            _RefereshLocalLicenseDataGridView();
        }

        private void _FilterComboBox()
        {
            string FilterText = txtFilter.Text.Trim();


            if (string.IsNullOrWhiteSpace(FilterText) || cbFilter.SelectedValue == "None")
            {

                //If the text box filter empty or the cb is none we just reset the 
                //row filter to restore back all data from the data grid view
                dtLocalLicenseApplication.DefaultView.RowFilter = "";
                return;
            }

            if (cbFilter.SelectedValue == "LocalDrivingLicenseApplicationID")
            {
                dtLocalLicenseApplication.DefaultView.RowFilter = $"{cbFilter.SelectedValue} = {FilterText}";
                return;

            }

            dtLocalLicenseApplication.DefaultView.RowFilter = $"{cbFilter.SelectedValue} like '{FilterText}%'";
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterComboBox();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            txtFilter.Visible = true;

            if (cbFilter.SelectedIndex == 0)
            {
                txtFilter.Visible = false;
                return;
            }

            clsUtil.FilterdItemsCB FilterItem = (clsUtil.FilterdItemsCB)cbFilter.SelectedItem;
            txtFilter.PlaceholderText = FilterItem.PlaceHolderText;
            txtFilter.IconLeft = FilterItem.TextBoxIcon;
        }

        private void editToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {


        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {

        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //we disable those tool menu strips if certain cases exists

            bool IsApplicationStatusActive = (string)dgvLocalLicenseApplication.CurrentRow.Cells[6].Value == "New";

            //if the application is completed or cancelled you do not have to edit .
            editToolStripMenuItem.Enabled = IsApplicationStatusActive;
            tsmCancel.Enabled = IsApplicationStatusActive;
            deleteToolStripMenuItem.Enabled = IsApplicationStatusActive;



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo Info = new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalLicenseApplication.CurrentRow.Cells[0].Value);
            Info.Show();
        }

        private void tsmCancel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to cancel this Application ?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (clsLocalDrivingLicenseApplications.CancelApplicationByLocalID((int)dgvLocalLicenseApplication.CurrentRow.Cells[0].Value))
                {

                    MessageBox.Show("Application Cancelled Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Application Is Not Cancelled Successfully ", "Error Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }



            else
                return;

            _RefereshLocalLicenseDataGridView();
        }

        private void dgvLocalLicenseApplication_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void btnManageTests_Click(object sender, EventArgs e)
        {
            frmChooseTestType Choosetest = new frmChooseTestType((int)dgvLocalLicenseApplication.CurrentRow.Cells[0].Value);
            Choosetest.ShowDialog();
            _RefereshLocalLicenseDataGridView();
        }

        private void dgvLocalLicenseApplication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool IsApplicationStatusActive = (string)dgvLocalLicenseApplication.CurrentRow.Cells[6].Value == "New";
            int PassedTests = (int)dgvLocalLicenseApplication.CurrentRow.Cells[5].Value;

            //if application either is cancelled or completed and passed all 3 tests then must not enable manage test .
            btnManageTests.Enabled = IsApplicationStatusActive && PassedTests != 3;

        }

        private void ShowLicenseHistoryStripMenu_Click(object sender, EventArgs e)
        {
            string NationalNumber = (string)dgvLocalLicenseApplication.CurrentRow.Cells[2].Value;
            int PersonID = clsPeople.GetPersonIDByNationalNumber(NationalNumber);

            frmLicensesHistory LicenseHistory = new frmLicensesHistory(PersonID);
            LicenseHistory.ShowDialog();
        }
    }
}
