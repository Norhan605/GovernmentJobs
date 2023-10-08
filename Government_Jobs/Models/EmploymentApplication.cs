using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class EmploymentApplication
{
    public int Id { get; set; }

    public int? RequestNum { get; set; }

    public DateTime? ResultDate { get; set; }

    public DateTime? ExtendResultDate { get; set; }

    public int? UserId { get; set; }

    public int? JobId { get; set; }

    public int? JobAppStatusId { get; set; }

    public int? JobDetailOfferId { get; set; }

    public int? JopDevPropId { get; set; }

    public int? QualificationLevelId { get; set; }

    public int? GradeId { get; set; }

    public int? GrievancesId { get; set; }

    public int? ReasonsRejectId { get; set; }

    public virtual ICollection<ComputerSkill> ComputerSkills { get; set; } = new List<ComputerSkill>();

    public virtual Grade? Grade { get; set; }

    public virtual Grievance? Grievances { get; set; }

    public virtual Job? Job { get; set; }

    public virtual JobAppStatus? JobAppStatus { get; set; }

    public virtual JobDetailsOffer? JobDetailOffer { get; set; }

    public virtual ICollection<JobDocument> JobDocuments { get; set; } = new List<JobDocument>();

    public virtual JobDevelopmentProposal? JopDevProp { get; set; }

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual ICollection<LastExperience> LastExperiences { get; set; } = new List<LastExperience>();

    public virtual QualificationLevel? QualificationLevel { get; set; }

    public virtual ReasonsRejectingApp? ReasonsReject { get; set; }

    public virtual ICollection<TrainingProgram> TrainingPrograms { get; set; } = new List<TrainingProgram>();

    public virtual User? User { get; set; }
}
