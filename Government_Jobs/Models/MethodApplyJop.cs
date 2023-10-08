using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class MethodApplyJop
{
    public int Id { get; set; }

    public string? Method { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
