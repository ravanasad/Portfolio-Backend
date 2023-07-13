using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityDal<T> where T: BaseEntity
    {
        DbSet<T> Table { get; }
        Task<T> GetByIdAsync(int id,bool tracked = false);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, bool tracked = false);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
