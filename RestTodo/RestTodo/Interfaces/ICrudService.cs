using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTodo.Interfaces
{
    public interface ICrudService<U> where U : class
    {
        IEnumerable<U> GetAll();
        U GetById(long id);
        void Save(U dto);
        void Update(U dto, long id);
        void Delete(long id);
        bool IsInDataBase(long id);
    }
}
