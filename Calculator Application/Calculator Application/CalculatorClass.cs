using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Application
{
    public delegate T Formula<T>(T arg1, T arg2);

    public class CalculatorClass
    {
        public event Formula<double> CalculateEvent
        {
            add { Console.WriteLine("Added the Delegate"); }
            remove { Console.WriteLine("Removed the Delegate"); }
        }

        public Formula<double> info;

        public double GetSum(double num1, double num2)
        {
            return num1 + num2;
        }

        public double GetDifference(double num1, double num2)
        {
            return num1 - num2;
        }

        public double GetProduct(double num1, double num2)
        {
            return num1 * num2;
        }

        public double GetQuotient(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else
            {

                MessageBox.Show("Cannot be divided by 0.",
                                       "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return double.NaN;

            }
        }
    }
}
