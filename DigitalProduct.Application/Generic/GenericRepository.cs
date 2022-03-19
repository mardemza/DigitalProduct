using DigitalProduct.EntityFramework;
using System.Linq.Expressions;

namespace DigitalProduct.Application.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private DigitalProductDbContext _context;
    public DigitalProductDbContext Context
    {
        get
        {
            if (_context == null)
                _context = new DigitalProductDbContext();   
            return _context;
        }
    }

    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
        Context.SaveChanges();
    }
    public void Add(IEnumerable<T> entities)
    {
        Context.Set<T>().AddRange(entities);
        Context.SaveChanges();
    }

    public void Update(T entity)
    {
        Context.Set<T>().Update(entity);
        Context.SaveChanges();
    }
    public void Update(IEnumerable<T> entities)
    {
        Context.Set<T>().UpdateRange(entities);
        Context.SaveChanges();
    }
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().Where(expression);
    }
    public IEnumerable<T> GetAll()
    {
        return Context.Set<T>().ToList();
    }
    public T Get(long id)
    {
        return Context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
        Context.SaveChanges();
    }
    public void Remove(IEnumerable<T> entities)
    {
        Context.Set<T>().RemoveRange(entities);
        Context.SaveChanges();
    }
}
