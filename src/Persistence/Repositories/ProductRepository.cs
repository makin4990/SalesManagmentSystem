using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using CoreFramework.Persistence.Repositories;

namespace Persistence.Repositories;

public class ProductRepository: EfRepositoryBase<Product, SmsDbContext>, IProductRepository
{
    public ProductRepository(SmsDbContext context):base(context)
    {

    }
}

