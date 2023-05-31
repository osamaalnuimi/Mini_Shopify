using Microsoft.EntityFrameworkCore;
using Mini_Shopify.Entities.Data;
using Mini_Shopify.Entities.Repository.IRepositoryBase;
using System.Linq.Expressions;

namespace Mini_Shopify.Entities.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext DbContext { get; set; }
        public RepositoryBase(ApplicationDbContext applicationDbContext) 
        { 
            DbContext = applicationDbContext;
        }
        public void Create(T entity) => DbContext.Set<T>().Add(entity);

        public void Delete(T entity) => DbContext.Set<T>().Remove(entity);

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)=> DbContext.Set<T>().Update(entity);
    }
}
