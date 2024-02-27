using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastaneMaliyet
{
    public static class AddMaterial
    {
        //Malzeme ekleme butonu
        public static void AddMaterialTable(TextBox txtMAd, TextBox txtMStok, TextBox txtMFiyat, RichTextBox rchNot)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString; 
            string stok = txtMStok.Text;
            string fiyat = txtMFiyat.Text;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("insert into malzemeler (Ad, stok, fiyat,notlar) values (@p1,@p2,@p3,@p4)", connect);
                cmd.Parameters.AddWithValue("@p1", txtMAd.Text);
                cmd.Parameters.AddWithValue("@p2", decimal.Parse(stok));
                cmd.Parameters.AddWithValue("@p3", decimal.Parse(fiyat));
                cmd.Parameters.AddWithValue("@p4", rchNot.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Malzeme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Malzeme getirme butonu
       
        public static void GetMaterial(TextBox txtmıd, TextBox txtMAd, TextBox txtMStok, TextBox txtFiyat, RichTextBox rchNot)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd2 = new SqlCommand("select * from malzemeler where Ad=@p1", connect);
                cmd2.Parameters.AddWithValue("@p1", txtMAd.Text);
                SqlDataReader dr=cmd2.ExecuteReader();
                while (dr.Read())
                {
                    txtmıd.Text = dr[0].ToString();
                    txtMStok.Text = dr[2].ToString();
                    txtFiyat.Text = dr[3].ToString();
                    rchNot.Text = dr[4].ToString();
                }
                
            }
        }
        //Malzeme Güncelle butonu
        public static void UpdateMaterial(TextBox txtmıd, TextBox txtMAd, TextBox txtMStok, TextBox txtFiyat, RichTextBox rchNot)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd3 = new SqlCommand("update malzemeler set ad=@p1, stok=@p2, fiyat=@p3, notlar=@p4 where malzemeıd=@p5", connect);
                cmd3.Parameters.AddWithValue("@p1", txtMAd.Text);
                cmd3.Parameters.AddWithValue("@p2", decimal.Parse(txtMStok.Text));
                cmd3.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
                cmd3.Parameters.AddWithValue("@p4", rchNot.Text);
                cmd3.Parameters.AddWithValue("@p5", int.Parse(txtmıd.Text));
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Malzeme güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

