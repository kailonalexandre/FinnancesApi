using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            
            builder.HasKey(u => u.Id);
            
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

            builder.Property(x => x.CreateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false);

            builder.Property(x => x.UpdateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false);
        }
    }
}
