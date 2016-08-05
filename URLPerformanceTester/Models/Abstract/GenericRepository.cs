﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace URLPerformanceTester.Models.Abstract
{
    public  class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        protected C Context { get; set; }
        public GenericRepository(C context) { Context = context; }
        public virtual IQueryable<T> GetAll() => Context.Set<T>();
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => Context.Set<T>().Where(predicate);
        public virtual void Add(T entity) => Context.Set<T>().Add(entity);
        public virtual void Delete(T entity) => Context.Set<T>().Remove(entity);
        public virtual void Edit(T entity) => Context.Entry(entity).State = EntityState.Modified;
        public virtual void Save() => Context.SaveChanges();
    }
}