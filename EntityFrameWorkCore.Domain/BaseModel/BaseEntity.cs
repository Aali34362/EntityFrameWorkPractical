using System.ComponentModel;

namespace EntityFrameWorkCore.Domain.BaseModel;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Crtd_User { get; set; } = string.Empty;
    public string Lst_Crtd_User { get; set; } = string.Empty;
    public DateTime Crtd_Date { get; set; } = DateTimeOffset.UtcNow.DateTime;
    public DateTime Lst_Crtd_Date { get; set; } = DateTimeOffset.UtcNow.DateTime;
    [DefaultValue(1)]
    public short Act_Ind { get; set; } = 1;
    [DefaultValue(0)]
    public short Del_Ind { get; set; } = 0;
}

//Creating abstract class because i dont want to instantiate it.
