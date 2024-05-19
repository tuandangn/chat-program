using ChatProgram.Shared.Ddd;
using Microsoft.EntityFrameworkCore;

namespace ChatProgram.Data.SqlServer;

public sealed class ChatProgramEfDbContext : DbContext, IDbContext
{
    public ChatProgramEfDbContext(DbContextOptions<ChatProgramEfDbContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatProgramEfDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public IQueryable<TEntity> GetDataSource<TEntity>() where TEntity : AggregateEntity
        => Set<TEntity>();

    public async Task<TEntity?> FindAsync<TEntity>(Guid key, CancellationToken cancellationToken = default)
        where TEntity : AggregateEntity
    {
        var entity = await FindAsync<TEntity>(new[] { key }).ConfigureAwait(false);
        return entity;
    }

    public Task<IEnumerable<TEntity>> GetDataAsync<TEntity>() where TEntity : AggregateEntity
    {
        IQueryable<TEntity> entities = Set<TEntity>();
        return Task.FromResult<IEnumerable<TEntity>>(entities);
    }

    async Task<TEntity> IDbContext.AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
    {
        await AddAsync((object)entity, cancellationToken).ConfigureAwait(false);
        await SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity;
    }

    async Task IDbContext.RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
    {
        Remove(entity);
        await SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    async Task<TEntity> IDbContext.UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
    {
        Update(entity);
        await SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity;
    }
}
