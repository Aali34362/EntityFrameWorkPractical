namespace EntityFrameWorkCore.Domain.BaseModel;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public string Crtd_User { get; set; } = string.Empty;
    public string Lst_Crtd_User { get; set; } = string.Empty;
    public DateTime Crtd_Date { get; set; }
    public DateTime Lst_Crtd_Date { get; set; }
    public bool Act_Ind { get; set; }
    public bool Del_Ind { get; set; }
}

//Creating abstract class because i dont want to instantiate it.
