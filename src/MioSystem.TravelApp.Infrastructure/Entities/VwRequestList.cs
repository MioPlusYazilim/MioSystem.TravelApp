using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VwRequestList
{
    public long Id { get; set; }

    public string? RequestNo { get; set; }

    public long CustomerId { get; set; }

    public string CustomerTitle { get; set; } = null!;

    public long? CustomerContactId { get; set; }

    public string? CustomerContactName { get; set; }

    public long? CompanyId { get; set; }

    public string? CompanyTitle { get; set; }

    public int ChannelId { get; set; }

    public string ChannelCode { get; set; } = null!;

    public string ChannelResourceKey { get; set; } = null!;

    public int RequestTypeId { get; set; }

    public string RequestTypeCode { get; set; } = null!;

    public string RequestTypeResourceKey { get; set; } = null!;

    public int StatusId { get; set; }

    public string StatusCode { get; set; } = null!;

    public string StatusResourceKey { get; set; } = null!;

    public long? AssignedEmployeeId { get; set; }

    public string? AssignedEmployeeName { get; set; }

    public string Subject { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
}
