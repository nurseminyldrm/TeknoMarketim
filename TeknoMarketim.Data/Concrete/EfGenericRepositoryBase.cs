

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeknoMarketim.Data.Abstract;

namespace TeknoMarketim.Data.Concrete;

public class EfGenericRepositoryBase<T, TContext>(TContext _context): IGenericRepository<T> where T : class where TContext : DbContext, new()
{
    //primary constructor injection yaptım...
    private readonly TContext context = _context ?? throw new ArgumentNullException(nameof(_context));
    private readonly DbSet<T> _dbSet = _context.Set<T>();

  

    public virtual void Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null!!!");
        }
            _dbSet.Add(entity);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null!!!");
        }
        _dbSet.Remove(entity);
        context.SaveChanges();
    }

    public bool Exist(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Any(predicate);
    }

    public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
    {
       return predicate == null ? _dbSet.ToList() : _dbSet.Where(predicate).ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public T GetOne(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.FirstOrDefault(predicate);
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null!!!");
        }
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}
