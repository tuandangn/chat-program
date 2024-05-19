namespace ChatProgram.Domain.Entities.Logs;

[Serializable]
public sealed record ConversationLogEntry : BaseLogEntry
{
    public ConversationLogReason Reason { get; internal init; }
    public bool NotifyToParticipants { get; internal init; }
}

public enum ConversationLogReason
{
    Generic,
    Join,
    Leave
}
