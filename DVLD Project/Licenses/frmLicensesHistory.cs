using DVLD_BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Licenses
{
    public partial class frmLicensesHistory : Form
    {
        DataTable dtLocalLicenses;
        DataTable dtInternationalLicense;

        int _PersonID = -1;

        int _DriverID = -1;
        clsDrivers _Driver;


        public frmLicensesHistory()
        {
            InitializeComponent();

        }
        public frmLicensesHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

        }



        private void _LoadInternationalLicenseGridView()
        {
            dtInternationalLicense = clsInternationalLicenses.GetAllDriverInternationalLicenses(_DriverID);
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
                dgvInternationalLicense.Columns[2].HeaderText = "Local License ID";
                dgvInternationalLicense.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvInternationalLicense.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicense.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvInternationalLicense.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicense.Columns[5].HeaderText = "Is Active";

            }
        }
        private void _LoadLicenseGridView()
        {
            dtLocalLicenses = clsLicenses.GetDriverLicenses(_DriverID);
            dgvLocalLicenses.DataSource = dtLocalLicenses;

            dgvLocalLicenses.EnableHeadersVisualStyles = false;

            dgvLocalLicenses.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvLocalLicenses.ColumnHeadersDefaultCellStyle.BackColor;

            dgvLocalLicenses.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvLocalLicenses.ColumnHeadersDefaultCellStyle.ForeColor;

            if (dgvLocalLicenses.Rows.Count > 0)
            {
                dgvLocalLicenses.Columns[0].HeaderText = "License ID";
                dgvLocalLicenses.Columns[1].HeaderText = "Application ID";
                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenses.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[5].HeaderText = "Is Active";

            }
        }

        private void cntrlPersonCardWithFilter_OnPersonSelected(int PersonID)
        {
            if(PersonID != -1)
            {

                _DriverID = clsDrivers.GetDriverIDByPersonID(PersonID);
                _LoadDataGridViewsDate();

            }
            //if person id was -1 when the event was fired then no person was found 
            // so we clear the grid view 
            else
            {
                ClearGridViewsData();
            }
        }
        private void _LoadPersonInfo()
        {
            cntrlPersonCardWithFilter1.LoadPerson(_PersonID);
            cntrlPersonCardWithFilter1.Enabled = false;
        }

        private void _LoadDataGridViewsDate()
        {
            _LoadLicenseGridView();
            _LoadInternationalLicenseGridView();
        }
        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {            //subscribe to the event

            cntrlPersonCardWithFilter1.OnPersonSelected += cntrlPersonCardWithFilter_OnPersonSelected;

            if (_PersonID != -1)
            {
                _DriverID = clsDrivers.GetDriverIDByPersonID(_PersonID);

                if (_DriverID == -1)
                {
                    MessageBox.Show("Error Loading Driver", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _LoadPersonInfo();
                _LoadDataGridViewsDate();
            }

            //in case there is no driver if was sent then the default value will be -1
            //so we enable the filter card to let the user to search for the person
            else
            {
                cntrlPersonCardWithFilter1.Enabled = true;
            }

        }

        private void cntrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmDriversInfo frmDriversInfo = new frmDriversInfo((int)dgvLocalLicenses.CurrentRow.Cells["LicenseID"].Value);
            frmDriversInfo.ShowDialog();

        }


        private void ClearGridViewsData()
        {
            dgvLocalLicenses.DataSource = null;
            dgvInternationalLicense.DataSource = null;
        }

        private void cntrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
