﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ChoreDataModel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChoreDataModel.Repositories
{
    public class RepositoryBase<T, C> : IRepository<T, C> where T : class, IEntity, new() where C : DbContext
    {
        public C Context => _context;
        private readonly C _context;
        private readonly DbSet<T> _dbSet;

        protected RepositoryBase(C context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T item)
        {
             _dbSet.AddAsync(item);
        }


        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return _dbSet.FirstOrDefaultAsync(exp);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _dbSet.FirstOrDefault(exp);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<List<T>> ToListAsync()
        {
            return _dbSet.ToListAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _dbSet.AsQueryable().Where(exp);
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet;
        }

        public void Update(T item)
        {
          _context.Update(item);
        }

        

    }
}
