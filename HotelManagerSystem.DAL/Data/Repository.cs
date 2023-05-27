using HotelManagerSystem.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.DAL.Data
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity<T>
    {
        protected readonly HotelContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(HotelContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

            if (_dbSet == default(DbSet<T>))
                throw new ArgumentNullException(nameof(DbSet<T>));
        }

        public async Task<T> AddAsync(T item)
        {

            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(T);

            T result = dbSet.Add(item).Entity;
            _context.SaveChanges();

            return result;
        }

        public async Task<List<T>> AddAllAsync(IEnumerable<T> items)
        {
            var result = new List<T>();

            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(List<T>);

            foreach (T item in items)
            {
                T entity = dbSet.Add(item).Entity;
                result.Add(entity);
            }

            _context.SaveChanges();
            return result;
        }

        public async Task DeleteAsync(T item)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return;

            dbSet.Remove(item);
            _context.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(List<T>);

            return dbSet.ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(T);

            T item = dbSet
                .FirstOrDefault(obj => obj.Id.Equals(id));

            return item;
        }

        public async Task<IEnumerable<T>> GetByPredicate(Predicate<T> predicate)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return null;

            return dbSet.Where(item => predicate(item));
        }

        public async Task UpdateAsync(T item)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return;

            dbSet.Update(item);

            _context.SaveChanges();
        }
    }
}
