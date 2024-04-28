namespace EntityFrameWorkCore.Domain.BaseModel;

public abstract class BaseResponse
{
    public Guid Id { get; set; }
    public string Crtd_User { get; set; } = string.Empty;
    public string Lst_Crtd_User { get; set; } = string.Empty;
    public DateTime Crtd_Date { get; set; }
    public DateTime Lst_Crtd_Date { get; set; }
    public short Act_Ind { get; set; }
    public short Del_Ind { get; set; }
}
