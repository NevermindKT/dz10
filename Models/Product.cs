using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100,MinimumLength = 3)]
    public string? Name { get; set; }
    [ForeignKey("Categorie")]
    public int? IdCategory { get; set; }
    [Range(0, 1000)]
    public int? Quantity { get; set; }
    [ForeignKey("Review")]
    public int? IdRevew { get; set; }

    public string DisplayProduct => $"{Name} ({Quantity})";

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Review? IdRevewNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
