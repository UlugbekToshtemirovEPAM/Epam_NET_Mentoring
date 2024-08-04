namespace Modul14.AdoNet.ProductOrder.DataManager
{
    using Modul14.AdoNet.ProductOrder.Domain;
    using Npgsql;
    using System;
    using System.Data;

    public class DatabaseManager
    {
        private readonly string _connectionString;

        private const string myConnectionString = "Server=localhost;Port=5432;Database=MyDb1;User Id=postgres;Password=postgres";

        public DatabaseManager(string connectionString = null)
        {
            _connectionString = string.IsNullOrWhiteSpace(connectionString) ? myConnectionString : connectionString;
        }

        // CRUD for Product
        public void AddProduct(Product product)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand(
                    "INSERT INTO Products (Id, Name, Description, Weight, Height, Width, Length) " +
                    "VALUES (@Id, @Name, @Description, @Weight, @Height, @Width, @Length)", connection);
                command.Parameters.AddWithValue("Id", product.Id);
                command.Parameters.AddWithValue("Name", product.Name);
                command.Parameters.AddWithValue("Description", product.Description);
                command.Parameters.AddWithValue("Weight", product.Weight);
                command.Parameters.AddWithValue("Height", product.Height);
                command.Parameters.AddWithValue("Width", product.Width);
                command.Parameters.AddWithValue("Length", product.Length);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Product GetProduct(Guid id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand("SELECT * FROM Products WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("Id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Weight = reader.GetFloat(reader.GetOrdinal("Weight")),
                            Height = reader.GetFloat(reader.GetOrdinal("Height")),
                            Width = reader.GetFloat(reader.GetOrdinal("Width")),
                            Length = reader.GetFloat(reader.GetOrdinal("Length"))
                        };
                    }
                }
            }
            return null;
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand(
                    "UPDATE Products SET Name = @Name, Description = @Description, Weight = @Weight, Height = @Height, Width = @Width, Length = @Length " +
                    "WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("Id", product.Id);
                command.Parameters.AddWithValue("Name", product.Name);
                command.Parameters.AddWithValue("Description", product.Description);
                command.Parameters.AddWithValue("Weight", product.Weight);
                command.Parameters.AddWithValue("Height", product.Height);
                command.Parameters.AddWithValue("Width", product.Width);
                command.Parameters.AddWithValue("Length", product.Length);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(Guid id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand("DELETE FROM Products WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // CRUD for Order
        public void AddOrder(Order order)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand(
                    "INSERT INTO Orders (Id, Status, CreatedDate, UpdatedDate, ProductId) " +
                    "VALUES (@Id, @Status, @CreatedDate, @UpdatedDate, @ProductId)", connection);
                command.Parameters.AddWithValue("Id", order.Id);
                command.Parameters.AddWithValue("Status", order.Status);
                command.Parameters.AddWithValue("CreatedDate", order.CreatedDate);
                command.Parameters.AddWithValue("UpdatedDate", order.UpdatedDate);
                command.Parameters.AddWithValue("ProductId", order.ProductId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Order GetOrder(Guid id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand("SELECT * FROM Orders WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("Id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Status = (Status)reader.GetInt32(reader.GetOrdinal("Status")),
                            CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            UpdatedDate = reader.GetDateTime(reader.GetOrdinal("UpdatedDate")),
                            ProductId = reader.GetGuid(reader.GetOrdinal("ProductId")),
                            Product = GetProduct(reader.GetGuid(reader.GetOrdinal("ProductId"))) 
                        };
                    }
                }
            }
            return null;
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand(
                    "UPDATE Orders SET Status = @Status, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate, ProductId = @ProductId " +
                    "WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("Id", order.Id);
                command.Parameters.AddWithValue("Status", order.Status);
                command.Parameters.AddWithValue("CreatedDate", order.CreatedDate);
                command.Parameters.AddWithValue("UpdatedDate", order.UpdatedDate);
                command.Parameters.AddWithValue("ProductId", order.ProductId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrder(Guid id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand("DELETE FROM Orders WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Fetch all products
        public DataTable GetAllProducts()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand("SELECT * FROM Products", connection);
                var adapter = new NpgsqlDataAdapter(command);
                var dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Fetch orders with filtering
        public DataTable GetOrdersByFilter(DateTime? month = null, Status? status = null, int? year = null, Guid? productId = null)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand("CALL GetOrdersByFilter(@Month, @Status, @Year, @ProductId)", connection);
                command.Parameters.AddWithValue("Month", month.HasValue ? (object)month.Value : DBNull.Value);
                command.Parameters.AddWithValue("Status", status.HasValue ? (object)status.Value : DBNull.Value);
                command.Parameters.AddWithValue("Year", year.HasValue ? (object)year.Value : DBNull.Value);
                command.Parameters.AddWithValue("ProductId", productId.HasValue ? (object)productId.Value : DBNull.Value);
                var adapter = new NpgsqlDataAdapter(command);
                var dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Delete orders in bulk
        public void DeleteOrdersInBulk(DateTime? month = null, Status? status = null, int? year = null, Guid? productId = null)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var command = new NpgsqlCommand("CALL DeleteOrdersInBulk(@Month, @Status, @Year, @ProductId)", connection);
                command.Parameters.AddWithValue("Month", month.HasValue ? (object)month.Value : DBNull.Value);
                command.Parameters.AddWithValue("Status", status.HasValue ? (object)status.Value : DBNull.Value);
                command.Parameters.AddWithValue("Year", year.HasValue ? (object)year.Value : DBNull.Value);
                command.Parameters.AddWithValue("ProductId", productId.HasValue ? (object)productId.Value : DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
