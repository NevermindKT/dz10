using System;
using System.Collections.Generic;

namespace Store.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
