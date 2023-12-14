using System.Linq.Expressions;

namespace GymManager.Entities.Interfaces.Repositories
{
    public interface IGenericRepository<T, TId> where T : EntityBase
    {
        Task<T> Insert(T entity);
        Task<T?> GetById(TId id, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetByExpression(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        void Update(T entity);
        Task<bool> SoftDelete(TId id);
        Task<bool> HardDelete(TId id);
    }
}