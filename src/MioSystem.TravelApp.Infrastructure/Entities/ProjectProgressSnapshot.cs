using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class ProjectProgressSnapshot
{
    public long Id { get; set; }

    public long ProjectId { get; set; }

    public DateTime SnapshotAt { get; set; }

    public decimal ProgressPercent { get; set; }

    public int CompletedTaskCount { get; set; }

    public int TotalTaskCount { get; set; }

    public string? Note { get; set; }

    public virtual Project Project { get; set; } = null!;
}
