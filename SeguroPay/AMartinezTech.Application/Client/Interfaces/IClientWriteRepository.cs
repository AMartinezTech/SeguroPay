using AMartinezTech.Domain.Client;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Client.Interfaces;

public interface IClientWriteRepository : ICreate<ClientEntity>, IUpdate<ClientEntity>;