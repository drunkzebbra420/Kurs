using System;
using System.Collections.Generic;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class Type
{
    public int IdType { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
