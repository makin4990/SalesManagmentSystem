using CoreFramework.Security.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Domain.Entities.User;

namespace Persistence.Contexts
{
    public class SmsDbContext : IdentityDbContext<User,Role,int>
    {
        protected IConfiguration Configuration { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<OperationClaim> OperationClaims { get; set; }
        //public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }


        public SmsDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Location>(a =>
            //{
            //    a.ToTable("Locations").HasKey(k => k.Id);
            //});

        }
    }
}
