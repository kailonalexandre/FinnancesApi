using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories");
            // Define the primary key for the CategoryEntity
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Color)
                .HasMaxLength(20);

            // Add if not present, and ensure no default value is set
            builder.Property(x => x.CreateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false);

            builder.Property(x => x.UpdateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false);
        }
    }
    
}