using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;


namespace TestPetrol
{
    public static class FillTank
    {
        public static void GetFillTank(NumericUpDown nmr, TextBox plaka, string isim, TextBox tutar)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                if (nmr.Value != 0)
                {
                    SqlCommand cmd = new SqlCommand("insert into hareket (plaka,benzintür,litre,fiyat) values (@p1,@p2,@p3,@p4)", connect);
                    cmd.Parameters.AddWithValue("@p1", plaka.Text);
                    cmd.Parameters.AddWithValue("@p2", isim);
                    cmd.Parameters.AddWithValue("@p3", nmr.Value);
                    cmd.Parameters.AddWithValue("@p4", decimal.Parse(tutar.Text));
                    cmd.ExecuteNonQuery();
                    //truncate table tblHareket -> bu komut sql tablosunu sıfırlar
                }
                //kasadaki miktar değişimi

                SqlCommand cmd2 = new SqlCommand("update kasa set miktar=miktar+@p1", connect);
                cmd2.Parameters.AddWithValue("@p1", decimal.Parse(tutar.Text));
                cmd2.ExecuteNonQuery();


                //stok azalımı
                SqlCommand cmd3 = new SqlCommand("update benzin set stok=stok-@p1 where petroltür=@p2", connect);
                cmd3.Parameters.AddWithValue("@p1", nmr.Value);
                cmd3.Parameters.AddWithValue("@p2", isim);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Satış yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
