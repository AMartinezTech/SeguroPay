using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Client;

public interface IClientReadRepository :  IGetById<ClientEntity,Guid>, IFilter<ClientEntity>, IPagination<ClientEntity>;
