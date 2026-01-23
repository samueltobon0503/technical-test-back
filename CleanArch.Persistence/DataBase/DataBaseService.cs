using CleanArch.Application.DataBase;
using CleanArch.Domain.Entities.Category;
using CleanArch.Domain.Entities.WorkTask;
using CleanArch.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanArch.Persistence.DataBase
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options) { }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<WorkTaskEntity> WorkTasks { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
        public new EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new CategoryConfiguration(modelBuilder.Entity<CategoryEntity>());
            new WorkTaskConfiguration(modelBuilder.Entity<WorkTaskEntity>());
        }
    }
}
