using DVLD_Project.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.People
{
    public partial class frmPersonCard : Form
    {
        public bool _IsPersonCardDataChanged
        {
            get
            {
                return cntrlPersonCard1._IsEditFormSaved;
            }
        }

        bool _IsEditFormClosed = false;
        public frmPersonCard(int PersonID)
        {
            InitializeComponent();
            cntrlPersonCard1.LoadPersonCardByPersonID(PersonID);

      
        }


        public frmPersonCard(string NationalNumber)
        {
            InitializeComponent();
            cntrlPersonCard1.LoadPersonCardByPersonNationalNo(NationalNumber);
           
        }

        private void frmPersonCard_Load(object sender, EventArgs e)
        {
        }

        private void cntrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
