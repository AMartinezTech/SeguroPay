using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Clients.Entitties;

namespace AMartinezTech.Application.Clients;

public interface IClientWriteRepository : ICreate<ClientEntity>, IUpdate<ClientEntity>, IDelete<Guid>;