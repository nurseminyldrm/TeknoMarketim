

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeknoMarketim.Data.Abstract;

namespace TeknoMarketim.Data.Concrete;

public class EfGenericRepositoryBase<T, TContext> : IGenericRepository<T> where T : class where TContext : DbContext, new()
{
    //protected readonly AppContext _appContext;
    //private readonly DbSet<T> _dbSet;
    //public EfGenericRepositoryBase(AppContext appContext, DbSet<T> dbSet)
    //{
    //    _appContext = appContext;
    //    _dbSet = dbSet;
    //}

    public virtual void Add(T entity)
    {
        using (var context = new TContext())
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
    }

    public void Delete(T entity)
    {
        using (var context = new TContext())
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
    }

    public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
    {
        using (var context = new TContext())
        {
            return predicate == null
                ? context.Set<T>().ToList()
                :context.Set<T>().Where(predicate).ToList();
        }
    }

    public T GetById(int id)
    {
        using (var context = new TContext())
        {
            return context.Set<T>().Find(id);
        }
    }

    public T GetOne(Expression<Func<T, bool>> predicate)
    {
        using(var context = new TContext())
        {
            return context.Set<T>().Where(predicate).SingleOrDefault();
        }
    }

    public void Update(T entity)
    {
        using(var context = new TContext())
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
