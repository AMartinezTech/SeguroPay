using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Client.Entitties;

namespace AMartinezTech.Application.Client;

public interface IClientReadRepository :  IGetById<ClientEntity,Guid>, IFilter<ClientEntity>, IPagination<ClientEntity>;
