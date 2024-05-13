using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel.RelationalModel;

public class CoachAndTeam : BaseEntity
{
    public Guid TeamId { get; set; }
    public virtual Team? Team { get; set; }
    public Guid CoachId { get; set; }
    public virtual Coach? Coach { get; set; }
}
