using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class JobGroup
{
    public int Id { get; set; }

    public string? JobGroup1 { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<QualitativeGroup> QualitativeGroups { get; set; } = new List<QualitativeGroup>();
}
