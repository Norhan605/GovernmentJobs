using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class LastExperience
{
    public int Id { get; set; }

    public string? LastExperienceJob { get; set; }

    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public string? CompanyName { get; set; }

    public int? GovernmentalCategoryId { get; set; }

    public int? EmploymentAppId { get; set; }

    public virtual EmploymentApplication? EmploymentApp { get; set; }

    public virtual GovernmentCategory? GovernmentalCategory { get; set; }
}
