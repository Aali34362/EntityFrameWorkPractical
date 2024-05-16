using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.Response;

public class TeamList : BaseResponse
{
    public string? TeamName { get; set; }
    public int? TeamMembers { get; set; }
    public string? TeamType { get; set; }
}
