﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkCore.Domain.BaseModel;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Crtd_User { get; set; } = string.Empty;
    public string Lst_Crtd_User { get; set; } = string.Empty;
    public DateTime Crtd_Date { get; set; }
    public DateTime Lst_Crtd_Date { get; set; }
    [DefaultValue(1)]
    public short Act_Ind { get; set; } = 1;
    [DefaultValue(0)]
    public short Del_Ind { get; set; } = 0;
    //For Sql Server Only
    ////[Timestamp]
    ////public byte[]? Version { get; set; }

    [ConcurrencyCheck]
    public Guid Version { get; set; }
}

//Creating abstract class because i dont want to instantiate it.
