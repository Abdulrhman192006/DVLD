using DVLD_Project.Golbal_Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Tests
{
    public partial class frmUpdateTestTypes : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        clsTestTypes.TestType _TestTypeID;

        clsTestTypes _TestType;
        public frmUpdateTestTypes(clsTestTypes.TestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }


        private void _LoadData()
        {
            lbTestTypeID.Text = _TestTypeID.ToString();
            
            txtTestTypeTitle.Text = _TestType.TestTypeTitle;
            txtTestTypeFees.Text = _TestType.TestTypeFees.ToString();
            txtTestTypeDescription.Text = _TestType.TestTypeDescription;
        }



        private void txtTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeTitle, "This Field Must Not Be Empty");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeTitle, "");
            }

        }

        private void txtTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "This Field Must Not Be Empty");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeFees, "");
            }

            if (!clsValidations.ValidateFloat(txtTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "This Field Value Is Not Valid");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeFees, "");
            }
        }



        private void frmUpdateTestTypes_Load_1(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("Test Type Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadData();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Must fill all the info correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _TestType.TestTypeTitle = txtTestTypeTitle.Text.Trim();
            _TestType.TestTypeFees = Convert.ToDecimal(txtTestTypeFees.Text.Trim());
            _TestType.TestTypeDescription = txtTestTypeDescription.Text.Trim();

            if (_TestType.Update())
            {
                MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, (int)_TestTypeID);
            }
            else
            {
                MessageBox.Show("Error saving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void txtTestTypeDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTypeDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeDescription, "This Field Must Not Be Empty");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeDescription, "");
            }
        }
    }
}
