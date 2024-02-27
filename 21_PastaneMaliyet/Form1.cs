using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PastaneMaliyet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductList.GetProductList(dataGridView1);
            AddCmb.AddCmbProduct(cmbUrun, cmbMalzeme);
            Case.GetCase(dataGridView2);
        }

        private void btnUrunliste_Click(object sender, EventArgs e)
        {
            ProductList.GetProductList(dataGridView1);
        }
        private void btnKasa_Click(object sender, EventArgs e)
        {
            Case.GetCase(dataGridView1);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMEkle_Click(object sender, EventArgs e)
        {
            AddMaterial.AddMaterialTable(txtMad, txtMStok, txtFiyat, richTextBox1);
            AddCmb.AddCmbProduct(cmbUrun, cmbMalzeme);
            MaterialList.GetMaterialList(dataGridView1);
        }

        private void btnUEkle_Click(object sender, EventArgs e)
        {
            AddProduct.AddProductTable(txtUAd);
            AddCmb.AddCmbProduct(cmbUrun,cmbMalzeme);
            ProductList.GetProductList(dataGridView1);
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            CreateProduct.CreateProductList(cmbUrun, cmbMalzeme, txtMiktar, txtMaliyet, listBox1);
            CreateProduct.CreateList(listBox1, cmbUrun);

        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            
            if (txtMiktar.Text == "")
            {
                txtMiktar.Text = "0";
            }
            CreateProduct.CalculateCost(cmbMalzeme, txtMaliyet, txtMiktar);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtUId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtUAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtUSAdet.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSFiyat.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            AddProduct.AddCost(txtUId, txtMFiyat);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            AddProduct.UpdateProduct(txtUId, txtUSAdet, txtMFiyat, txtSFiyat);
            ProductList.GetProductList(dataGridView1);
        }

        private void btnMGuncelle_Click(object sender, EventArgs e)
        {
            AddMaterial.UpdateMaterial(txtMId, txtMad, txtMStok, txtFiyat, richTextBox1);
            MaterialList.GetMaterialList(dataGridView1);
        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateProduct.CreateList(listBox1, cmbUrun);
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            AddMaterial.GetMaterial(txtMId, txtMad, txtMStok, txtFiyat, richTextBox1);
        }

        private void btnMListe_Click_1(object sender, EventArgs e)
        {
            MaterialList.GetMaterialList(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Case.AddCostInputOutput(txtMFiyat, txtSFiyat,txtUSAdet);
            Case.GetCase(dataGridView2);
        }

    }
}
