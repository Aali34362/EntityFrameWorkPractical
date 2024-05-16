using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.Response;

public class CoachList : BaseResponse
{
    public string? Name { get; set; }
}