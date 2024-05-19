using ChatProgram.Shared.Ddd;

namespace ChatProgram.Data;

public interface IDbContext
{
    IQueryable<TEntity> GetDataSource<TEntity>() where TEntity : AggregateEntity;

    Task<IEnumerable<TEntity>> GetDataAsync<TEntity>() where TEntity : AggregateEntity;

    Task<TEntity?> FindAsync<TEntity>(Guid key, CancellationToken cancellationToken = default)
        where TEntity : AggregateEntity;

    Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : AggregateEntity;

    Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : AggregateEntity;

    Task<TEntity> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
             where TEntity : AggregateEntity;
}