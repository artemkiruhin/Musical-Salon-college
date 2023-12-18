using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;
using MySqlConnector;

namespace MusicalSalon.Database.DbWorkers {
    public class ProvidersDbWorker : DbWorkerBase, IDbWorker<Provider> {
        public void Add(Provider entity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Providers(name) VALUES (@n)";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@n", entity.Name);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Providers WHERE id=@pId";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@pId", id);

            cmd.ExecuteNonQuery();
        }

        public void Edit(Provider updatedEntity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Providers SET name=@n WHERE id=@pId";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@n", updatedEntity.Name);
            cmd.Parameters.AddWithValue("@pId", updatedEntity.Id);

            cmd.ExecuteNonQuery();
        }

        public List<Provider> GetAll() {
            var providers = new List<Provider>();
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Providers";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                providers.Add(new Provider()
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name")
                });


            return providers;
        }

        public Provider GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);
    }
}
