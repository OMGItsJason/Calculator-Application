using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Application
{
    public partial class FrmCalculatore : Form
    {
        public FrmCalculatore()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            string[] status = { "+", "-", "*", "/" };
            foreach (string m in status)
            {
                cb0perator.Items.Add(m);
            }
        }


        CalculatorClass cal = new CalculatorClass();
        double num1;
        double num2;

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxInput1.Text) || String.IsNullOrWhiteSpace(textBoxInput2.Text))
            {
                MessageBox.Show("Please input numbers");
            }
            else
            {


                num1 = Convert.ToDouble(textBoxInput1.Text);
                num2 = Convert.ToDouble(textBoxInput2.Text);

                string selectedOperator = cb0perator.SelectedItem.ToString();



                switch (selectedOperator)
                {
                    case "+":
                        cal.CalculateEvent += new Formula<double>(cal.GetSum);
                        lblDisplayTotal.Text = cal.GetSum(num1, num2).ToString();
                        cal.CalculateEvent -= new Formula<double>(cal.GetSum);
                        break;
                    case "-":
                        cal.CalculateEvent += new Formula<double>(cal.GetDifference);
                        lblDisplayTotal.Text = cal.GetDifference(num1, num2).ToString();
                        cal.CalculateEvent -= new Formula<double>(cal.GetDifference);
                        break;
                    case "*":
                        cal.CalculateEvent += new Formula<double>(cal.GetProduct);
                        lblDisplayTotal.Text = cal.GetProduct(num1, num2).ToString();
                        cal.CalculateEvent -= new Formula<double>(cal.GetProduct);
                        break;
                    case "/":
                        cal.CalculateEvent += new Formula<double>(cal.GetQuotient);
                        lblDisplayTotal.Text = cal.GetQuotient(num1, num2).ToString();
                        cal.CalculateEvent -= new Formula<double>(cal.GetQuotient);
                        break;
                    default:
                        Console.WriteLine("Invalid operator selected.");
                        break;
                }
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxInput1.Clear();
            textBoxInput2.Clear();
            cb0perator.SelectedIndex = -1;
            lblDisplayTotal.Text = "";
        }

        private void textBoxInput1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;           
            }
        }

        private void textBoxInput2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
