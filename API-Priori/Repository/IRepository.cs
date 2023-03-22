﻿using System.Linq.Expressions;

namespace API_Priori.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(Expression<Func<T, bool>> predicate);
        void Add (T entity);
        void Update (T entity);
        void Delete (T entity); 
    }
}