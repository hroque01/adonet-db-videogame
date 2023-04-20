using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class VideogameManager
    {
        private readonly string connectionString;

        public VideogameManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InserisciVideogame(Videogame videogame)
        {
            //istanzio l'using
            using (SqlConnection  conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var sql = $"INSERT INTO videogames (name, overview, release_date, created_at, update_at, software_house_id)" +
                        $"OUTPUT INSERTED.ID" +
                        $"VALUES (@Name, @Overview, @Release_date, @Creted_at, @Update_at, Software_house_id)";
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", videogame.Name);
                        cmd.Parameters.AddWithValue("@Overview", videogame.Overview);
                        cmd.Parameters.AddWithValue("@Release_date", videogame.Release_date);
                        cmd.Parameters.AddWithValue("@Creted_at", videogame.Created_at);
                        cmd.Parameters.AddWithValue("@Update_at", videogame.Update_at);
                        cmd.Parameters.AddWithValue("@Software_house_id", videogame.Software_house_id);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);  
                }
                


            }
        }
    }
}
