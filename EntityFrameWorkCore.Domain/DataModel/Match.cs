using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class Match : BaseEntity
{
    public Guid HomeTeamId { get; set; }
    public virtual Team? HomeTeam { get; set; }
    public int HomeTeamScore { get; set; }

    public Guid AwayTeamId { get; set; }
    public virtual Team? AwayTeam { get; set; }
    public int AwayTeamScore { get; set; }
    
    
    public decimal TicketPrice {  get; set; }
    public DateTime Match_Date { get; set; }
}
