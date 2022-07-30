using FSM.Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSM.Calendar.Persistance.Configurations;

public class SlotAssignmentConfiguration : IEntityTypeConfiguration<SlotAssignment>
{
    public void Configure(EntityTypeBuilder<SlotAssignment> builder)
    {
        builder.ToTable("SlotAssignments")
               .HasKey(t => new { t.SlotId, RegionId = t.TerritoryAliasId, t.ProcessAliasId });

        builder.HasOne(t => t.TerritoryAlias)
               .WithMany(t => t.SlotAssignments)
               .HasForeignKey(t => t.TerritoryAliasId)
               .HasPrincipalKey(t => t.Id);
           
        builder.HasOne(t => t.Slot)
               .WithMany(t => t.SlotAssignments)
               .HasForeignKey(t => t.SlotId)
               .HasPrincipalKey(t => t.Id);
           
        builder.HasOne(t => t.ProcessAlias)
               .WithMany(t => t.SlotAssignments)
               .HasForeignKey(t => t.ProcessAliasId)
               .HasPrincipalKey(t => t.Id);
    }
}