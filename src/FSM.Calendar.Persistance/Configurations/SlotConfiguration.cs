using FSM.Calendar.Domain.Entities;
using FSM.Calendar.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSM.Calendar.Persistance.Configurations;

internal class SlotConfiguration : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> builder)
    {
        builder.ToTable("Slots")
               .HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Date)
               .HasColumnType("date")
               .IsRequired()
               .HasConversion<DateOnlyConverter, DateOnlyComparer>();
        
        builder.Property(t => t.FromTime)
               .HasColumnType("time(7)")
               .IsRequired()
               .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
        
        builder.Property(t => t.ToTime)
               .HasColumnType("time(7)")
               .IsRequired()
               .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
    }
}