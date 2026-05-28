using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class RequestNote
{
    public long Id { get; set; }

    public long RequestId { get; set; }

    public long? EmployeeId { get; set; }

    public string? NoteTypeCode { get; set; }

    public string NoteText { get; set; } = null!;

    public bool IsInternal { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Request Request { get; set; } = null!;
}
