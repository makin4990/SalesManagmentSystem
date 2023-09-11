using CoreFramework.Persistence.Repositories;
using CoreFramework.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {
    }
}
