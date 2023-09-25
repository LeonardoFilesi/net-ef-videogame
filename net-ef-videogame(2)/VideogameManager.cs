using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame_2_
{
    public static class VideogameManager
    {
        private static string connectionString = "Data Source=localhost;Integrated Security=True";

        // CREATE VIDEOGAME

        public static bool CreateVideogame(Videogame videogame)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@name, @overview, @releaseDate, @softwareHouseId);";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@name", videogame.Name);
                    cmd.Parameters.AddWithValue("@overview", videogame.Overview);
                    cmd.Parameters.AddWithValue("@releaseDate", videogame.ReleaseDate);
                    cmd.Parameters.AddWithValue("@softwareHouseId", videogame.SoftwareHouseId);

                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }

        // VIDEOGAME BY ID
        public static List<Videogame> GetVideogamesById(long id)
        {
            List<Videogame> videogames = new List<Videogame>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, name, overview, release_date, created_at, updated_at, software_house_id FROM videogames WHERE id = @id;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader data = cmd.ExecuteReader())
                        {
                            // if (reader.Read())
                            //    {
                            //        long Id = reader.GetInt64(0);
                            //        string name = reader.GetString(1);
                            //        string overview = reader.GetString(2);
                            //        DateTime releaseDate = reader.GetDateTime(3);
                            //        long softwareHouseId = reader.GetInt64(4);
                            //
                            //        Videogame videogame = new Videogame(Id, name, overview, releaseDate, softwareHouseId);
                            //
                            //        return videogame;     METODO ALTERNATIVO

                            while (data.Read())
                            {
                                Videogame videogameReaded = new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
                                videogames.Add(videogameReaded);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return videogames;
            }
        }

        // VIDEOGAME BY STRING
        public static List<Videogame> GetVideogamesByString(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE name LIKE @name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Videogame> videogames = new List<Videogame>();

                            while (reader.Read())
                            {
                                long Id = reader.GetInt64(0);
                                string gameName = reader.GetString(1);
                                string overview = reader.GetString(2);
                                DateTime releaseDate = reader.GetDateTime(3);
                                long softwareHouseId = reader.GetInt64(4);

                                Videogame videogame = new Videogame(Id, gameName, overview, releaseDate, softwareHouseId);
                                videogames.Add(videogame);
                            }

                            return videogames;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }
        // DELETE VIDEOGAME

        public static bool DeleteVideogame(long deletegameid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    string query = "DELETE  FROM videogames WHERE id=@Id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Id", deletegameid));


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }

        public static bool CreateSoftwareHouse(SoftwareHouse softwareHouse)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (software_house_id, name, country) VALUES (@softwareHouseId, @name, @country);";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@softwareHouseId", softwareHouse.SoftwareHouseId);
                    cmd.Parameters.AddWithValue("@name", softwareHouse.Name);
                    cmd.Parameters.AddWithValue("@country", softwareHouse.Country);

                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }
    }
}
