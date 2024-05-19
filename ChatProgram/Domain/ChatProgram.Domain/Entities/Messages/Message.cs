using ChatProgram.Shared.Ddd;

namespace ChatProgram.Domain.Entities.Messages;

[Serializable]
public sealed record Message : Entity
{
    #region Ctor

    internal Message(Guid senderId, Guid conversationId, string content)
        : this(Guid.NewGuid(), senderId, conversationId, content, DateTime.UtcNow)
    {
    }

    internal Message(Guid id, Guid senderId, Guid conversationId, string content, DateTime sentOnUtc)
        : base(id)
    {
        SenderId = senderId;
        ConversationId = conversationId;
        Content = content;
        SentOnUtc = sentOnUtc;
    }

    #endregion

    public Guid SenderId { get; }
    public Guid ConversationId { get; }
    public string Content { get; }
    public DateTime SentOnUtc { get; }
}
