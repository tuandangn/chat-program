using ChatProgram.Shared.Ddd;

namespace ChatProgram.Domain.Entities.Logs;

[Serializable]
public record BaseLogEntry : ValueObject
{
    public string Content { get; internal init; }
        = string.Empty;
    public DateTime CreatedOnUtc { get; internal init; }
}
