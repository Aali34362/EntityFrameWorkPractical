using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.Response;

public class LeagueDetails : BaseResponse
{
    public string? Name { get; set; }
}
