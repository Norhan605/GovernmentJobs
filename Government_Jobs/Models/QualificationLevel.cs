using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class QualificationLevel
{
    public int Id { get; set; }

    public string? QualificationLevel1 { get; set; }

    public virtual ICollection<EmploymentApplication> EmploymentApplications { get; set; } = new List<EmploymentApplication>();

    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
}
