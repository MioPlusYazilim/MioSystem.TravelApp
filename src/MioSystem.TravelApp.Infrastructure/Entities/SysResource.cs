using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class SysResource
{
    public long Id { get; set; }

    public string ResourceKey { get; set; } = null!;

    public string ResourceType { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsSystem { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<SysResourceTranslation> SysResourceTranslations { get; set; } = new List<SysResourceTranslation>();
}
