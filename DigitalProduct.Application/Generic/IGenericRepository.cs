using System.Linq.Expressions;

namespace DigitalProduct.Application.Generic;

public interface IGenericRepository<T> where T : class
{
    T Get(long id);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);

    void Add(T entity);
    void Add(IEnumerable<T> entities);

    void Update(T entity);
    void Update(IEnumerable<T> entities);

    void Remove(T entity);
    void Remove(IEnumerable<T> entities);
}
