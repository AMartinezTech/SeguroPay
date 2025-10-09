using AMartinezTech.Application.Client.Conversation;

namespace AMartinezTech.WinForms.Client.Conversations;

public class ClientConversationController(ClientConversationApplicationService service)
{
    private readonly ClientConversationApplicationService _service = service;

    public async Task<Guid> PersistenceAsync(ClientConversationDto dto)
    {
        return await _service.PersistenceAsync(dto);
    }

    public async Task<List<ClientConversationDto>> Filter(Dictionary<string, object?>? filter = null, Dictionary<string,object?>? globalSearch = null, bool? isActived = null)
    {
        return await _service.FilterAsync(filter, globalSearch, isActived);
    }
}
