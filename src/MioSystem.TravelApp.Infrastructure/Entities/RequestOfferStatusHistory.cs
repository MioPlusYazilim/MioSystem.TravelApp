using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class RequestOfferStatusHistory
{
    public long Id { get; set; }

    public long RequestOfferId { get; set; }

    public int? OldStatusId { get; set; }

    public int NewStatusId { get; set; }

    public long? ChangedByEmployeeId { get; set; }

    public DateTime ChangedAt { get; set; }

    public string? Note { get; set; }

    public virtual Employee? ChangedByEmployee { get; set; }

    public virtual SysLookupItem NewStatus { get; set; } = null!;

    public virtual SysLookupItem? OldStatus { get; set; }

    public virtual RequestOffer RequestOffer { get; set; } = null!;
}
