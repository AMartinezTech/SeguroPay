using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Client.Entitties;

namespace AMartinezTech.Application.Client;

public interface IClientWriteRepository : ICreate<ClientEntity>, IUpdate<ClientEntity>, IDelete<Guid>;