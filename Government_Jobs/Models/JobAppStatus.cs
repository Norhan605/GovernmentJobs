using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class JobAppStatus
{
    public int Id { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<EmploymentApplication> EmploymentApplications { get; set; } = new List<EmploymentApplication>();
}
