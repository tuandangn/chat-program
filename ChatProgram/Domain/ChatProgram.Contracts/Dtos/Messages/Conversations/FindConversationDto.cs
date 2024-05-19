namespace ChatProgram.Contracts.Dtos.Messages.Conversations;

[Serializable]
public sealed record FindConversationDto(Guid participant1, Guid participant2);
