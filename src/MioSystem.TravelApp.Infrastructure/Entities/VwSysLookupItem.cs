using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VwSysLookupItem
{
    public int Id { get; set; }

    public string GroupCode { get; set; } = null!;

    public string ItemCode { get; set; } = null!;

    public string? Value { get; set; }

    public string ResourceKey { get; set; } = null!;

    public int SortOrder { get; set; }

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; }
}
