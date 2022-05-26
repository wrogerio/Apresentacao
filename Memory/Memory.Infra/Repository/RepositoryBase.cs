using Memory.Domain.Interfaces.Repositories;
using Memory.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Infra.Repository
{
    public class RepositoryBase<tEntity> : IRepositoryBase<tEntity> where tEntity : class
    {
        private readonly MemoryContext _context;

        public RepositoryBase(MemoryContext context)
        {
            _context = context;
        }

        public void Add(tEntity obj)
        {
            _context.Set<tEntity>().Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<tEntity> GetAll()
        {
            return _context.Set<tEntity>().ToList();
        }

        public tEntity GetById(Guid id)
        {
            return _context.Set<tEntity>().Find(id);
        }

        public void Remove(Guid id)
        {
            _context.Set<tEntity>().Remove(GetById(id));
            _context.SaveChanges();
        }

        public void Update(tEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
