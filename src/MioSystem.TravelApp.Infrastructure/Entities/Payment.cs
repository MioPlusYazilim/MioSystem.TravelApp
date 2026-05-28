using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class Payment
{
    public long Id { get; set; }

    public long PaymentNoSequence { get; set; }

    public string? PaymentNo { get; set; }

    public long? InvoiceId { get; set; }

    public long? CurrentAccountId { get; set; }

    public long? CustomerId { get; set; }

    public int DirectionId { get; set; }

    public int StatusId { get; set; }

    public int CurrencyId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual CurrentAccount? CurrentAccount { get; set; }

    public virtual ICollection<CurrentAccountTransaction> CurrentAccountTransactions { get; set; } = new List<CurrentAccountTransaction>();

    public virtual Customer? Customer { get; set; }

    public virtual SysLookupItem Direction { get; set; } = null!;

    public virtual Invoice? Invoice { get; set; }

    public virtual SysLookupItem Status { get; set; } = null!;
}
