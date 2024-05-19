namespace ChatProgram.Shared.Ddd;

[Serializable]
public abstract record AggregateEntity
{
    protected AggregateEntity(Guid id) => Id = id;

    public Guid Id { get; }
}
