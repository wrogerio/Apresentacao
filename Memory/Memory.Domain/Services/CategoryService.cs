using Memory.Domain.Entities;
using Memory.Domain.Interfaces.Repositories;
using Memory.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Domain.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
