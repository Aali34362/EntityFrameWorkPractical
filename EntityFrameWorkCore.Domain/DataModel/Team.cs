using EntityFrameWorkCore.Domain.BaseModel;
using EntityFrameWorkCore.Domain.DataModel.RelationalModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class Team : BaseEntity
{
    public string TeamName { get; set; } = string.Empty;
    public int? TeamMembers { get; set; }
    public string TeamType { get; set; } = string.Empty;

    public Guid CoachId { get; set; }
    public virtual Coach? Coach { get; set; }

    public Guid LeagueId { get; set; }
    public virtual League? League { get; set; }

    public virtual TeamAndLeague? TeamAndLeague { get; set; }
    public virtual CoachAndTeam? CoachAndTeam { get; set; }
    public virtual List<Match>? HomeMatches { get; set; }
    public virtual List<Match>? AwayMatches { get; set; }
}

