using DVLD_Project.Controls;
using DVLD_Project.Golbal_Functions;
using DVLD_Project.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD_Project.People
{
    public partial class cntrlManagePeople : UserControl
    {
        DataTable dtPeople;

        public cntrlManagePeople()
        {
            InitializeComponent();
        }

        private void _LoadDataGridViewPeople()
        {

             dtPeople = clsPeople.GetAllPeopleSelectedColumns();


            dgvPeople.DataSource = dtPeople;
                                                                            
            dgvPeople.EnableHeadersVisualStyles = false;

            dgvPeople.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvPeople.ColumnHeadersDefaultCellStyle.BackColor;

            dgvPeople.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvPeople.ColumnHeadersDefaultCellStyle.ForeColor;

        }

        private void _LoadComboBoxFilter()
        {

            //Set the source data for the filterd combo box
            clsUtil.FilterdItemsCB[] CBItemsArr = {new  clsUtil.FilterdItemsCB("None" , "None" , "" , null),new  clsUtil.FilterdItemsCB("Person ID" , "PersonID","Enter Person ID", Resources.card),
                new clsUtil.FilterdItemsCB("National Number" , "NationalNo","Enter National Number", Resources.card) ,new clsUtil.FilterdItemsCB("First Name", "FirstName","Enter First Name", Resources.person_boy) ,
             new clsUtil.FilterdItemsCB("Second Name" , "SecondName","Enter Second Name", Resources.person_boy) ,  new clsUtil.FilterdItemsCB("Third Name" , "ThirdName","Enter Third Name", Resources.person_boy) ,
             new clsUtil.FilterdItemsCB("Last Name" , "LastName","Enter Last Name", Resources.person_boy) ,  new clsUtil.FilterdItemsCB("Nationality" , "Nationality","Enter Nationality", Resources.geography__1_) ,
            new clsUtil.FilterdItemsCB("Gender" , "Gender","",null) , new clsUtil.FilterdItemsCB("Phone" , "Phone","Enter Phone Number", Resources.phone),new clsUtil.FilterdItemsCB("Email" , "Email","Enter Email", Resources.mail__1_)};


            cbFilter.DataSource = CBItemsArr;
            cbFilter.DisplayMember = "Name";
            cbFilter.ValueMember = "ColumnName";


            cbFilter.SelectedIndex = 0;
        }
        private void cntrlManagePeople_Load(object sender, EventArgs e)
        {

            _LoadComboBoxFilter();

            _LoadDataGridViewPeople();
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            // Add new person
            frmAddEdit frm = new frmAddEdit();

            frm.ShowDialog();
            _LoadDataGridViewPeople();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Edit selected person
            frmAddEdit edit = new frmAddEdit((int)dgvPeople.CurrentRow.Cells[0].Value);
            edit.ShowDialog();
            _LoadDataGridViewPeople();
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPeople Person = clsPeople.FindPersonByID((int)dgvPeople.CurrentRow.Cells[0].Value);
            string imagepath = Person.ImagePath;

            if (MessageBox.Show("Are you sure you want to delete this person ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (clsPeople.DeletePerson(Person.PersonID))
                {

                    if (!string.IsNullOrEmpty(imagepath))
                    {

                        try
                        {
                            //delete person image file from the folder 
                            System.IO.File.Delete(imagepath);
                        }
                        catch
                        {
                            MessageBox.Show("Error Deleting Person Photo", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;

                        }
                    }

                    MessageBox.Show("Person Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Person Data Is Connected To Another Components", "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }


            //Cancel delete
            else
                return;

                _LoadDataGridViewPeople();

        }
        


        private void _FilterComboBoxItem()
        {
            string FilterText = txtFilter.Text.Trim();


            if (string.IsNullOrWhiteSpace(FilterText) || cbFilter.SelectedValue == "None")
            {

                //If the text box filter empty or the cb is null we just reset the 
                //row filter to restore back all data from the data grid view
                dtPeople.DefaultView.RowFilter = "";
                return;
            }

            if(cbFilter.SelectedValue == "PersonID")
            {
               dtPeople.DefaultView.RowFilter = $"{cbFilter.SelectedValue} = {FilterText}";
                return;

            }

           dtPeople.DefaultView.RowFilter = $"{cbFilter.SelectedValue} like '{FilterText}%'";

        }



        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilter.Text = string.Empty;
            txtFilter.Visible = true;
            btnMale.Visible = false;
            btnFemale.Visible = false;


            if (cbFilter.SelectedIndex == 0) //None
            {
                txtFilter.Visible = false;
                return;
            }

            if (cbFilter.SelectedValue == "Gender")
            {
                txtFilter.Visible = false;
                btnMale.Visible = true;
                btnFemale.Visible = true;
                return;
            }

            //We convert the selected item in the combo box after connecting it to the array to class filter item , and then use all the propreties
            clsUtil.FilterdItemsCB FilterItem = (clsUtil.FilterdItemsCB)cbFilter.SelectedItem;
            txtFilter.PlaceholderText = FilterItem.PlaceHolderText;
            txtFilter.IconLeft = FilterItem.TextBoxIcon;

            
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterComboBoxItem();
        }

        private void btnMale_Click_1(object sender, EventArgs e)
        {
            //Whene selecting male we type in the text filter male to filter for male 
            cbFilter.SelectedValue= "Gender";
            txtFilter.Text = "Male";

        }

        private void btnFemale_Click(object sender, EventArgs e)
        {
            cbFilter.SelectedValue = "Gender";
            txtFilter.Text = "Female";


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            cbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
            btnFemale.Visible = false;
            btnMale.Visible = false;


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPersonCard PersonCard = new frmPersonCard((int)dgvPeople.CurrentRow.Cells[0].Value);
            PersonCard.ShowDialog();

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //When selecting person id , the text box will make you only type numbers
            if (cbFilter.Text == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }
    }
}
