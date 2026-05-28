using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class ProjectTaskAssignee
{
    public long Id { get; set; }

    public long ProjectTaskId { get; set; }

    public long EmployeeId { get; set; }

    public DateTime AssignedAt { get; set; }

    public DateTime? UnassignedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ProjectTask ProjectTask { get; set; } = null!;
}
