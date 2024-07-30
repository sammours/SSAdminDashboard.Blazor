namespace SSAdminDashboard.Infrastructure.Extensions;

using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SSAdminDashboard.Domain;

public static partial class EntityFrameworkExtensions
{
    public static IQueryable<T> ApplyQueryOptions<T>(
        this IQueryable<T> source,
        QueryOptions<T>? options)
        where T : class, IEntity
    {
        if (options == null)
        {
            return source;
        }

        if (options.Include is not null)
        {
            source = source.Include(options.Include);
        }

        if (options.Order is not null)
        {
            source = options.OrderDirection == OrderDirection.Ascending
                            ? Queryable.OrderBy(source, options.Order)
                            : Queryable.OrderByDescending(source, options.Order);
        }

        source = !options.TrackChanges ? source : source.AsNoTracking();
        source = source.Skip(options.Skip);
        source = options.Take != -1 ? source.Take(options.Take) : source;
        return source;
    }

    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> source,
        Expression<Func<T, bool>>? expression)
        where T : class, IEntity
    {
        if (expression == null)
        {
            return source;
        }

        return source.Where(expression);
    }
}
