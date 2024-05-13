using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkCore.Domain.DataModel.RelationalModel;
using EntityFrameWorkCore.Domain.DataModel;

namespace EntityFrameWorkCore.Data.Configuration.RelationalConfiguration;

internal class CoachAndTeamConfiguration : IEntityTypeConfiguration<CoachAndTeam>
{
    public void Configure(EntityTypeBuilder<CoachAndTeam> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(q => q.Coach)
            .WithOne(q => q.CoachAndTeam)
            .HasForeignKey<CoachAndTeam>(q => q.CoachId)
            .IsRequired();

        builder.HasOne(q => q.Team)
            .WithOne(q => q.CoachAndTeam)
            .HasForeignKey<CoachAndTeam>(q => q.TeamId)
            .IsRequired();
    }
}
