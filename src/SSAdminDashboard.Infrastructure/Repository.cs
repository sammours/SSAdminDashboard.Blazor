namespace SSAdminDashboard.Domain;

using Microsoft.EntityFrameworkCore;
using SSAdminDashboard.Infrastructure;
using SSAdminDashboard.Infrastructure.Extensions;
using System.Linq.Expressions;

public abstract class Repository<TEntity>(AdDbContext dbContext) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    protected AdDbContext DbContext { get; set; } = dbContext;

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? expression = null, QueryOptions<TEntity>? options = null, CancellationToken? cancellationToken = null)
         => await this.DbContext.Set<TEntity>()
            .WhereIf(expression)
            .ApplyQueryOptions(options)
            .ToListAsync(cancellationToken ?? CancellationToken.None);

    public async Task<IEnumerable<TEntity>> GetAsync(List<Expression<Func<TEntity, bool>>>? expressions = null, QueryOptions<TEntity>? options = null, CancellationToken? cancellationToken = null)
         => await this.DbContext.Set<TEntity>()
            .WhereIf(expressions)
            .ApplyQueryOptions(options)
            .ToListAsync(cancellationToken ?? CancellationToken.None);

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken? cancellationToken = null)
         => await this.DbContext.Set<TEntity>()
            .WhereIf(expression)
            .CountAsync(cancellationToken ?? CancellationToken.None);

    public async Task<int> CountAsync(List<Expression<Func<TEntity, bool>>>? expressions = null, CancellationToken? cancellationToken = null)
         => await this.DbContext.Set<TEntity>()
            .WhereIf(expressions)
            .CountAsync(cancellationToken ?? CancellationToken.None);

    public async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken)
        => await this.DbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, QueryOptions<TEntity>? options = null, CancellationToken? cancellationToken = null)
        => await this.DbContext.Set<TEntity>()
            .WhereIf(expression)
            .ApplyQueryOptions(options)
            .FirstOrDefaultAsync(cancellationToken ?? CancellationToken.None);

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
    {
        this.DbContext.Set<TEntity>().Add(entity);
        await this.DbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        this.DbContext.Set<TEntity>().Update(entity);
        await this.DbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync(long entity, CancellationToken cancellationToken)
    {
        var dbEntity = await this.GetByIdAsync(entity, cancellationToken);
        if (dbEntity is not null)
        {
            this.DbContext.Remove(dbEntity);
            await this.DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}