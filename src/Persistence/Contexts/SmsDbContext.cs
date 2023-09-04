using CoreFramework.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class SmsDbContext : DbContext
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
            
            //modelBuilder.Entity<Location>(a =>
            //{
            //    a.ToTable("Locations").HasKey(k => k.Id);
            //});

        }
    }
}
