using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastaneMaliyet
{
    public static class AddCmb
    {
        public static void AddCmbProduct(ComboBox cmbBox,ComboBox comboBox)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from urunler", connect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbBox.ValueMember = "UrunId";
                cmbBox.DisplayMember = "Ad";
                cmbBox.DataSource = dt;
            }
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select * from malzemeler", connect);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                comboBox.ValueMember = "MalzemeId";
                comboBox.DisplayMember = "Ad";
                comboBox.DataSource = dt2;
            }
        }
    }
}
