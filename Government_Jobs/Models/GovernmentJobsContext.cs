using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Government_Jobs.Models;

public partial class GovernmentJobsContext : DbContext
{
    public GovernmentJobsContext()
    {
    }

    public GovernmentJobsContext(DbContextOptions<GovernmentJobsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ad> Ads { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AdsDocument> AdsDocuments { get; set; }

    public virtual DbSet<AdsStatus> AdsStatuses { get; set; }

    public virtual DbSet<AdsType> AdsTypes { get; set; }

    public virtual DbSet<CategoryReqAd> CategoryReqAds { get; set; }

    public virtual DbSet<ComputerSkill> ComputerSkills { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<CopNationalId> CopNationalIds { get; set; }

    public virtual DbSet<CriminalRecord> CriminalRecords { get; set; }

    public virtual DbSet<DegreeProficiency> DegreeProficiencies { get; set; }

    public virtual DbSet<DisabilitiesType> DisabilitiesTypes { get; set; }

    public virtual DbSet<EmploymentApplication> EmploymentApplications { get; set; }

    public virtual DbSet<Evaluation> Evaluations { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Government> Governments { get; set; }

    public virtual DbSet<GovernmentCategory> GovernmentCategories { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Grievance> Grievances { get; set; }

    public virtual DbSet<GrievancesDetail> GrievancesDetails { get; set; }

    public virtual DbSet<GrievancesResult> GrievancesResults { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobAppStatus> JobAppStatuses { get; set; }

    public virtual DbSet<JobDetailsOffer> JobDetailsOffers { get; set; }

    public virtual DbSet<JobDevelopmentProposal> JobDevelopmentProposals { get; set; }

    public virtual DbSet<JobDocument> JobDocuments { get; set; }

    public virtual DbSet<JobGroup> JobGroups { get; set; }

    public virtual DbSet<JobInfo> JobInfos { get; set; }

    public virtual DbSet<JobStatus> JobStatuses { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LastExperience> LastExperiences { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<MethodApplyJop> MethodApplyJops { get; set; }

    public virtual DbSet<MobileNum> MobileNums { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<QualificationLevel> QualificationLevels { get; set; }

    public virtual DbSet<QualitativeGroup> QualitativeGroups { get; set; }

    public virtual DbSet<ReasonsRejectingApp> ReasonsRejectingApps { get; set; }

    public virtual DbSet<SkillName> SkillNames { get; set; }

    public virtual DbSet<SkillType> SkillTypes { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }

    public virtual DbSet<TrainingType> TrainingTypes { get; set; }

    public virtual DbSet<TypesUserTemplate> TypesUserTemplates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AN4KT9C;Database=Government_jobs;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ad>(entity =>
        {
            entity.Property(e => e.AdsDocumentsId).HasColumnName("ads_documents_Id");
            entity.Property(e => e.AdsMinisttry).HasColumnName("Ads_ministtry");
            entity.Property(e => e.AdsStatusId).HasColumnName("ads_status_Id");
            entity.Property(e => e.AdsTypeId).HasColumnName("ads_type_Id");
            entity.Property(e => e.CaoaHelp).HasColumnName("caoa_help");
            entity.Property(e => e.ContactId).HasColumnName("contact_Id");
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.ExtendAdsPeriod)
                .HasColumnType("datetime")
                .HasColumnName("Extend_ads_period");
            entity.Property(e => e.GovernmentCategoryId).HasColumnName("government_category_Id");
            entity.Property(e => e.ImportantNotes).HasColumnName("Important_notes");
            entity.Property(e => e.IsCentralAdd).HasColumnName("is_central_add");
            entity.Property(e => e.Isopend).HasColumnName("isopend");
            entity.Property(e => e.LinkDetails).HasColumnName("link_details");
            entity.Property(e => e.LogoImg).HasColumnName("logo_img");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.RefuseNote).HasColumnName("refuse_note");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateNote).HasColumnName("update_note");

            entity.HasOne(d => d.AdsDocuments).WithMany(p => p.Ads)
                .HasForeignKey(d => d.AdsDocumentsId)
                .HasConstraintName("FK_Ads_Ads_Documents");

            entity.HasOne(d => d.AdsStatus).WithMany(p => p.Ads)
                .HasForeignKey(d => d.AdsStatusId)
                .HasConstraintName("FK_Ads_Ads_status");

            entity.HasOne(d => d.AdsType).WithMany(p => p.Ads)
                .HasForeignKey(d => d.AdsTypeId)
                .HasConstraintName("FK_Ads_Ads_Type");

            entity.HasOne(d => d.Contact).WithMany(p => p.Ads)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Ads_Contact");

            entity.HasOne(d => d.GovernmentCategory).WithMany(p => p.Ads)
                .HasForeignKey(d => d.GovernmentCategoryId)
                .HasConstraintName("FK_Ads_Government_categories");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Street).HasColumnName("street");
            entity.Property(e => e.UnitNum).HasColumnName("unit_num");
            entity.Property(e => e.UserId).HasColumnName("user_Id");
        });

        modelBuilder.Entity<AdsDocument>(entity =>
        {
            entity.ToTable("Ads_Documents");
        });

        modelBuilder.Entity<AdsStatus>(entity =>
        {
            entity.ToTable("Ads_status");

            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<AdsType>(entity =>
        {
            entity.ToTable("Ads_Type");

            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<CategoryReqAd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Category_req_add");

            entity.ToTable("Category_req_ads");

            entity.Property(e => e.GovernmentCategoryId).HasColumnName("government_category_Id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.GovernmentCategory).WithMany(p => p.CategoryReqAds)
                .HasForeignKey(d => d.GovernmentCategoryId)
                .HasConstraintName("FK_Category_req_ads_Government_categories");
        });

        modelBuilder.Entity<ComputerSkill>(entity =>
        {
            entity.ToTable("Computer_skills");

            entity.Property(e => e.EmploymentAppId).HasColumnName("employment_app_Id");
            entity.Property(e => e.EvaluationId).HasColumnName("evaluation_Id");
            entity.Property(e => e.SkillNameId).HasColumnName("skill_name_Id");
            entity.Property(e => e.SkillTypeId).HasColumnName("skill_type_Id");

            entity.HasOne(d => d.EmploymentApp).WithMany(p => p.ComputerSkills)
                .HasForeignKey(d => d.EmploymentAppId)
                .HasConstraintName("FK_Computer_skills_Employment_application");

            entity.HasOne(d => d.Evaluation).WithMany(p => p.ComputerSkills)
                .HasForeignKey(d => d.EvaluationId)
                .HasConstraintName("FK_Computer_skills_Evaluation");

            entity.HasOne(d => d.SkillName).WithMany(p => p.ComputerSkills)
                .HasForeignKey(d => d.SkillNameId)
                .HasConstraintName("FK_Computer_skills_skill_name");

            entity.HasOne(d => d.SkillType).WithMany(p => p.ComputerSkills)
                .HasForeignKey(d => d.SkillTypeId)
                .HasConstraintName("FK_Computer_skills_skill_type");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Contuct");

            entity.ToTable("Contact");
        });

        modelBuilder.Entity<CopNationalId>(entity =>
        {
            entity.ToTable("cop_national_id");

            entity.Property(e => e.NationalBackImg).HasColumnName("national_backImg");
            entity.Property(e => e.NationalFrontImg).HasColumnName("national_frontImg");
            entity.Property(e => e.NationalId).HasColumnName("national_Id");
            entity.Property(e => e.UserId).HasColumnName("user_Id");

            entity.HasOne(d => d.User).WithMany(p => p.CopNationalIds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_cop_national_id_User");
        });

        modelBuilder.Entity<CriminalRecord>(entity =>
        {
            entity.ToTable("Criminal_record");

            entity.Property(e => e.CriminalRecord1).HasColumnName("criminal_record");
            entity.Property(e => e.UserId).HasColumnName("user_Id");

            entity.HasOne(d => d.User).WithMany(p => p.CriminalRecords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Criminal_record_User");
        });

        modelBuilder.Entity<DegreeProficiency>(entity =>
        {
            entity.ToTable("Degree_proficiency");
        });

        modelBuilder.Entity<DisabilitiesType>(entity =>
        {
            entity.ToTable("Disabilities_Types");
        });

        modelBuilder.Entity<EmploymentApplication>(entity =>
        {
            entity.ToTable("Employment_application");

            entity.Property(e => e.ExtendResultDate)
                .HasColumnType("datetime")
                .HasColumnName("extend_result_date");
            entity.Property(e => e.GradeId).HasColumnName("grade_Id");
            entity.Property(e => e.GrievancesId).HasColumnName("grievances_Id");
            entity.Property(e => e.JobAppStatusId).HasColumnName("job_app_status_Id");
            entity.Property(e => e.JobDetailOfferId).HasColumnName("job_detail_offer_Id");
            entity.Property(e => e.JobId).HasColumnName("job_Id");
            entity.Property(e => e.JopDevPropId).HasColumnName("jop_dev_prop_Id");
            entity.Property(e => e.QualificationLevelId).HasColumnName("qualification_level_Id");
            entity.Property(e => e.ReasonsRejectId).HasColumnName("reasons_reject_Id");
            entity.Property(e => e.RequestNum).HasColumnName("request_num");
            entity.Property(e => e.ResultDate)
                .HasColumnType("datetime")
                .HasColumnName("result_date");
            entity.Property(e => e.UserId).HasColumnName("user_Id");

            entity.HasOne(d => d.Grade).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_Employment_application_Grade");

            entity.HasOne(d => d.Grievances).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.GrievancesId)
                .HasConstraintName("FK_Employment_application_Grievances");

            entity.HasOne(d => d.JobAppStatus).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.JobAppStatusId)
                .HasConstraintName("FK_Employment_application_Job_app_status");

            entity.HasOne(d => d.JobDetailOffer).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.JobDetailOfferId)
                .HasConstraintName("FK_Employment_application_Job_Details_Offer");

            entity.HasOne(d => d.Job).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Employment_application_Jobs");

            entity.HasOne(d => d.JopDevProp).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.JopDevPropId)
                .HasConstraintName("FK_Employment_application_Job_development_proposal");

            entity.HasOne(d => d.QualificationLevel).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.QualificationLevelId)
                .HasConstraintName("FK_Employment_application_Qualification_level");

            entity.HasOne(d => d.ReasonsReject).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.ReasonsRejectId)
                .HasConstraintName("FK_Employment_application_Reasons_rejecting_app");

            entity.HasOne(d => d.User).WithMany(p => p.EmploymentApplications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Employment_application_User");
        });

        modelBuilder.Entity<Evaluation>(entity =>
        {
            entity.ToTable("Evaluation");

            entity.Property(e => e.Evaluation1).HasColumnName("evaluation");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User_Type");

            entity.ToTable("Gender");
        });

        modelBuilder.Entity<Government>(entity =>
        {
            entity.ToTable("Government");

            entity.Property(e => e.Government1).HasColumnName("government");
        });

        modelBuilder.Entity<GovernmentCategory>(entity =>
        {
            entity.ToTable("Government_categories");

            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("Grade");

            entity.Property(e => e.Grade1).HasColumnName("grade");
        });

        modelBuilder.Entity<Grievance>(entity =>
        {
            entity.Property(e => e.EndGrievances)
                .HasColumnType("datetime")
                .HasColumnName("end_grievances");
            entity.Property(e => e.ExtendGrievance)
                .HasColumnType("datetime")
                .HasColumnName("extend_grievance");
            entity.Property(e => e.GrievanceDetailsId).HasColumnName("grievance_details_Id");
            entity.Property(e => e.GrievanceInquiry).HasColumnName("grievance_inquiry");
            entity.Property(e => e.GrievanceResultId).HasColumnName("grievance_result_Id");
            entity.Property(e => e.StartGrievances)
                .HasColumnType("datetime")
                .HasColumnName("start_grievances");

            entity.HasOne(d => d.GrievanceDetails).WithMany(p => p.Grievances)
                .HasForeignKey(d => d.GrievanceDetailsId)
                .HasConstraintName("FK_Grievances_Grievances_Details");

            entity.HasOne(d => d.GrievanceResult).WithMany(p => p.Grievances)
                .HasForeignKey(d => d.GrievanceResultId)
                .HasConstraintName("FK_Grievances_Grievances_Result");
        });

        modelBuilder.Entity<GrievancesDetail>(entity =>
        {
            entity.ToTable("Grievances_Details");

            entity.Property(e => e.GovernmentId).HasColumnName("government_Id");
            entity.Property(e => e.RejectionReason).HasColumnName("rejection_reason");
            entity.Property(e => e.TestDate)
                .HasColumnType("datetime")
                .HasColumnName("test_date");
            entity.Property(e => e.TestPlace).HasColumnName("test_place");

            entity.HasOne(d => d.Government).WithMany(p => p.GrievancesDetails)
                .HasForeignKey(d => d.GovernmentId)
                .HasConstraintName("FK_Grievances_Details_Government");
        });

        modelBuilder.Entity<GrievancesResult>(entity =>
        {
            entity.ToTable("Grievances_Result");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(e => e.AdsId).HasColumnName("ads_Id");
            entity.Property(e => e.AppLink).HasColumnName("app_link");
            entity.Property(e => e.ApplicationConditions).HasColumnName("application_conditions");
            entity.Property(e => e.ApplyDate).HasColumnName("apply_date");
            entity.Property(e => e.ArtisticSkills).HasColumnName("artistic_skills");
            entity.Property(e => e.BasicSkills).HasColumnName("basic_skills");
            entity.Property(e => e.CloseInquery)
                .HasColumnType("datetime")
                .HasColumnName("close_inquery");
            entity.Property(e => e.ContactDetails).HasColumnName("contact_details");
            entity.Property(e => e.EducationLevel).HasColumnName("education_level");
            entity.Property(e => e.ExpYears).HasColumnName("exp_years");
            entity.Property(e => e.GenderId).HasColumnName("gender_Id");
            entity.Property(e => e.GrievancesId).HasColumnName("grievances_Id");
            entity.Property(e => e.InqueryDate)
                .HasColumnType("datetime")
                .HasColumnName("inquery_date");
            entity.Property(e => e.InterviewDate)
                .HasColumnType("datetime")
                .HasColumnName("interview_date");
            entity.Property(e => e.InterviewEnddate)
                .HasColumnType("datetime")
                .HasColumnName("interview_enddate");
            entity.Property(e => e.InterviewStartdate)
                .HasColumnType("datetime")
                .HasColumnName("interview_startdate");
            entity.Property(e => e.IsDistributed).HasColumnName("is_distributed");
            entity.Property(e => e.IsSpecialNeedAccept).HasColumnName("is_special_need_accept");
            entity.Property(e => e.JobCode).HasColumnName("job_code");
            entity.Property(e => e.JobDesc).HasColumnName("job_desc");
            entity.Property(e => e.JobGoal).HasColumnName("job_goal");
            entity.Property(e => e.JobGroupId).HasColumnName("job_group_Id");
            entity.Property(e => e.JobInfoId).HasColumnName("job_info_Id");
            entity.Property(e => e.JobLevel).HasColumnName("job_level");
            entity.Property(e => e.JobLocation).HasColumnName("job_location");
            entity.Property(e => e.JobName).HasColumnName("job_name");
            entity.Property(e => e.JobPath).HasColumnName("job_path");
            entity.Property(e => e.JobStatusId).HasColumnName("job_status_Id");
            entity.Property(e => e.MaxAge).HasColumnName("max_age");
            entity.Property(e => e.MethodApplyId).HasColumnName("method_apply_Id");
            entity.Property(e => e.MinGrade).HasColumnName("min_grade");
            entity.Property(e => e.NumOfApplicant)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("num_of_Applicant");
            entity.Property(e => e.QualificationReq).HasColumnName("qualification_req");
            entity.Property(e => e.SubmitInfo).HasColumnName("submit_info");

            entity.HasOne(d => d.Ads).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.AdsId)
                .HasConstraintName("FK_Jobs_Ads");

            entity.HasOne(d => d.Gender).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Jobs_Gender");

            entity.HasOne(d => d.JobGroup).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobGroupId)
                .HasConstraintName("FK_Jobs_Job_group");

            entity.HasOne(d => d.JobInfo).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobInfoId)
                .HasConstraintName("FK_Jobs_job_info");

            entity.HasOne(d => d.JobStatus).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobStatusId)
                .HasConstraintName("FK_Jobs_Job_status");

            entity.HasOne(d => d.MethodApply).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.MethodApplyId)
                .HasConstraintName("FK_Jobs_Method_Apply_Jop");
        });

        modelBuilder.Entity<JobAppStatus>(entity =>
        {
            entity.ToTable("Job_app_status");

            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<JobDetailsOffer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Jop_Details_Offer");

            entity.ToTable("Job_Details_Offer");

            entity.Property(e => e.GovernmentId).HasColumnName("government_Id");
            entity.Property(e => e.RejectionReason).HasColumnName("rejection_reason");
            entity.Property(e => e.TestDate)
                .HasColumnType("datetime")
                .HasColumnName("test_date");
            entity.Property(e => e.TestPlace).HasColumnName("test_place");

            entity.HasOne(d => d.Government).WithMany(p => p.JobDetailsOffers)
                .HasForeignKey(d => d.GovernmentId)
                .HasConstraintName("FK_Job_Details_Offer_Government");
        });

        modelBuilder.Entity<JobDevelopmentProposal>(entity =>
        {
            entity.ToTable("Job_development_proposal");

            entity.Property(e => e.Achivements).HasColumnName("achivements");
            entity.Property(e => e.DevelopmentProposal).HasColumnName("development_proposal");
            entity.Property(e => e.DurationImplementation).HasColumnName("Duration_implementation");
            entity.Property(e => e.ExpectedReturn).HasColumnName("Expected_return");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ProposalGoals).HasColumnName("proposal_goals");
            entity.Property(e => e.ProposalImportance).HasColumnName("proposal_importance");
            entity.Property(e => e.ReqImplementProposal).HasColumnName("Req_implement_proposal");
        });

        modelBuilder.Entity<JobDocument>(entity =>
        {
            entity.ToTable("Job_documents");

            entity.Property(e => e.AchievementsFile).HasColumnName("achievements_file");
            entity.Property(e => e.CareerDevelopment).HasColumnName("career_development");
            entity.Property(e => e.Certificate).HasColumnName("certificate");
            entity.Property(e => e.CriminalRecordId).HasColumnName("criminal_record_Id");
            entity.Property(e => e.EmploymentAppId).HasColumnName("employment_app_Id");
            entity.Property(e => e.JobProposal).HasColumnName("job_proposal");
            entity.Property(e => e.JobStatusStatement).HasColumnName("job_status_statement");
            entity.Property(e => e.NationalId).HasColumnName("national_Id");
            entity.Property(e => e.PersonalImg).HasColumnName("personal_img");
            entity.Property(e => e.Statement).HasColumnName("statement");
            entity.Property(e => e.StatementOfEmploymentStatus).HasColumnName("statement_of_employment_status");
            entity.Property(e => e.TrainingCertificates).HasColumnName("training_certificates");

            entity.HasOne(d => d.CriminalRecord).WithMany(p => p.JobDocuments)
                .HasForeignKey(d => d.CriminalRecordId)
                .HasConstraintName("FK_Job_documents_Criminal_record");

            entity.HasOne(d => d.EmploymentApp).WithMany(p => p.JobDocuments)
                .HasForeignKey(d => d.EmploymentAppId)
                .HasConstraintName("FK_Job_documents_Employment_application");

            entity.HasOne(d => d.National).WithMany(p => p.JobDocuments)
                .HasForeignKey(d => d.NationalId)
                .HasConstraintName("FK_Job_documents_cop_national_id");
        });

        modelBuilder.Entity<JobGroup>(entity =>
        {
            entity.ToTable("Job_group");

            entity.Property(e => e.JobGroup1).HasColumnName("job_group");
        });

        modelBuilder.Entity<JobInfo>(entity =>
        {
            entity.ToTable("job_info");

            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsSaved).HasColumnName("is_saved");
            entity.Property(e => e.Isarchived).HasColumnName("isarchived");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<JobStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_jop_status");

            entity.ToTable("Job_status");

            entity.Property(e => e.JopStatus).HasColumnName("jop_status");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.Property(e => e.DegreeProficiencyId).HasColumnName("Degree_proficiency_Id");
            entity.Property(e => e.EmploymentAppId).HasColumnName("employment_app_Id");
            entity.Property(e => e.Language1).HasColumnName("Language");

            entity.HasOne(d => d.DegreeProficiency).WithMany(p => p.Languages)
                .HasForeignKey(d => d.DegreeProficiencyId)
                .HasConstraintName("FK_Language_Degree_proficiency");

            entity.HasOne(d => d.EmploymentApp).WithMany(p => p.Languages)
                .HasForeignKey(d => d.EmploymentAppId)
                .HasConstraintName("FK_Language_Employment_application");
        });

        modelBuilder.Entity<LastExperience>(entity =>
        {
            entity.ToTable("Last_experience");

            entity.Property(e => e.CompanyName).HasColumnName("company_name");
            entity.Property(e => e.EmploymentAppId).HasColumnName("employment_app_Id");
            entity.Property(e => e.From)
                .HasColumnType("datetime")
                .HasColumnName("from");
            entity.Property(e => e.GovernmentalCategoryId).HasColumnName("governmental_category_Id");
            entity.Property(e => e.LastExperienceJob).HasColumnName("last_experience_job");
            entity.Property(e => e.To)
                .HasColumnType("datetime")
                .HasColumnName("to");

            entity.HasOne(d => d.EmploymentApp).WithMany(p => p.LastExperiences)
                .HasForeignKey(d => d.EmploymentAppId)
                .HasConstraintName("FK_Last_experience_Employment_application");

            entity.HasOne(d => d.GovernmentalCategory).WithMany(p => p.LastExperiences)
                .HasForeignKey(d => d.GovernmentalCategoryId)
                .HasConstraintName("FK_Last_experience_Government_categories");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.Property(e => e.Media).HasColumnName("media");
            entity.Property(e => e.NewsId).HasColumnName("news_Id");

            entity.HasOne(d => d.News).WithMany(p => p.Media)
                .HasForeignKey(d => d.NewsId)
                .HasConstraintName("FK_Media_News");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.Message1).HasColumnName("message");
            entity.Property(e => e.UserId).HasColumnName("user_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Messages_User");
        });

        modelBuilder.Entity<MethodApplyJop>(entity =>
        {
            entity.ToTable("Method_Apply_Jop");
        });

        modelBuilder.Entity<MobileNum>(entity =>
        {
            entity.ToTable("Mobile_nums");

            entity.Property(e => e.Mobile1).HasColumnName("mobile1");
            entity.Property(e => e.Mobile2).HasColumnName("mobile2");
            entity.Property(e => e.Mobile3).HasColumnName("mobile3");
            entity.Property(e => e.UserId).HasColumnName("user_Id");

            entity.HasOne(d => d.User).WithMany(p => p.MobileNums)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Mobile_nums_User");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdsId).HasColumnName("ads_Id");
            entity.Property(e => e.InstructionsApplicants).HasColumnName("Instructions_applicants");
            entity.Property(e => e.LatestNews).HasColumnName("Latest_news");
            entity.Property(e => e.Video).HasColumnName("video");

            entity.HasOne(d => d.Ads).WithMany(p => p.News)
                .HasForeignKey(d => d.AdsId)
                .HasConstraintName("FK_News_Ads");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.PaymentMoney)
                .HasColumnType("decimal(18, 1)")
                .HasColumnName("payment_money");
            entity.Property(e => e.ReferenceNum).HasColumnName("reference_num");
            entity.Property(e => e.UserId).HasColumnName("user_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Payment_User");
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.ToTable("Qualification");

            entity.Property(e => e.GradeId).HasColumnName("grade_Id");
            entity.Property(e => e.GraduationYear).HasColumnName("graduation_year");
            entity.Property(e => e.Persentage)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("persentage");
            entity.Property(e => e.Qualification1).HasColumnName("qualification");
            entity.Property(e => e.QualificationLevelId).HasColumnName("qualification_level_Id");

            entity.HasOne(d => d.Grade).WithMany(p => p.Qualifications)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_Qualification_Grade");

            entity.HasOne(d => d.QualificationLevel).WithMany(p => p.Qualifications)
                .HasForeignKey(d => d.QualificationLevelId)
                .HasConstraintName("FK_Qualification_Qualification_level");
        });

        modelBuilder.Entity<QualificationLevel>(entity =>
        {
            entity.ToTable("Qualification_level");

            entity.Property(e => e.QualificationLevel1).HasColumnName("qualification_level");
        });

        modelBuilder.Entity<QualitativeGroup>(entity =>
        {
            entity.ToTable("Qualitative_group");

            entity.Property(e => e.JobGroupId).HasColumnName("job_group_Id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.JobGroup).WithMany(p => p.QualitativeGroups)
                .HasForeignKey(d => d.JobGroupId)
                .HasConstraintName("FK_Qualitative_group_Job_group");
        });

        modelBuilder.Entity<ReasonsRejectingApp>(entity =>
        {
            entity.ToTable("Reasons_rejecting_app");
        });

        modelBuilder.Entity<SkillName>(entity =>
        {
            entity.ToTable("skill_name");

            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<SkillType>(entity =>
        {
            entity.ToTable("skill_type");

            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.ToTable("Specialization");

            entity.Property(e => e.QualificationId).HasColumnName("qualification_Id");
            entity.Property(e => e.Specialization1).HasColumnName("specialization");

            entity.HasOne(d => d.Qualification).WithMany(p => p.Specializations)
                .HasForeignKey(d => d.QualificationId)
                .HasConstraintName("FK_Specialization_Qualification");
        });

        modelBuilder.Entity<TrainingProgram>(entity =>
        {
            entity.ToTable("Training_programs");

            entity.Property(e => e.EmploymentAppId).HasColumnName("employment_app_Id");
            entity.Property(e => e.From)
                .HasColumnType("datetime")
                .HasColumnName("from");
            entity.Property(e => e.To)
                .HasColumnType("datetime")
                .HasColumnName("to");
            entity.Property(e => e.TrainingName).HasColumnName("training_name");
            entity.Property(e => e.TrainingPlace).HasColumnName("training_place");
            entity.Property(e => e.TrainingTypeId).HasColumnName("training_type_Id");

            entity.HasOne(d => d.EmploymentApp).WithMany(p => p.TrainingPrograms)
                .HasForeignKey(d => d.EmploymentAppId)
                .HasConstraintName("FK_Training_programs_Employment_application");
        });

        modelBuilder.Entity<TrainingType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Training_type");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.TrainingType1).HasColumnName("training_type");

            entity.HasOne(d => d.IdNavigation).WithMany()
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Training_type_Training_programs");
        });

        modelBuilder.Entity<TypesUserTemplate>(entity =>
        {
            entity.ToTable("Types_user_templates");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.DisabilityTypeId).HasColumnName("disability_type_Id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.GenderId).HasColumnName("gender_Id");
            entity.Property(e => e.GovernateId).HasColumnName("governate_Id");
            entity.Property(e => e.NumNationalId).HasColumnName("num_national_id");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.UserTypeId).HasColumnName("user_type_Id");

            entity.HasOne(d => d.Address).WithMany(p => p.Users)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_User_Address");

            entity.HasOne(d => d.DisabilityType).WithMany(p => p.Users)
                .HasForeignKey(d => d.DisabilityTypeId)
                .HasConstraintName("FK_User_Disabilities_Types");

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_User_Gender");

            entity.HasOne(d => d.Governate).WithMany(p => p.Users)
                .HasForeignKey(d => d.GovernateId)
                .HasConstraintName("FK_User_Government");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK_User_User_Type");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User_Type_1");

            entity.ToTable("User_Type");

            entity.Property(e => e.UserType1).HasColumnName("user_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
