using FSM.Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSM.Calendar.Persistance.Configurations;

public class TeamAssignmentConfiguration : IEntityTypeConfiguration<TeamAssignment>
{
    public void Configure(EntityTypeBuilder<TeamAssignment> builder)
    {
           builder.ToTable("TeamAssignments")
                  .HasKey(t => new { t.SlotId, t.TeamId, t.ProcessId, t.TerritoryId });

           builder.HasOne(t => t.Process)
                  .WithMany(t => t.TeamAssignments)
                  .HasForeignKey(t => t.ProcessId)
                  .HasPrincipalKey(t => t.Id);
           
           builder.HasOne(t => t.Slot)
                  .WithMany(t => t.TeamAssignments)
                  .HasForeignKey(t => t.SlotId)
                  .HasPrincipalKey(t => t.Id);
           
           builder.HasOne(t => t.Team)
                  .WithMany(t => t.TeamAssignments)
                  .HasForeignKey(t => t.TeamId)
                  .HasPrincipalKey(t => t.Id);
    }
}