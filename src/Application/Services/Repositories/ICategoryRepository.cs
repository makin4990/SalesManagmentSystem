using Domain.Entities;
using CoreFramework.Persistence.Repositories;

namespace Application.Services.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>, IRepository<Category>
    {
    }
}

