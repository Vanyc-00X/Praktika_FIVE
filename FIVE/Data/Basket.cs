using System;
using System.Collections.Generic;

namespace FIVE.Data;

public partial class Basket
{
    public int IdBasket { get; set; }

    public int IdUser { get; set; }

    public int IdTovar { get; set; }

    public int? CountTovar { get; set; }

    public virtual Tovar IdTovarNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
