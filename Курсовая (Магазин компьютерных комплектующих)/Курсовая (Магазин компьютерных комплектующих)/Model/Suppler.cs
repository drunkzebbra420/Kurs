using System;
using System.Collections.Generic;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class Suppler
{
    public int IdSupplers { get; set; }

    public string? NameSupplers { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
