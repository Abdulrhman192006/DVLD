using DVLD_Project.Golbal_Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.People.Controls
{
    public partial class cntrlPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;

        public int PersonID
        {
            get
            {
                return cntrlPersonCard1.PersonID;
            }
        }

        public bool EnablePersonCardWithFilter
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
        public void LoadPerson(int PersonID)
        {

            cntrlPersonCard1.LoadPersonCardByPersonID(PersonID);
            txtFilter.Text = PersonID.ToString();

        }
        public cntrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void _FindPerson()
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                MessageBox.Show("No Value Was Entered To Search For!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbFilter.SelectedItem == "Person ID")
            {

                cntrlPersonCard1.LoadPersonCardByPersonID(Convert.ToInt16(txtFilter.Text.Trim()));
            }

            else if (cbFilter.SelectedItem == "National Number")
            {

                cntrlPersonCard1.LoadPersonCardByPersonNationalNo(txtFilter.Text.Trim());
            }

            OnPersonSelected?.Invoke(cntrlPersonCard1.PersonID);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindPerson();

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

            if (cbFilter.SelectedItem == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";

            if (cbFilter.SelectedItem == "Person ID")
                txtFilter.PlaceholderText = "Enter Person ID";
            else
                txtFilter.PlaceholderText = "Enter National Number";
        }

        private void _LoadAddedPerson(object sender, int PersonID)
        {
            cntrlPersonCard1.LoadPersonCardByPersonID(PersonID);
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEdit Add = new frmAddEdit();
            Add.DataBack += _LoadAddedPerson;
            Add.ShowDialog();
        }

        private void cntrlPersonCard1_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txtFilter.Focus();
        }
    }
}
