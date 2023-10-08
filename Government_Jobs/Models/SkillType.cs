using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class SkillType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<ComputerSkill> ComputerSkills { get; set; } = new List<ComputerSkill>();
}
