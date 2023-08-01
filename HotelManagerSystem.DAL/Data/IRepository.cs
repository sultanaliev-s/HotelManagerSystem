using System.Linq.Expressions;
using HotelManagerSystem.Models.Common;

namespace HotelManagerSystem.DAL.Data
{
    public interface IRepository<T, TKey>
        where T : BaseEntity<TKey>
    {
        public Task<T> AddAsync(T item); // C
        public Task<List<T>> AddAllAsync(IEnumerable<T> items);
        public Task<List<T>> GetAllAsync(); // R
        public Task<T> GetByIdAsync(TKey id); // R
        public Task<List<T>> GetByPredicate(Expression<Func<T, bool>> predicate); //R 
        public Task UpdateAsync(T item); // U
        public Task DeleteAsync(T item); // D
        public Task DeleteByIdAsync(TKey id); // D
        public IQueryable<T> GetQuery();

    }
}
