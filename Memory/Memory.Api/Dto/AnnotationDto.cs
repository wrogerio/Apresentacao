using Memory.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Memory.Api.Dto
{
    public class AnnotationDto
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
