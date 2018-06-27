using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using InGame.BestPractice.Authorization.Roles;
using InGame.BestPractice.Authorization.Users;
using InGame.BestPractice.MultiTenancy;
using InGame.BestPractice.Store;

namespace InGame.BestPractice.EntityFrameworkCore
{
    public class BestPracticeDbContext : AbpZeroDbContext<Tenant, Role, User, BestPracticeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public BestPracticeDbContext(DbContextOptions<BestPracticeDbContext> options)
            : base(options)
        {




        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasOne(f => f.Category).WithMany().HasForeignKey(f=>f.CategoryId);
            modelBuilder.Entity<Category>().HasOne(f => f.ParentCategory).WithMany(f=>f.SubCategories).HasForeignKey(f=>f.ParentCategoryId).IsRequired(false);
        }
    }
}
