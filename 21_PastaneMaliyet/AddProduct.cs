using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastaneMaliyet
{
    public static class AddProduct
    {
        public static void AddProductTable(TextBox txtUrunAd)
        {
              string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("insert into urunler (Ad) values (@p1)", connect);
                    cmd.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
        //datagrid'ten çağırdığımız ürünün ıd'sini alarak fırınla eşleştirdi.
        //daha sonra fırın listesinde aynı ıd'nin maliyetini tek tek topladı
        public static void AddCost(TextBox txtuıd,TextBox txtUmaliyet)
        {
            //datagridview'de cellclick özelliğinde bunu çağırdık
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd2 = new SqlCommand("select sum(Maliyet) from fırın where urunıd=@p1", connect);
                cmd2.Parameters.AddWithValue("@p1", txtuıd.Text);
                SqlDataReader dr=cmd2.ExecuteReader();
                while (dr.Read())
                {
                    txtUmaliyet.Text = dr[0].ToString();
                }

            }
        }
        public static void UpdateProduct(TextBox txtUId,TextBox txtstok, TextBox txtmfiyat, TextBox txtsfiyat)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd3 = new SqlCommand("update urunler set satisadet=@p1, mfiyat=@p2, sfiyat=@p3 where urunId=@p4", connect);
                cmd3.Parameters.AddWithValue("@p1", int.Parse(txtstok.Text));
                cmd3.Parameters.AddWithValue("@p2", decimal.Parse(txtmfiyat.Text));
                cmd3.Parameters.AddWithValue("@p3", decimal.Parse(txtsfiyat.Text));
                cmd3.Parameters.AddWithValue("@p4", int.Parse(txtUId.Text));
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Ürün güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
