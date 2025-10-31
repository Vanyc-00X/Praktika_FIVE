using System;
using System.Collections.Generic;

namespace FIVE.Data;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdHuman { get; set; }

    public int IdRole { get; set; }

    public virtual ICollection<BaPol> BaPols { get; set; } = new List<BaPol>();

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual Human IdHumanNavigation { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
