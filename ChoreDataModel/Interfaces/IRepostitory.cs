using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChoreDataModel.Interfaces
{
    public interface IRepository<T, C> where T: class, IEntity, new() where C :DbContext
    {
        C Context { get; }
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);

        T FirstOrDefault(Expression<Func<T, bool>> exp);

        Task<int> SaveChangesAsync();
        int SaveChanges();

        void Add(T item);
        Task AddRangeAsync(IEnumerable<T> items);
        void AddRange(IEnumerable<T> items);
        void Delete(T item);

        Task<List<T>> ToListAsync();
        List<T> ToList();
        IQueryable<T> AsQueryable();

        IQueryable<T> AsNoTracking();
    }
}
