using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class SkillName
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ComputerSkill> ComputerSkills { get; set; } = new List<ComputerSkill>();
}
