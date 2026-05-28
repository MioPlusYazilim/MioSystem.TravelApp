using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class ProjectTask
{
    public long Id { get; set; }

    public long TaskNoSequence { get; set; }

    public string? TaskNo { get; set; }

    public long ProjectId { get; set; }

    public long? ProjectStageId { get; set; }

    public long? ParentTaskId { get; set; }

    public int StatusId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public long? AssignedEmployeeId { get; set; }

    public int Priority { get; set; }

    public DateTime? PlannedStartAt { get; set; }

    public DateTime? PlannedEndAt { get; set; }

    public DateTime? ActualStartAt { get; set; }

    public DateTime? ActualEndAt { get; set; }

    public decimal WeightPercent { get; set; }

    public decimal ProgressPercent { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? AssignedEmployee { get; set; }

    public virtual ICollection<ProjectTask> InverseParentTask { get; set; } = new List<ProjectTask>();

    public virtual ProjectTask? ParentTask { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<ProjectProgressLog> ProjectProgressLogs { get; set; } = new List<ProjectProgressLog>();

    public virtual ProjectStage? ProjectStage { get; set; }

    public virtual ICollection<ProjectTaskAssignee> ProjectTaskAssignees { get; set; } = new List<ProjectTaskAssignee>();

    public virtual SysLookupItem Status { get; set; } = null!;
}
