using DVLD_Project.Applications;
using DVLD_Project.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Test
{
    public partial class frmListTestTypes : Form
    {
        DataTable dtApplicaiontTypes;
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void _RefereshTestTypesDataGridView()
        {
            dtApplicaiontTypes = clsTestTypes.GetAllTestType();
            dgvTestTypes.DataSource = dtApplicaiontTypes;
            
            dgvTestTypes.EnableHeadersVisualStyles = false;

            dgvTestTypes.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvTestTypes.ColumnHeadersDefaultCellStyle.BackColor;

            dgvTestTypes.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvTestTypes.ColumnHeadersDefaultCellStyle.ForeColor;


            if (dgvTestTypes.Rows.Count > 0) 
            {
                dgvTestTypes.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgvTestTypes.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            }


        }
        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _RefereshTestTypesDataGridView();
        }

        private void _ApplyFilter()
        {
            if (!string.IsNullOrWhiteSpace(txtFilter.Text.Trim()))
                dtApplicaiontTypes.DefaultView.RowFilter = $"TestTypeTitle like '{txtFilter.Text}%'";
            else
                dtApplicaiontTypes.DefaultView.RowFilter = "";

        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void dgvTestTypes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnEditRow.Enabled = true;


        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes Update = new frmUpdateTestTypes((clsTestTypes.TestType)(dgvTestTypes.CurrentRow.Cells[0].Value));

            Update.ShowDialog();
            _RefereshTestTypesDataGridView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
        }

        private void btnEditRow_Click_1(object sender, EventArgs e)
        {
            frmUpdateTestTypes Update = new frmUpdateTestTypes((clsTestTypes.TestType)(dgvTestTypes.CurrentRow.Cells[0].Value));

            Update.ShowDialog();
            _RefereshTestTypesDataGridView();
        }

        private void dgvTestTypes_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            btnEditRow.Enabled = true;

        }
    }
}
