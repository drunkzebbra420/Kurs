using System;
using System.Collections.Generic;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class PickapPoint
{
    public int IdPickapPoint { get; set; }

    public int? IndexPickapPoint { get; set; }

    public string? SityPickapPoint { get; set; }

    public string? StreetPickapPoint { get; set; }

    public int? HousePickapPoint { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
