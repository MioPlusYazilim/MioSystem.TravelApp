using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class Project
{
    public long Id { get; set; }

    public long ProjectNoSequence { get; set; }

    public string? ProjectNo { get; set; }

    public long? SourceTransactionId { get; set; }

    public long? SourceRequestId { get; set; }

    public long? SourceOfferId { get; set; }

    public long CustomerId { get; set; }

    public long? CustomerContactId { get; set; }

    public long? CustomerContactEmploymentId { get; set; }

    public int StatusId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? PlannedStartDate { get; set; }

    public DateOnly? PlannedEndDate { get; set; }

    public DateOnly? ActualStartDate { get; set; }

    public DateOnly? ActualEndDate { get; set; }

    public decimal ProgressPercent { get; set; }

    public long? CreatedByEmployeeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BillingPlan> BillingPlans { get; set; } = new List<BillingPlan>();

    public virtual Employee? CreatedByEmployee { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomerContact? CustomerContact { get; set; }

    public virtual CustomerContactEmployment? CustomerContactEmployment { get; set; }

    public virtual ICollection<ProjectProgressLog> ProjectProgressLogs { get; set; } = new List<ProjectProgressLog>();

    public virtual ICollection<ProjectProgressSnapshot> ProjectProgressSnapshots { get; set; } = new List<ProjectProgressSnapshot>();

    public virtual ICollection<ProjectStage> ProjectStages { get; set; } = new List<ProjectStage>();

    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    public virtual RequestOffer? SourceOffer { get; set; }

    public virtual Request? SourceRequest { get; set; }

    public virtual TransactionMaster? SourceTransaction { get; set; }

    public virtual SysLookupItem Status { get; set; } = null!;
}
