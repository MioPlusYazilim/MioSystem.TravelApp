using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class SysLookupGroup
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? ResourceKey { get; set; }

    public string? Description { get; set; }

    public int SortOrder { get; set; }

    public bool IsSystem { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<SysLookupItem> SysLookupItems { get; set; } = new List<SysLookupItem>();
}
