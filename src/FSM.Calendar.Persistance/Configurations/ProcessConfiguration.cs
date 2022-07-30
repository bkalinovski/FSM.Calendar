using FSM.Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSM.Calendar.Persistance.Configurations;

internal class ProcessConfiguration : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.ToTable("Processes")
               .HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
               .HasColumnType("int")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
               .HasColumnType("varchar(100)")
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(t => t.ExternalId)
               .IsUnicode();

        builder.HasOne(t => t.ProcessAlias)
               .WithMany(t => t.Processes)
               .HasForeignKey(t => t.ProcessAliasId)
               .HasPrincipalKey(t => t.Id)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}