namespace Modul14.AdoNet.ProductOrder.Test
{
    using Modul14.AdoNet.ProductOrder.DataManager;
    using Modul14.AdoNet.ProductOrder.Domain;
    using Npgsql;
    using System;
    using System.Data;
    using Xunit;

    public class DatabaseManagerTests
    {
        private readonly DatabaseManager _dbManager;

        public DatabaseManagerTests()
        {
            var connectionString = "YourConnectionStringHere";
            _dbManager = new DatabaseManager(connectionString);
        }

        [Fact]
        public void AddProduct_ShouldAddProduct()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Description = "Test Description",
                Weight = 1.2f,
                Height = 3.4f,
                Width = 2.3f,
                Length = 5.6f
            };

            _dbManager.AddProduct(product);

            var retrievedProduct = _dbManager.GetProduct(product.Id);
            Assert.NotNull(retrievedProduct);
            Assert.Equal(product.Name, retrievedProduct.Name);
        }

        [Fact]
        public void UpdateProduct_ShouldUpdateProduct()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Old Name",
                Description = "Old Description",
                Weight = 1.0f,
                Height = 1.0f,
                Width = 1.0f,
                Length = 1.0f
            };

            _dbManager.AddProduct(product);

            product.Name = "New Name";
            product.Description = "New Description";
            product.Weight = 2.0f;
            product.Height = 2.0f;
            product.Width = 2.0f;
            product.Length = 2.0f;

            _dbManager.UpdateProduct(product);

            var updatedProduct = _dbManager.GetProduct(product.Id);
            Assert.NotNull(updatedProduct);
            Assert.Equal("New Name", updatedProduct.Name);
            Assert.Equal("New Description", updatedProduct.Description);
        }

        [Fact]
        public void DeleteProduct_ShouldDeleteProduct()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Description = "Test Description",
                Weight = 1.2f,
                Height = 3.4f,
                Width = 2.3f,
                Length = 5.6f
            };

            _dbManager.AddProduct(product);
            _dbManager.DeleteProduct(product.Id);

            var deletedProduct = _dbManager.GetProduct(product.Id);
            Assert.Null(deletedProduct);
        }

        [Fact]
        public void AddOrder_ShouldAddOrder()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Description = "Test Description",
                Weight = 1.2f,
                Height = 3.4f,
                Width = 2.3f,
                Length = 5.6f
            };

            _dbManager.AddProduct(product);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = Status.InProgress,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                ProductId = product.Id
            };

            _dbManager.AddOrder(order);

            var retrievedOrder = _dbManager.GetOrder(order.Id);
            Assert.NotNull(retrievedOrder);
            Assert.Equal(order.Status, retrievedOrder.Status);
        }

        [Fact]
        public void UpdateOrder_ShouldUpdateOrder()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Description = "Test Description",
                Weight = 1.2f,
                Height = 3.4f,
                Width = 2.3f,
                Length = 5.6f
            };

            _dbManager.AddProduct(product);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = Status.NotStarted,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                ProductId = product.Id
            };

            _dbManager.AddOrder(order);

            order.Status = Status.Done;
            _dbManager.UpdateOrder(order);

            var updatedOrder = _dbManager.GetOrder(order.Id);
            Assert.NotNull(updatedOrder);
            Assert.Equal(Status.Done, updatedOrder.Status);
        }

        [Fact]
        public void DeleteOrder_ShouldDeleteOrder()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Description = "Test Description",
                Weight = 1.2f,
                Height = 3.4f,
                Width = 2.3f,
                Length = 5.6f
            };

            _dbManager.AddProduct(product);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = Status.Arrived,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                ProductId = product.Id
            };

            _dbManager.AddOrder(order);
            _dbManager.DeleteOrder(order.Id);

            var deletedOrder = _dbManager.GetOrder(order.Id);
            Assert.Null(deletedOrder);
        }

        [Fact]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var product1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Description = "Description 1",
                Weight = 1.1f,
                Height = 1.1f,
                Width = 1.1f,
                Length = 1.1f
            };

            var product2 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Description = "Description 2",
                Weight = 2.2f,
                Height = 2.2f,
                Width = 2.2f,
                Length = 2.2f
            };

            _dbManager.AddProduct(product1);
            _dbManager.AddProduct(product2);

            var dataTable = _dbManager.GetAllProducts();
            Assert.NotNull(dataTable);
            Assert.True(dataTable.Rows.Count >= 2);
        }

        [Fact]
        public void GetOrdersByFilter_ShouldReturnFilteredOrders()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Description = "Test Description",
                Weight = 1.2f,
                Height = 3.4f,
                Width = 2.3f,
                Length = 5.6f
            };

            _dbManager.AddProduct(product);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = Status.Done,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                ProductId = product.Id
            };

            _dbManager.AddOrder(order);

            var dataTable = _dbManager.GetOrdersByFilter(status: Status.Done);
            Assert.NotNull(dataTable);
            Assert.True(dataTable.Rows.Count > 0);
        }

        [Fact]
        public void DeleteOrdersInBulk_ShouldDeleteOrdersInBulk()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Description = "Test Description",
                Weight = 1.2f,
                Height = 3.4f,
                Width = 2.3f,
                Length = 5.6f
            };

            _dbManager.AddProduct(product);

            var order1 = new Order
            {
                Id = Guid.NewGuid(),
                Status = Status.Done,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                ProductId = product.Id
            };

            var order2 = new Order
            {
                Id = Guid.NewGuid(),
                Status = Status.Done,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                ProductId = product.Id
            };

            _dbManager.AddOrder(order1);
            _dbManager.AddOrder(order2);

            _dbManager.DeleteOrdersInBulk(status: Status.Done);

            var dataTable = _dbManager.GetOrdersByFilter(status: Status.Done);
            Assert.NotNull(dataTable);
            Assert.Empty(dataTable.Rows);
        }
    }
}