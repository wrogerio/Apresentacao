using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Domain.Entities
{
    public class Annotation: EntityBase
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
