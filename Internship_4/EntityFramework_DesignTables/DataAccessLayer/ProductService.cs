using EntityFramework_DesignTables.Entities;
using EntityFramework_DesignTables.Exceptions;
using EntityFramework_DesignTables.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer
{
    public class ProductService
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var query = from product in _dbContext.Products
                        select product;
            var products = await query.ToListAsync();
            return products;
        }

        public List<Product> GetProducts()
        {
            var query = from product in _dbContext.Products
                        select product;
            var products = query.ToList();
            return products;
        }


        public async Task<Product> GetProduct(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                throw new NotFoundException("The product is not found ... ");
            }
            return product;
        }

        public async Task<List<ProductsSolded>> GetProductsSoldedAsync(string address, DateTime date, int packageNumber)
        {
            var query = from products in _dbContext.Products
                        join productList in _dbContext.ProductLists on products.ProductListId equals productList.ProductListId
                        where products.DateSold < date && productList.Package == packageNumber
                        group products by products.DateSold.Year into productsGroup
                        orderby productsGroup.Key
                        select new ProductsSolded
                        {
                            YearSold = productsGroup.Key,
                            CountOfProducts = productsGroup.Count()
                        };
            var soldedProducts = await query.ToListAsync();
            return soldedProducts;
        }

        //public async Task CreateProductAsync(int productListId)
        //{
        //    var product = new Product
        //    {
        //        ProductListId = productListId,
        //        ProductName = "Chocolate",
        //        DateSold = new DateTime(2021, 03, 7),
        //        Description = "Very yummy!"
        //    };
        //    await _dbContext.Products.AddAsync(product);
        //    await _dbContext.SaveChangesAsync();
        //}

        public async Task CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            var productIn = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
            if (productIn == null)
            {
                throw new NotFoundException("The product is not found ... ");
            }
            productIn.ProductListId = product.ProductListId;
            productIn.ProductName = product.ProductName;
            productIn.DateSold = product.DateSold;
            productIn.Description = product.Description;
            _dbContext.Products.Update(productIn);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductDescriptionAsync(int productId, string description)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product == null)
            {
                throw new NotFoundException("The product is not found ... ");
            }
            product.Description = description;
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product == null)
            {
                throw new NotFoundException("The product is not found ... ");
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
