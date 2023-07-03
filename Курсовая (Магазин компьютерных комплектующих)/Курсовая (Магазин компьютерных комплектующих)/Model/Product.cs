using System;
using System.Collections.Generic;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? NameProduct { get; set; }

    public string? DiscriptionProduct { get; set; }

    public int? TypeProduct { get; set; }

    public int? ManufactureProduct { get; set; }

    public int? SupplProduct { get; set; }

    public int? CountInStockProduct { get; set; }

    public decimal? CostProduct { get; set; }

    public string? PhotoProduct { get; set; }

    public virtual Manufacture? ManufactureProductNavigation { get; set; }

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Suppler? SupplProductNavigation { get; set; }

    public virtual Type? TypeProductNavigation { get; set; }
}
