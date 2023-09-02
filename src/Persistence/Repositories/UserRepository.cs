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
    public class UserRepository : EfRepositoryBase<User, SmsDbContext>, IUserRepository
    {
        public UserRepository(SmsDbContext context) : base(context)
        {
        }
    }
}
