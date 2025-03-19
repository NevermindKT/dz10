using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models;

public partial class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100,MinimumLength = 3)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}