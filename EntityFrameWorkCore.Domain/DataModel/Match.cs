using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class Match : BaseEntity
{
    public Guid HomeTeamId { get; set; }
    public Guid AwayTeamId { get; set; }
    public decimal TicketPrice {  get; set; }
    public DateTime Match_Date { get; set; }
}
