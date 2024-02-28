using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeferSeyehat
{
    public partial class Form1 : Form
    {
        //rezervasyon butonuna tıklandığında koltuk numarasına sahip butonun rengi değişti
        public Form1()
        {
            
            InitializeComponent();
            

        }
        
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2R7ER52;Initial Catalog=TestYolcuBilet;Integrated Security=True");
        void temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTelefon.Text = "";
            mskTC.Text = "";
            txtmail.Text = "";
            mskKaptanNo.Text = "";
            txtAdSoyad.Text = "";
            mskTelefonKaptan.Text = "";
            txtSeferNo.Text = "";
            txtKalkis.Text = "";
            txtVaris.Text = "";
            mskTarih.Text = "";
            mskSaat.Text = "";
            cmbKaptan.Text = "";
            txtFiyat.Text = "";
            txtSeferNo2.Text = "";
            mskTC2.Text = "";
            txtKoltukNo.Text = "";

        }
        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from seferbilgi", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void kaptanNo()
        {
            connection.Open();
            SqlCommand cmd2 = new SqlCommand("select * from Kaptan", connection);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                cmbKaptan.Items.Add(dr[1].ToString());
            }
            connection.Close();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            seferlistesi();
            kaptanNo();

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into yolcubilgi (ad,soyad,telefon,tc,cinsiyet,mail) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            sqlCommand.Parameters.AddWithValue("@p1", txtAd.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtSoyad.Text);
            sqlCommand.Parameters.AddWithValue("@p3", mskTelefon.Text);
            sqlCommand.Parameters.AddWithValue("@p4", mskTC.Text);
            sqlCommand.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            sqlCommand.Parameters.AddWithValue("@p6", txtmail.Text);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yolcu sisteme kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            temizle();
            

        }


        private void btnSeferOlustur_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into seferbilgi (kalkış,varış,tarih,saat,kaptan,fiyat) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            
            cmd.Parameters.AddWithValue("@p1", txtKalkis.Text);
            cmd.Parameters.AddWithValue("@p2", txtVaris.Text);
            cmd.Parameters.AddWithValue("@p3", mskTarih.Text);
            cmd.Parameters.AddWithValue("@p4", mskSaat.Text);
            cmd.Parameters.AddWithValue("@p5", cmbKaptan.Text);
            cmd.Parameters.AddWithValue("@p6", txtFiyat.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Sefer bilgisi sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            seferlistesi();
        }

        private void btnKaptan_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd2 = new SqlCommand("insert into kaptan (kaptanno,adsoyad,telefon) values (@p1,@p2,@p3)", connection);
            cmd2.Parameters.AddWithValue("@p1", mskKaptanNo.Text);
            cmd2.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
            cmd2.Parameters.AddWithValue("@p3", mskTelefonKaptan.Text);
            cmd2.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kaptan sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }


        private void btnRezerve_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd3 = new SqlCommand("insert into seferdetay (seferno,yolcutc,koltuk) values (@p1,@p2,@p3)", connection);
            cmd3.Parameters.AddWithValue("@p1", txtSeferNo2.Text);
            cmd3.Parameters.AddWithValue("@p2", mskTC2.Text);
            cmd3.Parameters.AddWithValue("@p3", txtKoltukNo.Text);
            cmd3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Rezervasyon ayrıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //buton rengi değiştirme
            string koltukNo = txtKoltukNo.Text;
            Button[] buttons = new Button[] {btn0,btn1,btn2,btn3,btn4,btn5,btn6,btn7,btn8,btn9 };
            foreach (Button btn in buttons)
            {
                if (btn.Text == koltukNo)
                {
                    btn.BackColor = Color.Brown;
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtSeferNo2.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "0";
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "9";
        }
    }
}
