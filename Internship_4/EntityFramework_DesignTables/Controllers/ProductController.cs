using EntityFramework_DesignTables.DataAccessLayer;
using EntityFramework_DesignTables.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Controllers
{
    // Can not add product, but other actions work. There is an error with OrderId, I think if the reason is
    // when I added migration there were not OrderId in the Product model

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ProductService _productService;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _productService = new ProductService(dbContext);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            await _productService.CreateProductAsync(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                await _productService.UpdateProductAsync(product);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                await _productService.RemoveProductAsync(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
