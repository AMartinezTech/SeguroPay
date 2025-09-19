using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Clients.Entitties;

namespace AMartinezTech.Application.Clients;

public interface IClientReadRepository :  IGetById<ClientEntity,Guid>, IFilter<ClientEntity>, IPagination<ClientEntity>;
