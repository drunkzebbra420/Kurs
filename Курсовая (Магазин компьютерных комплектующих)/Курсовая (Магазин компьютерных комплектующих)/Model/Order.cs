using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? UserOrder { get; set; }

    public DateTime? DateOrder { get; set; }

    public int? PickapPointOrder { get; set; }

    public int? CodeToGet { get; set; }

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual PickapPoint? PickapPointOrderNavigation { get; set; }

    public virtual User? UserOrderNavigation { get; set; }
}
