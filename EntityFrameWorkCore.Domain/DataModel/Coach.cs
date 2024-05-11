﻿using EntityFrameWorkCore.Domain.BaseModel;

namespace EntityFrameWorkCore.Domain.DataModel;

public partial class Coach : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    //public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
