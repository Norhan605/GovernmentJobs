using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class GrievancesResult
{
    public int Id { get; set; }

    public string? Result { get; set; }

    public virtual ICollection<Grievance> Grievances { get; set; } = new List<Grievance>();
}
