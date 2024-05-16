using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.Response;

public class TeamDetails : BaseResponse
{
    public string? TeamName { get; set; }
    public int? TeamMembers { get; set; }
    public string? TeamType { get; set; }
    public Guid CoachId { get; set; }
    public Guid LeagueId { get; set; }
}
