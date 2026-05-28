using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class SysResourceTranslation
{
    public long Id { get; set; }

    public long ResourceId { get; set; }

    public int LanguageId { get; set; }

    public string Value { get; set; } = null!;

    public bool IsApproved { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual SysLanguage Language { get; set; } = null!;

    public virtual SysResource Resource { get; set; } = null!;
}
