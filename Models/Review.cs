using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models;

public partial class Review
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Product")]
    public int? IdProduct { get; set; }
    [ForeignKey("User")]
    public int? IdUser { get; set; }
    [Required]
    [StringLength(500, MinimumLength = 3)]
    public string? ReviewDescription { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
