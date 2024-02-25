using System;
using System.Collections.Generic;

namespace StoreDomain.Models;

public partial class Customer: Entity
{
    public int IdCustomer { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
