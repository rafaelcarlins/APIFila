using APIFila.Interface;
using APIFila.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIFila.Business
{
    public class FilaBusiness : IFila
    {
        
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rafael\\source\\repos\\APIFila\\APIFila\\DbWipro.mdf;Integrated Security=True;Connect Timeout=30");
        public bool AddItemFila(IEnumerable<ItemFila> itemFila)
        {
            SqlCommand com = new SqlCommand("SP_AddItemFila", conn);
            com.CommandType = CommandType.StoredProcedure;
            conn.Open();
            foreach (var item in itemFila)
            {
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Moeda", item.Moeda);
                com.Parameters.AddWithValue("@Data_Inicio", item.Data_Inicio);
                com.Parameters.AddWithValue("@Data_Fim", item.Data_Fim);
                
                com.ExecuteNonQuery();
                
            }
            conn.Close();
            return true;

        }

        public ItemFila GetItemFila()
        { 
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            cmd = new SqlCommand("SP_GetItemFila", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);

            ItemFila itemFila = new ItemFila();

            if (dt.Rows.Count > 0)
            {
                itemFila.Moeda = dt.Rows[0]["Moeda"].ToString();
                itemFila.Data_Inicio = (dt.Rows[0]["Data_Inicio"].ToString());
                itemFila.Data_Fim = dt.Rows[0]["Data_Fim"].ToString();

                int ID = Convert.ToInt32( dt.Rows[0]["ID"]);

                RemoveItemFila(ID);

                return itemFila;
            }
            else
            {
                return null;
            }
            
        }
        private void RemoveItemFila(int ID)
        {
            SqlCommand com = new SqlCommand("SP_DeleteItemFila", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Id", ID);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}
