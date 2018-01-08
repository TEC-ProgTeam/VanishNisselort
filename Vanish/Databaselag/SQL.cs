using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;


namespace Vanish.Databaselag
{
    public class SQL
    {
        private static string ConnectionStreng = "Data Source=TEC-5350-LA0052\\SQLEXPRESS;Initial Catalog=AutoDB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // SqlConnection connection = new SqlConnection();
        public void getConnection()
        {
            // her henter jeg en textfil tror jeg - har vi ikke talt om
        }

        public static void insert(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionStreng))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.ExecuteNonQuery();
            }
        }
        // using System.Data.SqlClient; dette namespace skal være 4.4.2
        public static DataTable Select(string sql)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionStreng))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
                //DataTable table = new DataTable();
                adapter.Fill(table);

            }

            return table;
        }

        public List<object> SelectList(string sql)
        {
            return new List<object>();
        }
    }
}
