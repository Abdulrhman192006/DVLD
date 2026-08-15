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

namespace DVLD_Project.Applications
{
    public partial class frmUpdateApplicationTypes : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        int _ApplicationTypeID;

        clsApplicationTypes _ApplicationType;
        public frmUpdateApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }


        private void _LoadData()
        {
            lbApplicationTypeID.Text = _ApplicationTypeID.ToString();

            txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtApplicationTypeFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
        }



        private void txtApplicationTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApplicationTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeTitle, "This Field Must Not Be Empty");
            }
            else
            {
                errorProvider1.SetError(txtApplicationTypeTitle, "");
            }

        }

        private void txtApplicationTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApplicationTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeFees, "This Field Must Not Be Empty");
            }
            else
            {
                errorProvider1.SetError(txtApplicationTypeFees, "");
            }

            if (!clsValidations.ValidateFloat(txtApplicationTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeFees, "This Field Value Is Not Valid");
            }
            else
            {
                errorProvider1.SetError(txtApplicationTypeFees, "");
            }
        }

        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);

            if (_ApplicationType == null)
            {
                MessageBox.Show("Application Type Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadData();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Must fill all the info correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _ApplicationType.ApplicationTypeTitle = txtApplicationTypeTitle.Text.Trim();
            _ApplicationType.ApplicationTypeFees = Convert.ToDecimal(txtApplicationTypeFees.Text.Trim());


            if (_ApplicationType.Update())
            {
                MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _ApplicationTypeID);
            }
            else
            {
                MessageBox.Show("Error saving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
