using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class CurrentAccount
{
    public long Id { get; set; }

    public long AccountNoSequence { get; set; }

    public string? AccountCode { get; set; }

    public long? CustomerId { get; set; }

    public long? CompanyId { get; set; }

    public string Title { get; set; } = null!;

    public int CurrencyId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Company? Company { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual ICollection<CurrentAccountTransaction> CurrentAccountTransactions { get; set; } = new List<CurrentAccountTransaction>();

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
