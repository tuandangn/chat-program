using ChatProgram.Contracts.Dtos.Messages.Conversations;

namespace ChatProgram.Contracts.Services;

public interface IConversationManager
{
    Task<FindConversationResultDto> FindConversation(FindConversationDto dto);
    Task<CreateConversationResultDto> CreateConversationAsync(CreateConversationDto dto);
}
