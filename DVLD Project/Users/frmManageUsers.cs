using DVLD_BuisnessLayer;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Properties;
using DVLD_Project.Users.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Users
{
    public partial class frmManageUsers : Form
    {

        DataTable dtUsers;
        DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();


        public frmManageUsers()
        {
            InitializeComponent();
        }



        private void _LoadDataGridViewUsers()
        {
            lbNoRecords.Visible = false;

            dtUsers = clsUsers.GetAllUsers();
            dgvUsers.DataSource = dtUsers;

            //we check if there is record , becuase if there is not 
            //and we did not check it will give run time error
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[2].HeaderText = "User Name";
                dgvUsers.Columns[3].HeaderText = "Full Name";
                dgvUsers.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvUsers.Columns[4].HeaderText = "Is Active";
            }

            else
            {
                lbNoRecords.Visible = true;

            }
            dgvUsers.EnableHeadersVisualStyles = false;

            dgvUsers.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvUsers.ColumnHeadersDefaultCellStyle.BackColor;

            dgvUsers.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor;

            //add the action column once 
            if (!dgvUsers.Columns.Contains(actionColumn))
            {
                actionColumn.Name = "Actions";
                actionColumn.HeaderText = "";
                actionColumn.Text = "⋮";
                actionColumn.UseColumnTextForButtonValue = true;
                actionColumn.Width = 40;
                actionColumn.FlatStyle = FlatStyle.Standard;
                dgvUsers.Columns.Add(actionColumn);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvUsers.Columns[e.ColumnIndex].Name == "Actions")
            {


                Rectangle rect = dgvUsers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                cmsUsers.Show(dgvUsers,
                    rect.Left,
                    rect.Bottom);
            }
        }

        private void _LoadComboBoxFilter()
        {

            //Set the source data for the filterd combo box
            clsUtil.FilterdItemsCB[] CBItemsArr = {new  clsUtil.FilterdItemsCB("None" , "None","",null),new  clsUtil.FilterdItemsCB("User ID" , "UserID","Enter User ID", Resources.card),
                new clsUtil.FilterdItemsCB("Person ID" , "PersonID","Enter Person ID", Resources.card) ,new clsUtil.FilterdItemsCB("Is Active", "IsActive","",null) ,
             new clsUtil.FilterdItemsCB("Full Name" , "FullName","Enter Full Name", Resources.person_boy) ,  new clsUtil.FilterdItemsCB("User Name" , "UserName","Enter User Name", Resources.geography__1_)};


            cbFilter.DataSource = CBItemsArr;
            cbFilter.DisplayMember = "Name";
            cbFilter.ValueMember = "ColumnName";

            cbFilter.SelectedIndex = 0;
        }


        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadDataGridViewUsers();
            _LoadComboBoxFilter();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser();
            addEditUser.ShowDialog();
            _LoadDataGridViewUsers();

        }

        private void cmsUsers_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddEditUser addEdit = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells["UserID"].Value);
            addEdit.ShowDialog();
            _LoadDataGridViewUsers();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (clsUsers.DeleteUser((int)dgvUsers.CurrentRow.Cells["UserID"].Value))
                {

                    MessageBox.Show("User Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("User Data Is Connected To Another Components", "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }


            //Cancel delete
            else
                return;

         
            _LoadDataGridViewUsers();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userCard = new frmUserInfo((int)dgvUsers.CurrentRow.Cells["UserID"].Value);
            userCard.ShowDialog();

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
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

        private void _FilterComboBox()
        {
            string FilterText = txtFilter.Text.Trim();


            if (string.IsNullOrWhiteSpace(FilterText) || cbFilter.SelectedValue == "None")
            {

                //If the text box filter empty or the cb is none we just reset the 
                //row filter to restore back all data from the data grid view
                dtUsers.DefaultView.RowFilter = "";
                return;
            }

            if (cbFilter.SelectedValue == "PersonID" ||
               cbFilter.SelectedValue == "UserID")
            {
                dtUsers.DefaultView.RowFilter = $"{cbFilter.SelectedValue} = {FilterText}";
                return;

            }

            dtUsers.DefaultView.RowFilter = $"{cbFilter.SelectedValue} like '{FilterText}%'";
        }


        private void _FilterActiveComboBox()
        {
            string FilterItem = "IsActive";


            //Index 0 = Yes
            if (cbActiveUser.SelectedIndex == 0)
            {
                dtUsers.DefaultView.RowFilter = $"{FilterItem} = 1";
                return;
            }

            //Index 1 = No
            if (cbActiveUser.SelectedIndex == 1)
            {
                dtUsers.DefaultView.RowFilter = $"{FilterItem} = 0";
                return;
            }

            //Index 2 = All
            dtUsers.DefaultView.RowFilter = "";
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
            if (cbFilter.SelectedValue == "PersonID" || cbFilter.SelectedValue == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }

        private void cbActiveUser_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _FilterActiveComboBox();
        }
    }
}
