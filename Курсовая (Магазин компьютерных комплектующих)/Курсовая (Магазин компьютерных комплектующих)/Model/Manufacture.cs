using System;
using System.Collections.Generic;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class Manufacture
{
    public int IdManufacture { get; set; }

    public string? NameManufacture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
