using System;
using System.Collections.Generic;

namespace StoreDomain.Models;

public partial class Cart: Entity
{
    public int IdCart { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
