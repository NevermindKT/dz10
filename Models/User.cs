using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}