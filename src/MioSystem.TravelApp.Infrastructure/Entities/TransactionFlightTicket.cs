using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class TransactionFlightTicket
{
    public long Id { get; set; }

    public long TransactionId { get; set; }

    public long? TransactionLineId { get; set; }

    public string PassengerName { get; set; } = null!;

    public int? PassengerTypeId { get; set; }

    public int? TicketDocumentTypeId { get; set; }

    public string? Pnr { get; set; }

    public string? TicketNumber { get; set; }

    public string? AirlineCode { get; set; }

    public string? RouteText { get; set; }

    public DateTime? DepartureAt { get; set; }

    public DateTime? ReturnAt { get; set; }

    public DateTime? IssueDate { get; set; }

    public decimal FareAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal ServiceFeeAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SysLookupItem? PassengerType { get; set; }

    public virtual SysLookupItem? TicketDocumentType { get; set; }

    public virtual TransactionMaster Transaction { get; set; } = null!;

    public virtual TransactionLine? TransactionLine { get; set; }
}
