﻿using API_Priori.Context;
using API_Priori.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API_Priori.RepositoryImpl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}
