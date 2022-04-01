namespace AutoComplete.Repository.Interface;

using System.Linq.Expressions;
public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);
    Task Create(T entity);
    void CreateMany(T[] entities);
    void Update(T entity);
    void Delete(T entity);

}
