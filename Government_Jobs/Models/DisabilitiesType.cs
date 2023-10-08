using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class DisabilitiesType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
