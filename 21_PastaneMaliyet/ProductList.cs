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
    public static class ProductList
    {
        public static void GetProductList(DataGridView dataGridView)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from urunler", connect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView.DataSource = dt;
                connect.Close();
            }
        }
    }
}
