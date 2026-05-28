using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VwProjectList
{
    public long Id { get; set; }

    public string? ProjectNo { get; set; }

    public string ProjectName { get; set; } = null!;

    public long CustomerId { get; set; }

    public string CustomerTitle { get; set; } = null!;

    public int StatusId { get; set; }

    public string StatusCode { get; set; } = null!;

    public string StatusResourceKey { get; set; } = null!;

    public decimal ProgressPercent { get; set; }

    public DateOnly? PlannedStartDate { get; set; }

    public DateOnly? PlannedEndDate { get; set; }

    public DateOnly? ActualStartDate { get; set; }

    public DateOnly? ActualEndDate { get; set; }

    public long? SourceTransactionId { get; set; }

    public string? TransactionNo { get; set; }

    public int? TaskCount { get; set; }

    public int? CompletedTaskCount { get; set; }
}
