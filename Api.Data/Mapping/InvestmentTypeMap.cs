using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class InvestmentTypeMap : IEntityTypeConfiguration<InvestmentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<InvestmentTypeEntity> builder)
        {
            builder.ToTable("InvestmentTypes");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);
                    
            builder.Property(x => x.CreateAt)
                .HasColumnType("datetime(6)")
                .IsRequired(false); // Remove HasDefaultValue(null)


            // Relacionamento (se quiser ativar a navegação reversa no futuro):
            // builder.HasMany<InvestmentEntity>()
            //     .WithOne(i => i.InvestmentType)
            //     .HasForeignKey(i => i.InvestmentTypeId)
            //     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}