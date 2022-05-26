using Memory.Domain.Entities;
using Memory.Domain.Interfaces.Repositories;
using Memory.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Infra.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly MemoryContext _context;

        public CategoryRepository(MemoryContext context) : base(context)
        {
            _context = context;
        }
    }
}
