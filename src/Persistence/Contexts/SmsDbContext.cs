using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using User = Domain.Entities.User;

namespace Persistence.Contexts
{
    public class SmsDbContext : IdentityDbContext<User,Role,int>
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<AppointmentProduct> AppointmentProducts { get; set; }



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

            modelBuilder.Entity<Category>(a =>
            {
                a.ToTable("Categories").HasKey(k => k.Id);
                a.HasMany(p => p.Products)
                 .WithOne(c => c.Category)
                 .HasForeignKey(fk=> fk.CategoryId);
            });

            modelBuilder.Entity<AppointmentProduct>(a =>
            {
                a.HasKey(k => k.Id);

                a.HasOne(p => p.Product)
                .WithMany(ap => ap.Appointments)
                .HasForeignKey(fk => fk.ProductId);

                a.HasOne(ap => ap.Appointment)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => fk.AppointmentId);

            });

        }
    }
}
