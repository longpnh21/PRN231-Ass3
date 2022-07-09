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
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository repository;
        private readonly IMapper mapper;

        public CategoriesController(IMapper mapper)
        {
            this.mapper = mapper;
            repository = new CategoryRepository();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            try
            {
                return Ok(mapper.Map<List<CategoryDto>>(await repository.GetCategoriesAsync()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            try
            {
                var result = await repository.FindCategoryByIdAsync(id);
                return result != null ? Ok(mapper.Map<CategoryDto>(result)) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoryAsync([FromBody] CategoryDto category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                category.CategoryId = null;

                await repository.SaveCategoryAsync(mapper.Map<Category>(category));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var e = await repository.FindCategoryByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            await repository.DeleteCategoryAsync(e);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] CategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (category.CategoryId != id)
            {
                return BadRequest();
            }

            var e = await repository.FindCategoryByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }

            await repository.UpdateCategoryAsync(mapper.Map<Category>(category));
            return NoContent();
        }
    }
}