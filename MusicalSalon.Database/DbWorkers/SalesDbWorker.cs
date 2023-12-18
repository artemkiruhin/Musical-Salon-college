using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;
using MySqlConnector;

namespace MusicalSalon.Database.DbWorkers
{
    public class SalesDbWorker : DbWorkerBase, IDbWorker<Sale>
    {
        public void Add(Sale entity)
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Sales(disk_id, sale_date, quantity, full_price) VALUES (@d, @s, @q, @p)";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@d", entity.Diskid);
            cmd.Parameters.AddWithValue("@s", entity.SaleDate);
            cmd.Parameters.AddWithValue("@q", entity.Quantity);
            cmd.Parameters.AddWithValue("@p", entity.FullPrice);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Sales WHERE id=@sId";

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@sId", id);

            cmd.ExecuteNonQuery();
        }

        public void Edit(Sale updatedEntity)
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Sales SET disk_id=@d, sale_date=@s, quantity=@q, full_price=@p WHERE id=@sId";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@d", updatedEntity.Diskid);
            cmd.Parameters.AddWithValue("@s", updatedEntity.SaleDate);
            cmd.Parameters.AddWithValue("@q", updatedEntity.Quantity);
            cmd.Parameters.AddWithValue("@p", updatedEntity.FullPrice);
            cmd.Parameters.AddWithValue("@sId", updatedEntity.Id);

            cmd.ExecuteNonQuery();
        }

        public List<Sale> GetAll()
        {
            var sales = new List<Sale>();
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Disks";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                sales.Add(new Sale()
                {
                    Id = reader.GetInt32("id"),
                    Diskid = reader.GetInt32("disk_id"),
                    SaleDate = reader.GetDateTime("sale_date"),
                    Quantity = reader.GetInt32("quantity"),
                    FullPrice = reader.GetDecimal("full_price")
                });


            return sales;
        }
    }
}
