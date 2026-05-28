using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class ProjectStage
{
    public long Id { get; set; }

    public long ProjectId { get; set; }

    public int StatusId { get; set; }

    public string StageName { get; set; } = null!;

    public string? Description { get; set; }

    public int SortOrder { get; set; }

    public DateOnly? PlannedStartDate { get; set; }

    public DateOnly? PlannedEndDate { get; set; }

    public DateOnly? ActualStartDate { get; set; }

    public DateOnly? ActualEndDate { get; set; }

    public decimal WeightPercent { get; set; }

    public decimal ProgressPercent { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<ProjectProgressLog> ProjectProgressLogs { get; set; } = new List<ProjectProgressLog>();

    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    public virtual SysLookupItem Status { get; set; } = null!;
}
