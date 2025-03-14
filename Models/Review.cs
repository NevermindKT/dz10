using System;
using System.Collections.Generic;

namespace Store.Models;

public partial class Review
{
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? IdUser { get; set; }

    public string? ReviewDescription { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
