using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Grievance
{
    public int Id { get; set; }

    public DateTime? StartGrievances { get; set; }

    public DateTime? EndGrievances { get; set; }

    public bool? GrievanceInquiry { get; set; }

    public DateTime? ExtendGrievance { get; set; }

    public int? GrievanceResultId { get; set; }

    public int? GrievanceDetailsId { get; set; }

    public virtual ICollection<EmploymentApplication> EmploymentApplications { get; set; } = new List<EmploymentApplication>();

    public virtual GrievancesDetail? GrievanceDetails { get; set; }

    public virtual GrievancesResult? GrievanceResult { get; set; }
}
