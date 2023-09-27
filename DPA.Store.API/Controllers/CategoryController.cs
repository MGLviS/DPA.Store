using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("GetID/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _categoryRepository.GetByIdCat(id);
            return Ok(categories);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(Category category)
        {
            var result = await _categoryRepository.Insert(category);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
        /*
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _categoryRepository.GetById(id);
            return Ok(categories);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Category category)
        {
            var result = await _categoryRepository.Insert(category);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        //[HttpDelete("Delete")]
        */
 
    }
}
