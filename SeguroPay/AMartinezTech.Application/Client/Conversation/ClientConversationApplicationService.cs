using AMartinezTech.Application.Client.Conversation.Interfaces;
using AMartinezTech.Domain.Client.Entitties; 

namespace AMartinezTech.Application.Client.Conversation;

public class ClientConversationApplicationService(IClientConversationReadRepository readRepository, IClientConversationWriteRepository writeRepository)
{
    private readonly IClientConversationReadRepository _readRepository = readRepository;
    private readonly IClientConversationWriteRepository _writeRepository = writeRepository;

    #region "Writer"
    public async Task<Guid> PersistenceAsync(ClientConversationDto dto)
    {
        if (dto.Id == Guid.Empty) { return await CreateAsync(dto); }
        else { await UpdateAsync(dto); return dto.Id; }

    }

    private async Task UpdateAsync(ClientConversationDto dto)
    {
        var entity = ClientConversationEntity.Create(dto.Id, dto.ClientId, dto.Channel, dto.ContactNumber, dto.CreatedAt, dto.Subject, dto.Message, dto.CreatedBy);
        await _writeRepository.UpdateAsync(entity);
    }

    private async Task<Guid> CreateAsync(ClientConversationDto dto)
    {
        var entity = ClientConversationEntity.Create(dto.Id, dto.ClientId, dto.Channel, dto.ContactNumber, dto.CreatedAt, dto.Subject, dto.Message, dto.CreatedBy);
        await _writeRepository.CreateAsync(entity);
        return dto.Id;
    }

    #endregion

    #region "Read"
    public async Task<List<ClientConversationDto>> FilterAsync(Dictionary<string, object?>? filter = null, Dictionary<string, object?>? globalSearch = null, bool? IsActive = null)
    {
        var result = await _readRepository.FilterAsync(filter, globalSearch, IsActive);
        return ClientConversationMapper.ToDtoList(result);
    }

    public async Task<ClientConversationDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id);    
        return ClientConversationMapper.ToDto(result);
    }

     
    #endregion
}



