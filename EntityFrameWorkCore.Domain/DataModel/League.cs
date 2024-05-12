using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class League : BaseEntity
{
    public string? Name { get; set; }
    public virtual ICollection<Team>? Teams { get; set; }
}
