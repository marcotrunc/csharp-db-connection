using System;
using System.Data.SqlClient;

namespace csharp_db_connection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True;Pooling=False";
            using(SqlConnection conn = new SqlConnection(stringaDiConnessione))
            {
                conn.Open();

                using (SqlCommand insert = new
                     SqlCommand(@"insert into clienti (Id, nome, cognome, codice_cliente)
 values (1, 'Mario', 'Rossi', 1231515456)", conn))
                {
                    var numrows = insert.ExecuteNonQuery();
                    Console.WriteLine(numrows);
                }

                using (SqlCommand query = new SqlCommand("select * from Clienti", conn))
                {
                    SqlDataReader reader = query.ExecuteReader();
                    while (reader.Read())
                    {       
                       for(int i = 0; i <reader.FieldCount; ++i)
                            Console.Write("{0}", reader[i]);
                       Console.WriteLine();
                    }
                }
            }
        }
    }
}
