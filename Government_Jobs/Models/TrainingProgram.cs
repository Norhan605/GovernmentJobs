using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class TrainingProgram
{
    public int Id { get; set; }

    public string? TrainingName { get; set; }

    public string? TrainingPlace { get; set; }

    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public int? TrainingTypeId { get; set; }

    public int? EmploymentAppId { get; set; }

    public virtual EmploymentApplication? EmploymentApp { get; set; }
}
