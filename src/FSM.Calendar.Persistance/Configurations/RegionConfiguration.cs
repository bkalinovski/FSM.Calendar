using FSM.Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSM.Calendar.Persistance.Configurations;

internal class RegionConfiguration : IEntityTypeConfiguration<TerritoryAlias>
{
    public void Configure(EntityTypeBuilder<TerritoryAlias> builder)
    {
        builder.ToTable("TerritoryAliases")
               .HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
               .HasColumnType("int")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
               .HasColumnType("varchar(30)")
               .HasMaxLength(30)
               .IsRequired();

        builder.HasMany(t => t.Territories)
               .WithOne(t => t.TerritoryAlias)
               .HasForeignKey(t => t.RegionId)
               .HasPrincipalKey(t => t.Id)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}