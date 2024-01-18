using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;
using MySqlConnector;

namespace MusicalSalon.Database.DbWorkers {
    public class DisksDbWorker : DbWorkerBase, IDbWorker<Disk> {
        public void Add(Disk entity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Disks(title, song_id, price) VALUES (@ttl, @songId, @prc)";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@songId", entity.SongId);
            cmd.Parameters.AddWithValue("@prc", entity.Price);
            cmd.Parameters.AddWithValue("@ttl", entity.Title);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Disks WHERE id=@dId";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@dId", id);

            cmd.ExecuteNonQuery();
        }

        public void Edit(Disk updatedEntity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Disks SET song_id=@sId, price=@prc, title=@ttl WHERE id=@dId";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@sId", updatedEntity.SongId);
            cmd.Parameters.AddWithValue("@prc", updatedEntity.Price);
            cmd.Parameters.AddWithValue("@dId", updatedEntity.Id);
            cmd.Parameters.AddWithValue("@ttl", updatedEntity.Title);

            cmd.ExecuteNonQuery();
        }

        public List<Disk> GetAll() {
            var disks = new List<Disk>();
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Disks";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                disks.Add(new Disk()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    SongId = reader.GetInt32("song_id"),
                    Price = reader.GetDecimal("price")
                });


            return disks;
        }

        public Disk GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);
    }
}
