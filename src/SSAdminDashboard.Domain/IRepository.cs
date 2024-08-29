namespace SSAdminDashboard.Domain;

using System.Linq.Expressions;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? expression = null, QueryOptions<TEntity>? options = null, CancellationToken? cancellationToken = null);
    Task<IEnumerable<TEntity>> GetAsync(List<Expression<Func<TEntity, bool>>>? expressions = null, QueryOptions<TEntity>? options = null, CancellationToken? cancellationToken = null);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken? cancellationToken = null);
    Task<int> CountAsync(List<Expression<Func<TEntity, bool>>>? expressions = null, CancellationToken? cancellationToken = null);
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, QueryOptions<TEntity>? options = null, CancellationToken? cancellationToken = null);
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(long id, CancellationToken cancellationToken);
}