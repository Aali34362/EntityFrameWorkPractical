using EntityFrameWorkCore.Domain.BaseModel;
using EntityFrameWorkCore.Domain.DataModel.RelationalModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class League : BaseEntity
{
    public string? Name { get; set; }
    public virtual List<Team> Teams { get; set; } = new List<Team>();
    public virtual TeamAndLeague? TeamAndLeague { get; set; }
}
