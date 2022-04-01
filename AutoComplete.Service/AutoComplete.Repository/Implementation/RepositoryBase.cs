

using Microsoft.EntityFrameworkCore;

namespace AutoComplete.Repository.Implementation;

using Interface;
using DbContext;

using System.Linq.Expressions;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected CarAutoCompleteDbContext RepositoryContext;

    public RepositoryBase(CarAutoCompleteDbContext context) => RepositoryContext = context;

    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges
            ? RepositoryContext.Set<T>().Where(expression).AsNoTracking()
            : RepositoryContext.Set<T>().Where(expression);

    public async Task Create(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);

    public async void CreateMany(T[] entities) => await RepositoryContext.Set<T>().AddRangeAsync(entities);

    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}
