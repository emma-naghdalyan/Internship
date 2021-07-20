using EntityFramework_DesignTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product> GetProductAsync(int id);
        public Task CreateAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task RemoveAsync(int id);
    }

    public interface ICustomerService
    {
        public Task<List<Customer>> GetCustomersAsync();
        public Task<Customer> GetCustomerAsync(int id);
        public Task CreateAsync(Customer product);
        public Task UpdateAsync(Customer product);
        public Task RemoveAsync(int id);
    }
}
