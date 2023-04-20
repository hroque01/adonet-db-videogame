using System.Data.SqlClient;

namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Apertura connessione
            string stringConnection = "Data Source=localhost;Initial Catalog=test;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(stringConnection);      
        }
    }
}