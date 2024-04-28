﻿using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore.Data.ScaffoldModels;

public partial class Coach
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? CrtdUser { get; set; }

    public string? LstCrtdUser { get; set; }

    public DateTime? CrtdDate { get; set; }

    public DateTime? LstCrtdDate { get; set; }

    public byte? ActInd { get; set; }

    public byte? DelInd { get; set; }
}
