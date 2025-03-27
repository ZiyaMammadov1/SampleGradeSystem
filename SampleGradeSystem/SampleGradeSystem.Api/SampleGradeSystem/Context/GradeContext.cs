using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using SampleGradeSystem.Models.Common;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Context
{
    public class GradeContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public GradeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeType> GradeTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries<IEntity>().ToList();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.ModifyTime = DateTime.UtcNow;
                }
                else if (entity.State == EntityState.Deleted)
                {
                    entity.Entity.isDeleted = true;
                    entity.State = EntityState.Modified;
                }
                else if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreateTime = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SQLSERVER_CONSTR"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
                }
            }

        }

    }

}
