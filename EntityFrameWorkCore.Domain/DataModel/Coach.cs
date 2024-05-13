using EntityFrameWorkCore.Domain.BaseModel;
using EntityFrameWorkCore.Domain.DataModel.RelationalModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class Coach : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual Team? Team { get; set; }
    public virtual CoachAndTeam? CoachAndTeam { get; set; }
}
