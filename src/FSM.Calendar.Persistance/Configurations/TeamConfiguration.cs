using FSM.Calendar.Domain.Entities;
using FSM.Calendar.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSM.Calendar.Persistance.Configurations;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams")
               .HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
               .HasColumnType("int")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
               .HasColumnType("varchar(10)")
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(t => t.Status)
               .HasColumnType("varchar(15)")
               .HasMaxLength(15)
               .HasConversion(status => status.ToString(), s => (Status)Enum.Parse(typeof(Status), s))
               .IsRequired();
    }
}