using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Domain.Interfaces.Services
{
    public interface IServiceBase<tEntity> where tEntity : class
    {
        IEnumerable<tEntity> GetAll();
        tEntity GetById(Guid id);
        void Add(tEntity obj);
        void Update(tEntity obj);
        void Remove(Guid id);
    }
}
