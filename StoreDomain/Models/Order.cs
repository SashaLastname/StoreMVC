using System;
using System.Collections.Generic;

namespace StoreDomain.Models;

public partial class Order:Entity
{
    public int IdOrder { get; set; }

    public int CustomerId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public int? AdminId { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
