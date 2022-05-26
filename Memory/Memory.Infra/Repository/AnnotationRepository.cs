using Memory.Domain.Entities;
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
    public class AnnotationRepository : IAnnotationRepository
    {
        private readonly MemoryContext _context;

        public AnnotationRepository(MemoryContext context)
        {
            _context = context;
        }

        public void Add(Annotation obj)
        {
            _context.tbAnnotations.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Annotation> GetAll()
        {
            return _context.tbAnnotations.Include(x => x.Category).ToList();
        }

        public Annotation GetById(Guid id)
        {
            return _context.tbAnnotations.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Guid id)
        {
            _context.tbAnnotations.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void Update(Annotation obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
