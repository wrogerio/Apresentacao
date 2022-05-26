using Memory.Domain.Interfaces.Repositories;
using Memory.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Domain.Services
{
    public class ServiceBase<tEntity> : IServiceBase<tEntity> where tEntity : class
    {
        private readonly IRepositoryBase<tEntity> _repository;
        public ServiceBase(IRepositoryBase<tEntity> repository)
        {
            _repository = repository;
        }
        
        public void Add(tEntity obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<tEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public tEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public void Update(tEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
