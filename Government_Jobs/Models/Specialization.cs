using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Specialization
{
    public int Id { get; set; }

    public string? Specialization1 { get; set; }

    public int? QualificationId { get; set; }

    public virtual Qualification? Qualification { get; set; }
}
