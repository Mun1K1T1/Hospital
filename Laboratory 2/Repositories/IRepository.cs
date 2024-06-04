using Laboratory_2.Data.Models.Data;
using Laboratory_2.Models;
using System;
using System.Collections.Generic;

namespace Laboratory_2.Repositories
{
    public interface IRepository<T> where T : EEntity
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        void Create(T Entity);
        void Update(T Entity);
        void Delete(Guid key);
        T GetFirst(Func<T, bool> predicate);
    }
}
