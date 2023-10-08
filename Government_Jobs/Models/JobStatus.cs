using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class JobStatus
{
    public int Id { get; set; }

    public string? JopStatus { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
