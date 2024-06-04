using System;
using System.Collections.Generic;

namespace Laboratory_2.Models
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }

    public class GenericRepository<T> : IRepository<T>
    {
        private readonly List<T> entities = new List<T>();

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return entities;
        }
    }
}
