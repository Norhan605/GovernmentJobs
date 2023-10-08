using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Job
{
    public int Id { get; set; }

    public DateTime? InqueryDate { get; set; }

    public string? JobName { get; set; }

    public string? JobDesc { get; set; }

    public string? BasicSkills { get; set; }

    public string? ArtisticSkills { get; set; }

    public int? ExpYears { get; set; }

    public string? ApplicationConditions { get; set; }

    public string? ContactDetails { get; set; }

    public bool? IsDistributed { get; set; }

    public int? MaxAge { get; set; }

    public string? EducationLevel { get; set; }

    public string? MinGrade { get; set; }

    public string? QualificationReq { get; set; }

    public string? ApplyDate { get; set; }

    public int? AdsId { get; set; }

    public string? AppLink { get; set; }

    public string? SubmitInfo { get; set; }

    public DateTime? InterviewDate { get; set; }

    public DateTime? InterviewStartdate { get; set; }

    public DateTime? InterviewEnddate { get; set; }

    public int? GrievancesId { get; set; }

    public DateTime? CloseInquery { get; set; }

    public string? NumOfApplicant { get; set; }

    public int? JobStatusId { get; set; }

    public bool? IsSpecialNeedAccept { get; set; }

    public int? GenderId { get; set; }

    public string? JobLevel { get; set; }

    public string? JobCode { get; set; }

    public string? JobLocation { get; set; }

    public string? JobPath { get; set; }

    public string? JobGoal { get; set; }

    public int? JobInfoId { get; set; }

    public int? JobGroupId { get; set; }

    public int? MethodApplyId { get; set; }

    public virtual Ad? Ads { get; set; }

    public virtual ICollection<EmploymentApplication> EmploymentApplications { get; set; } = new List<EmploymentApplication>();

    public virtual Gender? Gender { get; set; }

    public virtual JobGroup? JobGroup { get; set; }

    public virtual JobInfo? JobInfo { get; set; }

    public virtual JobStatus? JobStatus { get; set; }

    public virtual MethodApplyJop? MethodApply { get; set; }
}
