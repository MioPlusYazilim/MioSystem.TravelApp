using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class SysLanguage
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string ShortCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? CultureName { get; set; }

    public int SortOrder { get; set; }

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<SysResourceTranslation> SysResourceTranslations { get; set; } = new List<SysResourceTranslation>();
}
