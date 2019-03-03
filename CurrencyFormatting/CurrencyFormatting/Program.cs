using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = 1234567.89;
            string display;

            display = "InvariantInfo: " +
                money.ToString("C", NumberFormatInfo.InvariantInfo) +
                Environment.NewLine;

            display += "CurrentInfo: " +
                money.ToString("C", NumberFormatInfo.CurrentInfo) +
                Environment.NewLine;

            NumberFormatInfo info = new NumberFormatInfo();
            info.CurrencySymbol = "\x20AC";
            info.CurrencyPositivePattern = 3;
            info.CurrencyNegativePattern = 8;

            display += "CustomInfo: " +
                money.ToString("C", info);

            MessageBox.Show(display, "Currency Formatting");
        }
    }
}
