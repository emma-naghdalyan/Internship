using EntityFramework_DesignTables.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer
{
    public class OrderAdoService
    {
        IConfigurationRoot configuration;
        string connectionString;

        public OrderAdoService()
        {
            configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            string command = $"SELECT * FROM Orders;";
            List<Order> orders = new List<Order>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                var reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderId = reader.GetInt32(0),
                        CustomerId = reader.GetInt32(1),
                        TrackingNumber = reader.GetInt32(2)
                    });
                }
            }
            return orders;
        }

        public async Task CreateOrderAsync(Order order)
        {
            string command = $"INSERT INTO Orders(CustomerId, TrackingNumber) VALUES({order.CustomerId},{order.TrackingNumber});";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateOrderAsync(Order order)
        {
            string command = $"UPDATE Orders SET CustomerId={order.CustomerId}, TrackingNumber={order.TrackingNumber} WHERE OrderId={order.OrderId};";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            string command = $"DELETE FROM Orders WHERE OrderId={id};";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }
    }
}
