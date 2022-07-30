using FSM.Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSM.Calendar.Persistance.Configurations;

internal class TerritoryConfiguration : IEntityTypeConfiguration<Territory>
{
    public void Configure(EntityTypeBuilder<Territory> builder)
    {
        builder.ToTable("Territories")
               .HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
               .HasColumnType("int")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
               .HasColumnType("varchar(30)")
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(t => t.ExternalId)
               .HasColumnType("varchar(50)")
               .HasMaxLength(50);

        builder.HasOne(t => t.TerritoryAlias)
               .WithMany(t => t.Territories)
               .HasForeignKey(t => t.RegionId)
               .HasPrincipalKey(t => t.Id)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}