namespace SSAdminDashboard.Domain;

using System.Linq.Expressions;

public class QueryOptions<T>(int? skip = null, int? take = null, bool? trackChanges = false, Expression<Func<T, object>>? order = null, OrderDirection orderDirection = OrderDirection.Ascending,
        Expression<Func<T, object>>? include = null)
{
    public int Skip { get; set; } = skip ?? 0;
    public int Take { get; set; } = take ?? -1;
    public bool TrackChanges { get; set; } = trackChanges ?? false;
    public Expression<Func<T, object>>? Order { get; set; } = order;
    public OrderDirection OrderDirection { get; set; } = orderDirection;
    public Expression<Func<T, object>>? Include { get; set; } = include;
}
