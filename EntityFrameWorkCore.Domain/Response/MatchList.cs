using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.Response;

internal class MatchList : BaseResponse
{
    public Guid HomeTeamId { get; set; }
    public Guid AwayTeamId { get; set; }
}
