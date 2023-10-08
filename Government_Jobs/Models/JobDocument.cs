using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class JobDocument
{
    public int Id { get; set; }

    public string? PersonalImg { get; set; }

    public string? JobStatusStatement { get; set; }

    public string? Statement { get; set; }

    public string? AchievementsFile { get; set; }

    public string? CareerDevelopment { get; set; }

    public int? NationalId { get; set; }

    public int? CriminalRecordId { get; set; }

    public string? TrainingCertificates { get; set; }

    public string? StatementOfEmploymentStatus { get; set; }

    public string? JobProposal { get; set; }

    public string? Certificate { get; set; }

    public int? EmploymentAppId { get; set; }

    public virtual CriminalRecord? CriminalRecord { get; set; }

    public virtual EmploymentApplication? EmploymentApp { get; set; }

    public virtual CopNationalId? National { get; set; }
}
