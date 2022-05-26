using Memory.Api.Dto;
using Memory.Domain.Entities;
using Memory.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Memory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnotationsController : ControllerBase
    {
        private readonly IAnnotationRepository _annotationRepository;

        public AnnotationsController(IAnnotationRepository annotationRepository)
        {
            _annotationRepository = annotationRepository;
        }

        // GET: api/<AnnotationsController>
        [HttpGet]
        public IEnumerable<AnnotationDto> Get()
        {
            List<AnnotationDto> result = new List<AnnotationDto>();
            foreach (var annotation in _annotationRepository.GetAll())
                result.Add(new AnnotationDto { Id = annotation.Id, Order = annotation.Order, Type = annotation.Type, Description = annotation.Description, Tags = annotation.Tags, CategoryId = annotation.CategoryId, CategoryName = annotation.Category.CategoryName, CategoryDescription = annotation.Category.Description });

            result = result.OrderBy(r => r.CategoryName).ThenBy(r => r.Type).ThenBy(r => r.Order).ThenBy(r => r.Tags).ThenBy(r => r.Description).ToList();

            return result;
        }

        // GET api/<AnnotationsController>/5
        [HttpGet("{id}")]
        public AnnotationDto Get(Guid id)
        {
            var annotation = _annotationRepository.GetById(id);
            return new AnnotationDto { Id = annotation.Id, Order = annotation.Order, Type = annotation.Type, Description = annotation.Description, CategoryId = annotation.CategoryId, Tags = annotation.Tags };
        }

        [HttpGet("GetByCategory/{id}")]
        public IEnumerable<AnnotationDto> GetByCategory(Guid id)
        {
            List<AnnotationDto> result = new List<AnnotationDto>();
            foreach (var annotation in _annotationRepository.GetAll().Where(x => x.CategoryId == id))
                result.Add(new AnnotationDto { Id = annotation.Id, Order = annotation.Order, Type = annotation.Type, Description = annotation.Description, Tags = annotation.Tags, CategoryId = annotation.CategoryId, CategoryName = annotation.Category.CategoryName, CategoryDescription = annotation.Category.Description });

            result = result.OrderBy(r => r.CategoryName).ThenBy(r => r.Type).ThenBy(r => r.Order).ThenBy(r => r.Tags).ThenBy(r => r.Description).ToList();

            return result;
        }

        // POST api/<AnnotationsController>
        [HttpPost]
        public AnnotationDto Post([FromBody] Annotation annotation)
        {
            if (true)
            {
                _annotationRepository.Add(annotation);
                return new AnnotationDto { Id = annotation.Id, Order = annotation.Order, Type = annotation.Type, Description = annotation.Description, CategoryId = annotation.CategoryId, Tags = annotation.Tags, CategoryName = "", CategoryDescription = "" };
            }
        }

        // PUT api/<AnnotationsController>/5
        [HttpPut("{id}")]
        public AnnotationDto Put(Guid id, [FromBody] Annotation annotation)
        {
            if (true)
            {
                var annotationToUpdate = _annotationRepository.GetById(id);
                annotationToUpdate.Description = annotation.Description;
                annotationToUpdate.CategoryId = annotation.CategoryId;
                annotationToUpdate.Tags = annotation.Tags;
                annotationToUpdate.Order = annotation.Order;
                _annotationRepository.Update(annotationToUpdate);

                return new AnnotationDto { Id = annotationToUpdate.Id, Order = annotation.Order, Type = annotation.Type, Description = annotationToUpdate.Description, CategoryId = annotationToUpdate.CategoryId, Tags = annotationToUpdate.Tags, CategoryName = annotationToUpdate.Category.CategoryName, CategoryDescription = annotationToUpdate.Category.Description };
            }
        }

        // DELETE api/<AnnotationsController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            if (true)
            {
                _annotationRepository.Remove(id);
            }

            return true;
        }
    }
}
