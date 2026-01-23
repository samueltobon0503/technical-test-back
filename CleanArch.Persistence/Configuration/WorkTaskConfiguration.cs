using CleanArch.Domain.Entities.WorkTask;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Persistence.Configuration
{
    public class WorkTaskConfiguration
    {
        public WorkTaskConfiguration(EntityTypeBuilder<WorkTaskEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Status).IsRequired();
            entityBuilder.Property(x => x.DueDate).IsRequired();
            entityBuilder.Property(x => x.CategoryId).IsRequired();
            entityBuilder.Property(x => x.RowVersion).IsRowVersion();

            entityBuilder.HasOne(x => x.Category)
                .WithMany(c => c.WorkTasks)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasIndex(x => new { x.DueDate, x.Status })
                .HasFilter("[Status] = 0");
        }
    }
}
