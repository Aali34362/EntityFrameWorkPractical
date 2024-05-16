using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.Response;

public class CoachDetails : BaseResponse
{
    public string? Name { get; set; }
}
