using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
