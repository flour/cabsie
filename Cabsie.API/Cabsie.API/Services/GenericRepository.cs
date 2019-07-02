using Cabsie.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cabsie.API.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
        private AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> AllWithAsync(params Expression<Func<T, object>>[] props)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in props)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public int Count()
            => _context.Set<T>().Count();

        public void CreateItem(T item)
            => _context.Set<T>().Add(item);

        public void DeleteItem(T item)
        {
            var dbEntityEntry = _context.Entry(item);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var entries = _context.Set<T>().Where(predicate);
            entries.ForEachAsync(e => _context.Entry(e).State = EntityState.Deleted);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetItemAsync(Guid id)
         => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetItemAsync(Expression<Func<T, bool>> predicate)
         => await _context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task<T> GetItemAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] props)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in props)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
         => (await _context.SaveChangesAsync()) > 0;

        public void UpdateItem(T item)
         => _context.Set<T>().Update(item);
    }
}
