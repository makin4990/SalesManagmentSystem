using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using CoreFramework.Persistence.Repositories;

namespace Persistence.Repositories;

public class CategoryRepository: EfRepositoryBase<Category, SmsDbContext>, ICategoryRepository
{
    public CategoryRepository(SmsDbContext context):base(context)
    {

    }
}

