using Cabsie.API.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cabsie.API.Services
{
    public interface IGenericRepository<T> where T : class, IBaseEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> AllWithAsync(params Expression<Func<T, object>>[] props);
        int Count();
        Task<T> GetItemAsync(Guid id);
        Task<T> GetItemAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetItemAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] props);
        void CreateItem(T item);
        void UpdateItem(T item);
        void DeleteItem(T item);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        Task<bool> SaveAsync();
    }
}
