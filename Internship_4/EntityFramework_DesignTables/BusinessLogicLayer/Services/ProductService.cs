using EntityFramework_DesignTables.BusinessLogicLayer.Interfaces;
using EntityFramework_DesignTables.DataAccessLayer;
using EntityFramework_DesignTables.Entities;
using EntityFramework_DesignTables.Exceptions;
using EntityFramework_DesignTables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _unitOfWork.Products.CreateAsync(product);
            await _unitOfWork.Commit();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            try
            {
                return await _unitOfWork.Products.GetProductAsync(id);
            }
            catch (NotFoundException)
            {
                throw;
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _unitOfWork.Products.GetProductsAsync();
        }

        public async Task RemoveProductAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetProductAsync(id);
                _unitOfWork.Products.Remove(product);
                await _unitOfWork.Commit();
            }
            catch (NotFoundException)
            {
                throw;
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                var productIn = await _unitOfWork.Products.GetProductAsync(product.ProductId);
                productIn.ProductListId = product.ProductListId;
                productIn.ProductName = product.ProductName;
                productIn.DateSold = product.DateSold;
                productIn.Description = product.Description;
                _unitOfWork.Products.Update(productIn);
                await _unitOfWork.Commit();
            }
            catch(NotFoundException)
            {
                throw;
            }
        }

        public async Task UpdateDescriptionAsync(int productId, string description)
        {
            var product = await _unitOfWork.Products.GetProductAsync(productId);
            product.Description = description;
            _unitOfWork.Products.Update(product);
            await _unitOfWork.Commit();
        }

        //public async Task<List<ProductsSolded>> GetProductsSoldedAsync(string address, DateTime date, int packageNumber)
        //{
        //    var query = from products in _unitOfWork.Products
        //                join productList in _unitOfWork.ProductLists on products.ProductListId equals productList.ProductListId
        //                where products.DateSold < date && productList.Package == packageNumber
        //                group products by products.DateSold.Year into productsGroup
        //                orderby productsGroup.Key
        //                select new ProductsSolded
        //                {
        //                    YearSold = productsGroup.Key,
        //                    CountOfProducts = productsGroup.Count()
        //                };
        //    var soldedProducts = await query.ToListAsync();
        //    return soldedProducts;
        //}
    }
}
