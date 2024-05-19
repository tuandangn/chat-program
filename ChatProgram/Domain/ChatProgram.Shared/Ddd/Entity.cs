namespace ChatProgram.Shared.Ddd;

[Serializable]
public abstract record Entity
{
    protected Entity(Guid id) => Id = id;

    public Guid Id { get; }
}
