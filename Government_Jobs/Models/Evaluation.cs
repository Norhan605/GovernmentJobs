using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Evaluation
{
    public int Id { get; set; }

    public string? Evaluation1 { get; set; }

    public virtual ICollection<ComputerSkill> ComputerSkills { get; set; } = new List<ComputerSkill>();
}
