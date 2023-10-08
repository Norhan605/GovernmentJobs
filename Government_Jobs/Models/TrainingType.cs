using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class TrainingType
{
    public int Id { get; set; }

    public string? TrainingType1 { get; set; }

    public virtual TrainingProgram IdNavigation { get; set; } = null!;
}
