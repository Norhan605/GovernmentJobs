using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class JobDetailsOffer
{
    public int Id { get; set; }

    public DateTime? TestDate { get; set; }

    public string? TestPlace { get; set; }

    public string? RejectionReason { get; set; }

    public int? GovernmentId { get; set; }

    public virtual ICollection<EmploymentApplication> EmploymentApplications { get; set; } = new List<EmploymentApplication>();

    public virtual Government? Government { get; set; }
}
