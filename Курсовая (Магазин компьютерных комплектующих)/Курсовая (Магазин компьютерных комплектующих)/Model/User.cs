using System;
using System.Collections.Generic;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string LoginUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string NameUser { get; set; } = null!;

    public string SurNameUser { get; set; } = null!;

    public string? PatronymicUser { get; set; }

    public int RoleUser { get; set; }

    public string NumTelefonUser { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role RoleUserNavigation { get; set; } = null!;
}
