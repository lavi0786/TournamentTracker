using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                PrizeModel model = new PrizeModel(placeNameValue.Text, placeNumberValue.Text, prizeAmountValue.Text,
                    pricePercentageValue.Text);

                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again.");
            }
            placeNameValue.Text = "";
            placeNumberValue.Text = "";
            prizeAmountValue.Text = "0";
            pricePercentageValue.Text = "0";

        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNameValue.Text, out placeNumber);
            
            if(placeNumberValidNumber == false)
            {
                output = false;
            }

            if(placeNumber < 1)
            {
                output = false;
            }

            if(placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmoutValidNumber = decimal.TryParse(placeNameValue.Text,out prizeAmount);
            bool prizePercentageValidNumber = double.TryParse(pricePercentageValue.Text, out prizePercentage);

            if(prizeAmoutValidNumber == false || prizePercentageValidNumber == false) 
            { 
            output = false;
            }

            if(prizeAmount <= 0 || prizePercentage <= 0)
            {
                output = false;
            }

            if(prizePercentage<0 || prizePercentage >100)
            {
                output = false;
            }
            return output;          
        }
    }
}
