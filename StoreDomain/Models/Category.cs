using System;
using System.Collections.Generic;

namespace StoreDomain.Models;

public partial class Category: Entity
{
    public int IdCategory { get; set; }

    public string CategoryTitle { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
