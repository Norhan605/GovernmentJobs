using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Language
{
    public int Id { get; set; }

    public string? Language1 { get; set; }

    public int? DegreeProficiencyId { get; set; }

    public int? EmploymentAppId { get; set; }

    public virtual DegreeProficiency? DegreeProficiency { get; set; }

    public virtual EmploymentApplication? EmploymentApp { get; set; }
}
