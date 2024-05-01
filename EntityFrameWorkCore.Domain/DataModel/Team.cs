using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class Team : BaseEntity
{
    public string TeamName { get; set; } = string.Empty;
    public int TeamMembers { get; set; }
}
