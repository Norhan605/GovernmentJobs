using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class ComputerSkill
{
    public int Id { get; set; }

    public int? SkillTypeId { get; set; }

    public int? SkillNameId { get; set; }

    public int? EvaluationId { get; set; }

    public int? EmploymentAppId { get; set; }

    public virtual EmploymentApplication? EmploymentApp { get; set; }

    public virtual Evaluation? Evaluation { get; set; }

    public virtual SkillName? SkillName { get; set; }

    public virtual SkillType? SkillType { get; set; }
}
