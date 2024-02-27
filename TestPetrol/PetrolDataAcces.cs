using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPetrol
{

    public static class PetrolDataAcces
    {
        
        public static void GetPetrolValues(string petrolTur, Label label, ProgressBar progressBar,Label stokAded,Label lblkasa)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
           
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from benzin where petroltür=@p1", connect);
                cmd.Parameters.AddWithValue("@p1", petrolTur);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label.Text = dr[3].ToString();
                    progressBar.Value = Convert.ToInt32(dr[4].ToString());
                    stokAded.Text = dr[4].ToString();
                }
                connect.Close();
                connect.Open();
                SqlCommand cmd2 = new SqlCommand("select * from kasa", connect);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    lblkasa.Text = dr2[0].ToString();
                }
                connect.Close();
            }
            
        }
    }
}
