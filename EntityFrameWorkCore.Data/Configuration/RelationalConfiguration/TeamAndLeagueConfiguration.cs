using EntityFrameWorkCore.Domain.DataModel.RelationalModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configuration.RelationalConfiguration;

internal class TeamAndLeagueConfiguration : IEntityTypeConfiguration<TeamAndLeague>
{
    public void Configure(EntityTypeBuilder<TeamAndLeague> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(lt => lt.Team)
               .WithOne(t => t.TeamAndLeague)
               .HasForeignKey<TeamAndLeague>(lt => lt.TeamId);

        builder.HasOne(lt => lt.League)
               .WithOne(l => l.TeamAndLeague)
               .HasForeignKey<TeamAndLeague>(lt => lt.LeagueId);
    }
}