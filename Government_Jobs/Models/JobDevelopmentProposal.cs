using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class JobDevelopmentProposal
{
    public int Id { get; set; }

    public string? DevelopmentProposal { get; set; }

    public string? ProposalGoals { get; set; }

    public string? ProposalImportance { get; set; }

    public string? ReqImplementProposal { get; set; }

    public string? ExpectedReturn { get; set; }

    public string? Achivements { get; set; }

    public string? Notes { get; set; }

    public string? DurationImplementation { get; set; }

    public virtual ICollection<EmploymentApplication> EmploymentApplications { get; set; } = new List<EmploymentApplication>();
}
