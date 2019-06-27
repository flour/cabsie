using Cabsie.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cabsie.API.Services
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetItemAsync(Guid id);
        Task<IEnumerable<T>> GetItemsAsync(int page, int perPage);
        void CreateItem(T item);
        void UpdateItem(T item);
        Task DeleteItemAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
