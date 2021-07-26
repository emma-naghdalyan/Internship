using EntityFramework_DesignTables.DataAccessLayer.Interfaces;
using EntityFramework_DesignTables.Entities;
using EntityFramework_DesignTables.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Product product)
        {
            if (product==null)
            {
                throw new NullReferenceException();
            }
            await _dbContext.Products.AddAsync(product);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                throw new NotFoundException("The product is not found ... ");
            }
            return product;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var query = from product in _dbContext.Products
                        select product;
            var products = await query.ToListAsync();
            return products;
        }

        public void Remove(Product product)
        {
            _dbContext.Products.Remove(product);
        }

        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
        }
    }
}
