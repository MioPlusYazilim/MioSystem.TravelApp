using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class RequestAssignment
{
    public long Id { get; set; }

    public long RequestId { get; set; }

    public long EmployeeId { get; set; }

    public long? AssignedByEmployeeId { get; set; }

    public DateTime AssignedAt { get; set; }

    public DateTime? UnassignedAt { get; set; }

    public bool IsActive { get; set; }

    public string? Note { get; set; }

    public virtual Employee? AssignedByEmployee { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
