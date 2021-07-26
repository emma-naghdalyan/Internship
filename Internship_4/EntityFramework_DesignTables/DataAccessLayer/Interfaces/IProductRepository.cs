using EntityFramework_DesignTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product> GetProductAsync(int id);
        public Task CreateAsync(Product product);
        public void Update(Product product);
        public void Remove(Product product);
    }
}
