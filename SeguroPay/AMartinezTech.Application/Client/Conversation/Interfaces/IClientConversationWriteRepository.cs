using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Client.Conversation.Interfaces;

public   interface IClientConversationWriteRepository : ICreate<ClientConversationEntity>, IUpdate<ClientConversationEntity>;