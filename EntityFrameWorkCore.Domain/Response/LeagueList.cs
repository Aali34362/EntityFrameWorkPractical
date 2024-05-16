using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.Response;

public class LeagueList : BaseResponse
{
    public string? Name { get; set; }
}
