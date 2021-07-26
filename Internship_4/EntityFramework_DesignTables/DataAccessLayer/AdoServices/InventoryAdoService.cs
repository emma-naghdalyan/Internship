using EntityFramework_DesignTables.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer.AdoServices
{
    public class InventoryAdoService
    {
        IConfigurationRoot configuration;
        string connectionString;

        public InventoryAdoService()
        {
            configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Inventory>> GetInventoriesAsync()
        {
            string command = $"SELECT * FROM Inventories;";
            List<Inventory> inventories = new List<Inventory>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                var reader = await sqlCommand.ExecuteReaderAsync();
                while(reader.Read())
                {
                    inventories.Add(new Inventory
                    {
                        InventoryId = reader.GetInt32(0),
                        Type = reader.GetString(1),
                        SerialNumber = reader.GetString(2)
                    });
                }
            }
            return inventories;
        }

        public async Task CreateInventoryAsync(Inventory inventory)
        {
            string command = $"INSERT INTO Inventories(Type, SerialNumber) VALUES({inventory.Type},{inventory.SerialNumber});";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            string command = $"UPDATE Inventories SET Type={inventory.Type}, SerialNumber={inventory.SerialNumber} WHERE InventoryId={inventory.InventoryId};";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteInventoryAsync(int id)
        {
            string command = $"DELETE FROM Inventories WHERE InventoryId={id};";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }
    }
}
