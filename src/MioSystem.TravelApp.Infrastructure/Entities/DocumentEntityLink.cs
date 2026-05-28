using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class DocumentEntityLink
{
    public long Id { get; set; }

    public long DocumentId { get; set; }

    public long? DocumentVersionId { get; set; }

    public int EntityTypeId { get; set; }

    public long EntityId { get; set; }

    public int LinkRoleId { get; set; }

    public bool IsPrimary { get; set; }

    public bool IsActive { get; set; }

    public string? Note { get; set; }

    public long? CreatedByEmployeeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? CreatedByEmployee { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual DocumentVersion? DocumentVersion { get; set; }

    public virtual SysLookupItem EntityType { get; set; } = null!;

    public virtual SysLookupItem LinkRole { get; set; } = null!;
}
