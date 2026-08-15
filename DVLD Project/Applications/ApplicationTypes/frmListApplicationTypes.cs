using DVLD_Project.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Application
{
    public partial class frmListApplicationTypes : Form
    {
        DataTable dtApplicaiontTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
            
        }

        private void _RefereshApplicationTypesDataGridView()
        {
            dtApplicaiontTypes = clsApplicationTypes.GetAllApplicationType();
            dgvApplicationTypes.DataSource = dtApplicaiontTypes;

            dgvApplicationTypes.EnableHeadersVisualStyles = false;

            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvApplicationTypes.ColumnHeadersDefaultCellStyle.BackColor;

            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvApplicationTypes.ColumnHeadersDefaultCellStyle.ForeColor;


        }
        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefereshApplicationTypesDataGridView();
        }

        private void _ApplyFilter()
        {
            if (!string.IsNullOrWhiteSpace(txtFilter.Text.Trim()))
                dtApplicaiontTypes.DefaultView.RowFilter = $"ApplicationTypeTitle like '{txtFilter.Text}%'";
            else
                dtApplicaiontTypes.DefaultView.RowFilter = "";

        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void dgvApplicationTypes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnEditRow.Enabled = true;


        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationTypes Update = new frmUpdateApplicationTypes((int)(dgvApplicationTypes.CurrentRow.Cells[0].Value));

            Update.ShowDialog();
            _RefereshApplicationTypesDataGridView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
        }
    }
}
