using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Domain.Entities
{
    public class Category: EntityBase
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Annotation> Annotations { get; set; }
    }
}
