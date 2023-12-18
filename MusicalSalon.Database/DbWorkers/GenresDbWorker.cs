using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;
using MySqlConnector;

namespace MusicalSalon.Database.DbWorkers
{
    public class GenresDbWorker : DbWorkerBase, IDbWorker<Genre> {
        public void Add(Genre entity)
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Genres(name) VALUES (@nm)";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nm", entity.Name);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Genres WHERE id=@gId";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@gId", id);

            cmd.ExecuteNonQuery();
        }

        public void Edit(Genre updatedEntity)
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Genres SET name=@nm WHERE id=@gId";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@nm", updatedEntity.Name);
            cmd.Parameters.AddWithValue("@gId", updatedEntity.Id);

            cmd.ExecuteNonQuery();
        }

        public List<Genre> GetAll()
        {
            var genres = new List<Genre>();
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Genres";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                genres.Add(new Genre()
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name")
                });


            return genres;
        }

        public Genre GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);
    }
}
