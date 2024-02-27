using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace TestPetrol
{
    public static class PriceCalculation
    {
        public static void GetPriceCalculate(Label deger, NumericUpDown nmrUpDown, TextBox txtTutar)
        {
            double litreDeger, litre, tutar;
            litreDeger = Convert.ToDouble(deger.Text);
            litre = Convert.ToDouble(nmrUpDown.Value);
            tutar = litreDeger * litre;
            txtTutar.Text = tutar.ToString();
        }
    }
}
