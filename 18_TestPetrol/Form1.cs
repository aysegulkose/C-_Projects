using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.Remoting.Contexts;

namespace TestPetrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            PetrolDataAcces.GetPetrolValues("VMax_Kurşunsuz95", lbl95, progressBar1,lbl95D,lblkasa);
            PetrolDataAcces.GetPetrolValues("VMax_Diesel", lblmaxdizel, progressBar2,lblmaxdizelD,lblkasa);
            PetrolDataAcces.GetPetrolValues("VPro_Diesel", lblprodizel, progressBar3,lblprodizelD, lblkasa);
            PetrolDataAcces.GetPetrolValues("PoGaz_Otogaz", lblOtogaz, progressBar4,lblOtogazD, lblkasa);
            
        }

        private void nmr95_ValueChanged(object sender, EventArgs e)
        {
            PriceCalculation.GetPriceCalculate(lbl95, nmr95, txt95tutar);
        }

        private void nmrmaxdizel_ValueChanged(object sender, EventArgs e)
        {
            PriceCalculation.GetPriceCalculate(lblmaxdizel, nmrmaxdizel, txtmaxtutar);
        }

        private void nmrprodizel_ValueChanged(object sender, EventArgs e)
        {
            PriceCalculation.GetPriceCalculate(lblprodizel, nmrprodizel, txtprotutar);
        }

        private void nmrotogaz_ValueChanged(object sender, EventArgs e)
        {
            PriceCalculation.GetPriceCalculate(lblOtogaz, nmrotogaz, txtOtogaztutar);
        }

        private void btn95Dolum_Click(object sender, EventArgs e)
        {
            FillTank.GetFillTank(nmr95, txtplaka, "VMax_Kurşunsuz95", txt95tutar);
            PetrolDataAcces.GetPetrolValues("VMax_Kurşunsuz95", lbl95, progressBar1, lbl95D, lblkasa);
        }

        private void btnmaxDolum_Click(object sender, EventArgs e)
        {
            FillTank.GetFillTank(nmrmaxdizel, txtplaka, "VMax_Diesel", txtmaxtutar);
            PetrolDataAcces.GetPetrolValues("VMax_Diesel", lblmaxdizel, progressBar2, lblmaxdizelD, lblkasa);
        }

        private void btnproDolum_Click(object sender, EventArgs e)
        {
            FillTank.GetFillTank(nmrprodizel, txtplaka, "VPro_Diesel", txtprotutar);
            PetrolDataAcces.GetPetrolValues("VPro_Diesel", lblprodizel, progressBar3, lblprodizelD, lblkasa);
        }

        private void btnotogazDolum_Click(object sender, EventArgs e)
        {
            FillTank.GetFillTank(nmrotogaz, txtplaka, "PoGaz_Otogaz", txtOtogaztutar);
            PetrolDataAcces.GetPetrolValues("PoGaz_Otogaz", lblOtogaz, progressBar4, lblOtogazD, lblkasa);
        }
    }
}
