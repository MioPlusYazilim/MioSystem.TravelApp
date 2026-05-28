using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class CurrentAccountTransaction
{
    public long Id { get; set; }

    public long CurrentAccountId { get; set; }

    public long? InvoiceId { get; set; }

    public long? PaymentId { get; set; }

    public int TransactionTypeId { get; set; }

    public int CurrencyId { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal DebitAmount { get; set; }

    public decimal CreditAmount { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual CurrentAccount CurrentAccount { get; set; } = null!;

    public virtual Invoice? Invoice { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual SysLookupItem TransactionType { get; set; } = null!;
}
