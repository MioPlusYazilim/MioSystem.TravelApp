using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class ProjectProgressLog
{
    public long Id { get; set; }

    public long ProjectId { get; set; }

    public long? ProjectStageId { get; set; }

    public long? ProjectTaskId { get; set; }

    public decimal? OldProgressPercent { get; set; }

    public decimal NewProgressPercent { get; set; }

    public long? ChangedByEmployeeId { get; set; }

    public DateTime ChangedAt { get; set; }

    public string? Note { get; set; }

    public virtual Employee? ChangedByEmployee { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectStage? ProjectStage { get; set; }

    public virtual ProjectTask? ProjectTask { get; set; }
}
