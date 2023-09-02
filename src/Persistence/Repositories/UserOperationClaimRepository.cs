using Application.Services.Repositories;
using CoreFramework.Persistence.Repositories;
using CoreFramework.Security.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, SmsDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(SmsDbContext context) : base(context)
        {

        }
    }
}
