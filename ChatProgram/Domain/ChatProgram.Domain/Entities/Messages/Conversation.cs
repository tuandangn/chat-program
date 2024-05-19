using ChatProgram.Domain.Entities.Logs;
using ChatProgram.Shared.Ddd;

namespace ChatProgram.Domain.Entities.Messages;

[Serializable]
public sealed record Conversation : AggregateEntity
{
    #region Ctor

    internal Conversation(IList<Participant> participants, string? name = null)
        : this(Guid.NewGuid(), participants, name, [], DateTime.UtcNow)
    {
    }

    internal Conversation(Guid id, IList<Participant> participants, string? name, IList<ConversationLogEntry> logs, DateTime createdOnUtc)
        : base(id)
    {
        Name = name;
        CreatedOnUtc = createdOnUtc;
        _participants = participants;
        _logs = logs;
    }

    #endregion

    #region Fields

    private IList<Participant> _participants;
    private IList<ConversationLogEntry> _logs;

    #endregion

    public string? Name { get; }
    public IEnumerable<Participant> Participants => _participants ??= [];
    public IEnumerable<ConversationLogEntry> Logs => _logs ??= [];
    public DateTime CreatedOnUtc { get; }

    #region Methods

    internal void AddParticipant(Participant participant)
    {
        if (Participants.Any(p => p == participant))
            throw new ArgumentException("Duplicate participant", nameof(participant));

        _participants.Add(participant);
    }
    internal bool RemoveParticipant(Participant participant)
    {
        for (var i = 0; i < _participants.Count; i++)
        {
            if (_participants[0] == participant)
            {
                _participants.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    internal void AddLog(string content, ConversationLogReason reason, bool notifyToParticipants)
    {
        var entry = new ConversationLogEntry
        {
            Content = content,
            Reason = reason,
            NotifyToParticipants = notifyToParticipants,
            CreatedOnUtc = DateTime.UtcNow
        };
        _logs.Add(entry);
    }

    #endregion
}
