using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;
using MySqlConnector;

namespace MusicalSalon.Database.DbWorkers {
    public class MusiciansDbWorker : DbWorkerBase, IDbWorker<Musician> {
        public void Add(Musician entity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Musicians(name, career_year) VALUES (@n, @c)";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@n", entity.Name);
            cmd.Parameters.AddWithValue("@c", entity.CareerYear);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Musicians WHERE id=@mId";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@mId", id);

            cmd.ExecuteNonQuery();
        }

        public void Edit(Musician updatedEntity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Musicians SET name=@n, career_year=@c WHERE id=@mId";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@n", updatedEntity.Name);
            cmd.Parameters.AddWithValue("@c", updatedEntity.CareerYear);
            cmd.Parameters.AddWithValue("@mId", updatedEntity.Id);

            cmd.ExecuteNonQuery();
        }

        public List<Musician> GetAll() {
            var musicians = new List<Musician>();
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Musicians";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                musicians.Add(new Musician()
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    CareerYear = reader.GetInt32("career_year")
                });


            return musicians;
        }

        public Musician GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);
    }
}
