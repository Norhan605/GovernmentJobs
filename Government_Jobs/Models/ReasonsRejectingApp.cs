using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class ReasonsRejectingApp
{
    public int Id { get; set; }

    public string? Reason { get; set; }

    public virtual ICollection<EmploymentApplication> EmploymentApplications { get; set; } = new List<EmploymentApplication>();
}
