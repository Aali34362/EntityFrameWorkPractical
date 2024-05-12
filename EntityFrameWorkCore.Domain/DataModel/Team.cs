using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class Team : BaseEntity
{
    public string TeamName { get; set; } = string.Empty;
    public int? TeamMembers { get; set; }
    public Guid LeagueId { get; set; }
    public Guid CoachId { get; set; }
    ////public virtual League? League { get; set; } // Assuming there's a League entity
    ////public virtual Coach? Coach { get; set; } // Assuming there's a Coach entity
}

