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
    public static class CreateProduct
    {
        public static void CreateProductList(ComboBox cmburun, ComboBox cmbmalzeme, TextBox miktar, TextBox maliyet, ListBox listBox)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("insert into fırın (urunıd,malzemeıd,miktar,maliyet) values (@p1,@p2,@p3,@p4)", connect);
                cmd.Parameters.AddWithValue("@p1", cmburun.SelectedValue);
                cmd.Parameters.AddWithValue("@p2", cmbmalzeme.SelectedValue);
                cmd.Parameters.AddWithValue("@p3", decimal.Parse(miktar.Text));
                cmd.Parameters.AddWithValue("@p4", decimal.Parse(maliyet.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }
        public static void CreateList(ListBox listBox, ComboBox comboBox)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                connect.Open();
                SqlCommand cmd = new SqlCommand("execute Urunlistesi", connect);
                SqlDataReader dr = cmd.ExecuteReader();
                listBox.Items.Clear();
                while (dr.Read())
                {
                    if (comboBox.Text == dr[0].ToString())
                    {
                        listBox.Items.Add(dr[0].ToString() + " - " + dr[1].ToString() + " - " + dr[2].ToString()+ " - " +dr[3].ToString());
                    }
                }
            }
        }
        public static void CalculateCost(ComboBox cmbmalzeme, TextBox txtmaliyet, TextBox txtmiktar)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                double maliyet;
                connect.Open();
                SqlCommand cmd2 = new SqlCommand("select * from malzemeler where malzemeId=@p1", connect);
                cmd2.Parameters.AddWithValue("@p1", cmbmalzeme.SelectedValue);
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    double malzemeFiyati = Convert.ToDouble(dr["Fiyat"]);
                    if (malzemeFiyati == 2.00)
                    {
                        maliyet = malzemeFiyati * Convert.ToDouble(txtmiktar.Text);
                    }
                    else
                    {
                        maliyet = (malzemeFiyati / 1000) * Convert.ToDouble(txtmiktar.Text);
                    }
                    txtmaliyet.Text = maliyet.ToString();
                }
            }
        }
    }
}
