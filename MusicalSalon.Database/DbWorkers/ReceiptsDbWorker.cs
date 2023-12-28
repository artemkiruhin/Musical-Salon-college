using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;
using MySqlConnector;

namespace MusicalSalon.Database.DbWorkers {
    public class ReceiptsDbWorker : DbWorkerBase, IDbWorker<Receipt> {
        public void Add(Receipt entity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Receipts(number, recieve_date, provider_id, quantity, full_price) VALUES (@n, @r, @p, @q, @f)";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@n", entity.Number);
            cmd.Parameters.AddWithValue("@r", entity.RecieveDate);
            cmd.Parameters.AddWithValue("@p", entity.ProviderId);
            cmd.Parameters.AddWithValue("@q", entity.Quantity);
            cmd.Parameters.AddWithValue("@f", entity.FullPrice);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Receipts WHERE id=@rId";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@rId", id);

            cmd.ExecuteNonQuery();
        }

        public void Edit(Receipt updatedEntity) {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Receipts SET number=@n, recieve_date=@r, provider_id=@p, quantity=@q, full_price=@f WHERE id=@rId";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@n", updatedEntity.Number);
            cmd.Parameters.AddWithValue("@r", updatedEntity.RecieveDate);
            cmd.Parameters.AddWithValue("@p", updatedEntity.ProviderId);
            cmd.Parameters.AddWithValue("@q", updatedEntity.Quantity);
            cmd.Parameters.AddWithValue("@f", updatedEntity.FullPrice);
            cmd.Parameters.AddWithValue("@rId", updatedEntity.Id);

            cmd.ExecuteNonQuery();
        }

        public List<Receipt> GetAll() {
            var receipts = new List<Receipt>();
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Receipts";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                receipts.Add(new Receipt()
                {
                    Id = reader.GetInt32("id"),
                    Number = reader.GetString("number"),
                    RecieveDate = reader.GetDateTime("recieve_date"),
                    ProviderId = reader.GetInt32("provider_id"),
                    Quantity = reader.GetInt32("quantity"),
                    FullPrice = reader.GetInt32("full_price")
                });


            return receipts;
        }

        public Receipt GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);
    }
}
