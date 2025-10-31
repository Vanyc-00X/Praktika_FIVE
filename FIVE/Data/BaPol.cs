using System;
using System.Collections.Generic;

namespace FIVE.Data;

public partial class BaPol
{
    public int IdBa { get; set; }

    public string? IdTovar { get; set; }

    public string? Count { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
