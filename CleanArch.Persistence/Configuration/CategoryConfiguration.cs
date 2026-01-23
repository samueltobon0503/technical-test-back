using CleanArch.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Persistence.Configuration
{
    public class CategoryConfiguration
    {
        public CategoryConfiguration(EntityTypeBuilder<CategoryEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Description).HasMaxLength(200).IsRequired(false);

            entityBuilder.HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
