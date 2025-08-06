using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
     public class FinancialAccountMap : IEntityTypeConfiguration<FinancialAccountEntity>
    {
        public void Configure(EntityTypeBuilder<FinancialAccountEntity> builder)
        {
            builder.ToTable("FinancialAccounts");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(f => f.Date)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(f => f.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.CategoryId)
                .IsRequired();

            builder.Property(x => x.CreateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false);

            builder.Property(x => x.UpdateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false);

            builder.HasOne(f => f.Category)
                .WithMany()
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}