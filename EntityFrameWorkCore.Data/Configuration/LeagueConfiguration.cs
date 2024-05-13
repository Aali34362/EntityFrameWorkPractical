using EntityFrameWorkCore.Domain.DataModel;
using EntityFrameWorkCore.Domain.DataModel.RelationalModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configuration;

internal class LeagueConfiguration : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(l => l.TeamAndLeague)
              .WithOne(lt => lt.League)
              .HasForeignKey<TeamAndLeague>(lt => lt.LeagueId);
    }
}
