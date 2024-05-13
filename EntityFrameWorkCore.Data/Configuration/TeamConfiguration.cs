using EntityFrameWorkCore.Domain.DataModel;
using EntityFrameWorkCore.Domain.DataModel.RelationalModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configuration;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(q => q.TeamName).IsUnique();

        builder.HasMany(q => q.HomeMatches)
            .WithOne(q => q.HomeTeam)
            .HasForeignKey(q => q.HomeTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(q => q.AwayMatches)
            .WithOne(q => q.AwayTeam)
            .HasForeignKey(q => q.AwayTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.TeamAndLeague)
               .WithOne(lt => lt.Team)
               .HasForeignKey<TeamAndLeague>(lt => lt.TeamId);

        builder.HasOne(t => t.CoachAndTeam)
               .WithOne(lt => lt.Team)
               .HasForeignKey<CoachAndTeam>(lt => lt.CoachId);


        // Set up the relationship between Team and League
        ////builder.HasOne(t => t.League)
        ////       .WithMany(l => l.Teams)
        ////       .HasForeignKey(t => t.LeagueId);

        // Set up the relationship between Team and Coach
        ////builder.HasOne(t => t.Coach)
        ////       .WithMany()
        ////       .HasForeignKey(t => t.CoachId);
    }
}
