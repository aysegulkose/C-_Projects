using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastaneMaliyet
{
    public static class Case
    {
        public static void GetCase(DataGridView dataGridView)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from kasa", connect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView.DataSource = dt;
                connect.Close();
            }
        }
        public static void AddCostInputOutput(TextBox mfiyat, TextBox sfiyat,TextBox txtusadet)
        {
            decimal maliyet = decimal.Parse(mfiyat.Text)*decimal.Parse(txtusadet.Text);
            decimal satis = decimal.Parse(sfiyat.Text) * decimal.Parse(txtusadet.Text);
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("update kasa set gırıs=gırıs+@p1", connect);
                SqlCommand cmd2 = new SqlCommand("update kasa set cıkıs=cıkıs+@p2", connect);
                cmd.Parameters.AddWithValue("@p1", maliyet);
                cmd2.Parameters.AddWithValue("@p2", satis);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Fiyatlar güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
