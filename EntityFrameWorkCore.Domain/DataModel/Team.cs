using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class Team : BaseEntity
{
    public string TeamName { get; set; } = string.Empty;
    public int? TeamMembers { get; set; }
    public string TeamType { get; set; } = string.Empty;
    
    public Guid LeagueId { get; set; }
    public virtual League? League { get; set; }
   
    public Guid CoachId { get; set; }   
    public virtual Coach? Coach { get; set; }

    public List<Match>? HomeMatches { get; set; }
    public List<Match>? AwayMatches { get; set; }
}

