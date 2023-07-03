﻿using System;
using System.Collections.Generic;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class Role
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
