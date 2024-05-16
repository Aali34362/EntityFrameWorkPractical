using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.Response;

public class MatchDetails : BaseResponse
{
    public Guid HomeTeamId { get; set; }
    public int HomeTeamScore { get; set; }
    public Guid AwayTeamId { get; set; }
    public int AwayTeamScore { get; set; }
    public decimal TicketPrice { get; set; }
    public DateTime Match_Date { get; set; }
}
