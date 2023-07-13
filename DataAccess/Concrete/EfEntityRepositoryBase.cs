using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfEntityRepositoryBase<T> : IEntityDal<T> where T : BaseEntity
    {
        private BaseContext _context;

        public EfEntityRepositoryBase(BaseContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public T Add(T entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            //_context.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Modified;
            //_context.SaveChanges();
            return entity;
        }
        public T Delete(T entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Deleted;
            //_context.SaveChanges();
            return entity;
        }
        public async Task<T> GetByIdAsync(int id, bool tracked = true)
        {
            var context = _context.Set<T>();
            if(!tracked)
                context.AsNoTracking();

            T? entity = await context.FirstOrDefaultAsync(i => i.Id == id);
            return entity ?? throw new Exception("Id not exists");
        }
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, bool tracked = false)
        {
            var context = _context.Set<T>();
            if (!tracked)
                context.AsNoTracking();

            return   filter == null ?
                await context.ToListAsync() : 
                await context.Where(filter).ToListAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}
