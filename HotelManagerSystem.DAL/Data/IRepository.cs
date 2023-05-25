using HotelManagerSystem.Models.Common;

namespace HotelManagerSystem.DAL.Data
{
    public interface IRepository<T>
    {
        public Task<T> AddAsync(T item); // C
        public  Task<List<T>> AddAllAsync(IEnumerable<T> items);
        public Task<List<T>> GetAllAsync(); // R
        public Task<T> GetByIdAsync(int id); // R
        public Task<IEnumerable<T>> GetByPredicate(Predicate<T> predicate); //R 
        public Task UpdateAsync(T item); // U
        public Task DeleteAsync(T item); // D
      
    }
}
