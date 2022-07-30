using FSM.Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSM.Calendar.Persistance.Configurations;

internal class ProcessAliasConfiguration : IEntityTypeConfiguration<ProcessAlias>
{
    public void Configure(EntityTypeBuilder<ProcessAlias> builder)
    {
        builder.ToTable("ProcessAliases")
               .HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
               .HasColumnType("int")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
               .HasColumnType("varchar(100)")
               .HasMaxLength(100)
               .IsRequired();

        builder.HasMany(t => t.Processes)
               .WithOne(t => t.ProcessAlias)
               .HasForeignKey(t => t.ProcessAliasId)
               .HasPrincipalKey(t => t.Id)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}