﻿using System.Collections.Generic;

namespace RestTodo.Interfaces
{
    public interface ICrudRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Save(T entity);
        void Delete(long id);
        bool IsInDataBase(long id);
        void Update(T entity);
    }
}
