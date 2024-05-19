using ChatProgram.Shared.Ddd;

namespace ChatProgram.Domain.Entities.Messages;

[Serializable]
public sealed record Participant : ValueObject, IEquatable<Participant>
{
    #region Ctor

    internal Participant(Guid userId, string name)
    {
        UserId = userId;
        Name = name;
    }

    #endregion

    public Guid UserId { get; set; }
    public string Name { get; }

    public bool IsLeft { get; private set; }
    public DateTime? LeftOnUtc { get; private set; }

    public DateTime JoinedOnUtc { get; }

    #region Overriden

    public bool Equals(Participant? other)
    {
        if (other == null) return false;
        return UserId == other.UserId;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(EqualityComparer<Type>.Default.GetHashCode(EqualityContract),
            EqualityComparer<Guid>.Default.GetHashCode(UserId));
    }

    #endregion
}
