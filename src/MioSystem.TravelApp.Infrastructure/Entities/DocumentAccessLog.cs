using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class DocumentAccessLog
{
    public long Id { get; set; }

    public long DocumentId { get; set; }

    public long? DocumentVersionId { get; set; }

    public int ActionId { get; set; }

    public long? EmployeeId { get; set; }

    public DateTime AccessedAt { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public bool Succeeded { get; set; }

    public string? Note { get; set; }

    public virtual SysLookupItem Action { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;

    public virtual DocumentVersion? DocumentVersion { get; set; }

    public virtual Employee? Employee { get; set; }
}
