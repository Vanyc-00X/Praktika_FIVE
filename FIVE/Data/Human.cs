using System;
using System.Collections.Generic;

namespace FIVE.Data;

public partial class Human
{
    public int IdHuman { get; set; }

    public string Fio { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
