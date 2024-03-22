using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private ETicaretApiDbContext _context;

        public WriteRepository(ETicaretApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }
       

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return Remove(entity);
        }

        public bool UpdateAsync(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
