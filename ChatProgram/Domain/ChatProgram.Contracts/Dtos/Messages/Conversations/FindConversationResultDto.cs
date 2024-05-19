namespace ChatProgram.Contracts.Dtos.Messages.Conversations;

[Serializable]
public sealed record FindConversationResultDto(bool Found, Guid? Id);
