using EntityFramework_DesignTables.Entities;
using EntityFramework_DesignTables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.BusinessLogicLayer.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product> GetProductAsync(int id);
        public Task CreateProductAsync(Product product);
        public Task UpdateProductAsync(Product product);
        public Task RemoveProductAsync(int id);
        public Task UpdateDescriptionAsync(int productId, string description);
        //public Task<List<ProductsSolded>> GetProductsSoldedAsync(string address, DateTime date, int packageNumber);
    }
}
