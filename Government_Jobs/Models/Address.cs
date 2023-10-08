using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? UnitNum { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
