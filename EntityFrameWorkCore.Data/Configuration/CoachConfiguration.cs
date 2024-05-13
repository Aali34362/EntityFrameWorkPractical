using EntityFrameWorkCore.Domain.DataModel;
using EntityFrameWorkCore.Domain.DataModel.RelationalModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configuration;

internal class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(l => l.CoachAndTeam)
             .WithOne(lt => lt.Coach)
             .HasForeignKey<CoachAndTeam>(lt => lt.CoachId);
    }
}
