using System;
using System.Collections.Generic;

namespace StoreDomain.Models;

public partial class Admin: Entity
{
    public int IdAdmin { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Possition { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
