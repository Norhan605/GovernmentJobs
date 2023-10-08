﻿using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class UserType
{
    public int Id { get; set; }

    public string? UserType1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
