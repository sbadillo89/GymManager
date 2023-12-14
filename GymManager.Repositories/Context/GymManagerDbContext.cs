using System.Linq.Expressions;
using GymManager.Entities;
using GymManager.Entities.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GymManager.Repositories
{
    public class GymManagerDbContext : IdentityDbContext
    {
        public GymManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CashBox> CashBoxes { get; set; }
        public DbSet<CustomerChanges> CustomerChanges { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerDimensions> CustomerDimensions { get; set; }
        public DbSet<DocumentTypes> DocumentTypes { get; set; }
        public DbSet<GymLocations> GymLocations { get; set; }
        public DbSet<Gyms> Gyms { get; set; }
        public DbSet<MembershipTypes> MembershipTypes { get; set; }
        public DbSet<MembershipTypeChanges> MembershipTypeChanges { get; set; }
        public DbSet<MembershipCustomers> MembershipCustomers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionTypes> TransactionTypes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            modelBuilder.ApplyConfiguration(new TransactionTypesSeeds());
            modelBuilder.ApplyConfiguration(new DocumentTypesSeeds());

            Expression<Func<EntityBase, bool>> filterExpr = eb => !eb.IsDeleted;
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                // check if current entity type is child of BaseModel
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(EntityBase)))
                {
                    // modify expression to handle correct child type
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);

                    // set filter
                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }
        }
    }
}