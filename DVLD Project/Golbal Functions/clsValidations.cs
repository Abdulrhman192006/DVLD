using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Golbal_Functions
{
    static class clsValidations
    {
        public static bool ValidateEmailFormat(string Email)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Email);
        }


        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateNumber(string Number)
        {
        
            return ValidateInteger(Number) || ValidateFloat(Number);
        }

        public static bool ValidateTextBoxesErrorProviders(Panel p , ErrorProvider e)
        {
            foreach (Guna2TextBox txt in p.Controls.OfType<Guna2TextBox>())
            {

                if (e.GetError(txt) != "")
                {
                    return false;
                }

            }

            return true;
        }

        public static bool ValidateTextBoxesErrorProviders(Form f, ErrorProvider e)
        {
            foreach (Guna2TextBox txt in f.Controls.OfType<Guna2TextBox>())
            {

                if (e.GetError(txt) != "")
                {
                    return false;
                }

            }

            return true;
        }


    }
}
