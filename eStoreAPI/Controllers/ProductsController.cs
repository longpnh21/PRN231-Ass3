using AutoMapper;
using BusinessObject.Dtos;
using BusinessObject.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository;
        private readonly IMapper mapper;

        public ProductsController(IMapper mapper)
        {
            this.mapper = mapper;
            repository = new ProductRepository();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                return Ok(mapper.Map<List<ProductDto>>(await repository.GetProductsAsync()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                var result = await repository.FindProductByIdAsync(id);
                return result != null ? Ok(mapper.Map<ProductDto>(result)) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostProductAsync([FromBody] ProductDto product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await repository.SaveProductAsync(mapper.Map<Product>(product));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var e = await repository.FindProductByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            await repository.DeleteProductAsync(e);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (product.ProductId != id)
            {
                return BadRequest();
            }
            var e = await repository.FindProductByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            await repository.UpdateProductAsync(mapper.Map<Product>(product));
            return NoContent();
        }
    }
}