using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models;

public partial class Order
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int IdUser { get; set; }
    [ForeignKey("Product")]
    public int IdProduct { get; set; }
    [Range(0, 1000)]
    public int Quantity { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
