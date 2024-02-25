using System;
using System.Collections.Generic;

namespace StoreDomain.Models;

public partial class OrderItem: Entity
{
    public int IdItem { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int OrderItemQuantity { get; set; }

    public decimal PriceUnit { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
