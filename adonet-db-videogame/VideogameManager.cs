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
                    var sql = @"INSERT INTO videogames (name, overview, release_date, software_house_id) " +
                                "OUTPUT INSERTED.ID " +
                                "VALUES (@Name, @Overview, @Release_date, @Software_house_id)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", videogame.Name);
                        cmd.Parameters.AddWithValue("@Overview", videogame.Overview);
                        cmd.Parameters.AddWithValue("@Release_date", videogame.Release_date);
                        cmd.Parameters.AddWithValue("@Software_house_id", videogame.Software_house_id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);  
                }

            }
        }
        public Videogame GetVideogameId(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var sql = @"SELECT * FROM videogames WHERE id = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string name = reader.GetString(reader.GetOrdinal("name"));
                                string overview = reader.GetString(reader.GetOrdinal("overview"));
                                DateTime releaseDate = reader.GetDateTime(reader.GetOrdinal("release_date"));
                                long softwareHouseId = reader.GetInt64(reader.GetOrdinal("software_house_id"));

                                return new Videogame(name, overview, releaseDate, softwareHouseId);
                            }
                            else
                            {
                                throw new Exception("Videogame non trovato.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}
