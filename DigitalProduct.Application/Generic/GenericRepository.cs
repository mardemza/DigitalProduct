using DigitalProduct.EntityFramework;
using System.Linq.Expressions;

namespace DigitalProduct.Application.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DigitalProductDbContext _context;
    public GenericRepository(DigitalProductDbContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void Add(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    public void Update(IEnumerable<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
    }
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public T Get(long id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void Remove(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}
