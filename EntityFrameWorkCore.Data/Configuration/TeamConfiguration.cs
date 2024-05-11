using EntityFrameWorkCore.Domain.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configuration;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(x => x.Id);

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
