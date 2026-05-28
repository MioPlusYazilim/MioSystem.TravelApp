using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class TransactionRentAcar
{
    public long Id { get; set; }

    public long TransactionId { get; set; }

    public long? TransactionLineId { get; set; }

    public string PickupLocation { get; set; } = null!;

    public string? DropoffLocation { get; set; }

    public DateTime? PickupAt { get; set; }

    public DateTime? DropoffAt { get; set; }

    public string? VehicleGroup { get; set; }

    public string? DriverName { get; set; }

    public string? ConfirmationNo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TransactionMaster Transaction { get; set; } = null!;

    public virtual TransactionLine? TransactionLine { get; set; }
}
