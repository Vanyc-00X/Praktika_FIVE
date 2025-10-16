using System;
using System.Collections.Generic;

namespace FIVE.Data;

public partial class Tovar
{
    public int IdTovar { get; set; }

    public string NameTovar { get; set; } = null!;

    public int? Sell { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
}
