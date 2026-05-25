using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Data.Entities;

public partial class SysLanguage
{
    public int ID { get; set; }

    public string Code { get; set; } = null!;

    public string ShortCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? CultureName { get; set; }

    public int SortOrder { get; set; }

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
