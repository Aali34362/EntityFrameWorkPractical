using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel.RelationalModel;

public class TeamAndLeague : BaseEntity
{
    public Guid TeamId { get; set; }
    public virtual Team? Team { get; set; }

    public Guid LeagueId { get; set; }
    public virtual League? League { get; set; }
}
