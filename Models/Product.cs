using System;
using System.Collections.Generic;

namespace Store.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdCategory { get; set; }

    public int? Quantity { get; set; }

    public int? IdRevew { get; set; }

    public string DisplayProduct => $"{Name} ({Quantity})";

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Review? IdRevewNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
