using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;
using MySqlConnector;

namespace MusicalSalon.Database.DbWorkers {
    public class SongsDbWorker : DbWorkerBase, IDbWorker<Song> {
        public void Add(Song entity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Songs(title, musician_id, genre_id, release_year) VALUES (@t, @m, @g, @r)";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@t", entity.Title);
            cmd.Parameters.AddWithValue("@m", entity.MusicianId);
            cmd.Parameters.AddWithValue("@g", entity.GenreId);
            cmd.Parameters.AddWithValue("@r", entity.ReleaseYear);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Songs WHERE id=@sId";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@sId", id);

            cmd.ExecuteNonQuery();
        }

        public void Edit(Song updatedEntity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Songs SET title=@t, musician_id=@m, genre_id=@g, release_year=@r WHERE id=@sId";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@t", updatedEntity.Title);
            cmd.Parameters.AddWithValue("@m", updatedEntity.MusicianId);
            cmd.Parameters.AddWithValue("@g", updatedEntity.GenreId);
            cmd.Parameters.AddWithValue("@r", updatedEntity.ReleaseYear);
            cmd.Parameters.AddWithValue("@sId", updatedEntity.Id);

            cmd.ExecuteNonQuery();
        }

        public List<Song> GetAll() {
            var songs = new List<Song>();
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Disks";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                songs.Add(new Song()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    MusicianId = reader.GetInt32("musician_id"),
                    GenreId = reader.GetInt32("genre_id"),
                    ReleaseYear = reader.GetInt32("release_year")
                });


            return songs;
        }

        public Song GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);
    }
}
