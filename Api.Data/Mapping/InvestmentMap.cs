using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class InvestmentMap : IEntityTypeConfiguration<InvestmentEntity>
    {
        public void Configure(EntityTypeBuilder<InvestmentEntity> builder)
        {
            builder.ToTable("Investments");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.InvestedAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.CurrentValue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.InvestmentTypeId)
                .IsRequired();

            builder.Property(x => x.CreateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false);

            builder.Property(x => x.UpdateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false);

            builder.HasOne(i => i.InvestmentType)
                .WithMany() // ou WithMany(t => t.Investments) se tiver o inverso
                .HasForeignKey(i => i.InvestmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}