using Memory.Api.Dto;
using Memory.Domain.Entities;
using Memory.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Memory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController([FromServices] ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            List<CategoryDto> result = new List<CategoryDto>();
            var categories = _categoryRepository.GetAll();

            foreach (var category in categories)
                result.Add(new CategoryDto { Id = category.Id, CategoryName = category.CategoryName, Description = category.Description });

            return result.OrderBy(x => x.CategoryName);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public CategoryDto Get(Guid id)
        {
            var category = _categoryRepository.GetById(id);
            return new CategoryDto { Id = category.Id, CategoryName = category.CategoryName, Description = category.Description };
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            if (true)
            {
                _categoryRepository.Add(category);
            }

            return category;
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public Category Put(Guid id, [FromBody] Category category)
        {
            if (true)
            {
                var categoryToUpdate = _categoryRepository.GetById(id);
                categoryToUpdate.CategoryName = category.CategoryName;
                categoryToUpdate.Description = category.Description;
                _categoryRepository.Update(categoryToUpdate);
            }

            return category;
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            if (true)
            {
                _categoryRepository.Remove(id);
            }
            return true;
        }
    }
}
