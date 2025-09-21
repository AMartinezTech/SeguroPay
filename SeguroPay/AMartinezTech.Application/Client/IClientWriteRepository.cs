using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Client;

public interface IClientWriteRepository : ICreate<ClientEntity>, IUpdate<ClientEntity>, IDelete<Guid>;