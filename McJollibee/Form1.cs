using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McJollibee
{

    public partial class Form1 : Form
    {
        const double Price_ChickenwRice = 50.00;
        const double Price_Burger = 30.00;
        const double Price_SoftDrinks = 15.00;
        const double Vat_Rate = 0.15;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enabletxtboxes();
            //===combo box===//
            Payment.Items.Add("Cash");
        }
        //=========enable text boxes========//
        private void enabletxtboxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Enabled = false;
                    else
                        func(control.Controls);
            };
            func(Controls);

        }
        //========Chicken with Rice==========//
        private void CwR_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CwR.Checked == true)
            {
                CwRbox.Enabled = true;
                CwRbox.Text = "";
                CwRbox.Focus();

            }
            else
            {
                CwRbox.Enabled = false;
                CwRbox.Text = "0";
                
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        //========Burger==========//
        private void BG_CheckedChanged_1(object sender, EventArgs e)
        {
            if (BG.Checked == true)
            {
                BGbox.Enabled = true;
                BGbox.Text = "";
                BGbox.Focus();
            }
            else
            {
                BGbox.Enabled = false;
                BGbox.Text = "0";
            }
        }

        //========SoftDrinks==========//
        private void SD_CheckedChanged_1(object sender, EventArgs e)
        {
            if (SD.Checked == true)
            {
                SDbox.Enabled = true;
                SDbox.Text = "";
                SDbox.Focus();
            }

        }
        private void CwRbox_Leave(object sender, EventArgs e)
        {
            double a, TP, TPV, FVP;
            a = Convert.ToDouble(CwRbox.Text) * Price_ChickenwRice;
            TP = a;
            TPbox.Text = String.Format("{0:C}", "\u20B1" + TP);
            TPV = (TP * Vat_Rate);
            VaTBox.Text = String.Format("{0:C}", "\u20B1" + TPV);
            FVP = (TPV + TP);
            TPVBox.Text = String.Format("{0:C}", "\u20B1" + FVP);
        }
        private void BGbox_Leave(object sender, EventArgs e)
        {
            double b,TP, TPV, FVP;
            
            b = Convert.ToDouble(BGbox.Text) * Price_Burger;
            TP =  b;
            TPbox.Text = String.Format("{0:C}", "\u20B1" + TP);
            TPV = (TP * Vat_Rate);
            VaTBox.Text = String.Format("{0:C}", "\u20B1" + TPV);
            FVP = (TPV + TP);
            TPVBox.Text = String.Format("{0:C}", "\u20B1" + FVP);
        }
        private void SDbox_Leave(object sender, EventArgs e)
        {
            double a, b, c, TP, TPV, FVP;
            a = Convert.ToDouble(CwRbox.Text) * Price_ChickenwRice;
            b = Convert.ToDouble(BGbox.Text) * Price_Burger;
            c = Convert.ToDouble(SDbox.Text) * Price_SoftDrinks;
            TP = a + b + c;
            TPbox.Text = String.Format("{0:C}", "\u20B1" + TP);
            TPV = (TP * Vat_Rate);
            VaTBox.Text = String.Format("{0:C}", "\u20B1" + TPV);
            FVP = (TPV + TP);
            TPVBox.Text = String.Format("{0:C}", "\u20B1" + FVP);

        }

        private void Money_Leave(object sender, EventArgs e)
        {
            double a, b, c, TP, TPV, FVP, cost, change;
       
            a = Convert.ToDouble(CwRbox.Text) * Price_ChickenwRice;
            b = Convert.ToDouble(BGbox.Text) * Price_Burger;
            c = Convert.ToDouble(SDbox.Text) * Price_SoftDrinks;
            TP = a + b + c;
            TPbox.Text = String.Format("{0:C}", "\u20B1" + TP);
            TPV = (TP * Vat_Rate);
            VaTBox.Text = String.Format("{0:C}", "\u20B1" + TPV);
            FVP = (TPV + TP);
            TPVBox.Text = String.Format("{0:C}", "\u20B1" + FVP);
            if (Payment.Text == "Cash")
            {
                change = Convert.ToDouble(Money.Text);
                cost = change - FVP;
                Cbox.Text = Convert.ToString(cost);
                Cbox.Text = String.Format("{0:C}", "\u20B1" + cost);

            }

        }

        //====pay method + cash=======//
        private void Payment_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Payment.Text == "Cash")
            {
                Money.Enabled = true;
                Money.Text = "";
                Money.Focus();
            }
            else
            {
                Money.Enabled = false;
                Money.Text = "0";
            }

        }

      

       
    }
        
}
