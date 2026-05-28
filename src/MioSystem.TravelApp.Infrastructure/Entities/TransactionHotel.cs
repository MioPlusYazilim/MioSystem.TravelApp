using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class TransactionHotel
{
    public long Id { get; set; }

    public long TransactionId { get; set; }

    public long? TransactionLineId { get; set; }

    public string HotelName { get; set; } = null!;

    public string? City { get; set; }

    public DateOnly? CheckInDate { get; set; }

    public DateOnly? CheckOutDate { get; set; }

    public string? GuestName { get; set; }

    public string? RoomType { get; set; }

    public string? ConfirmationNo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TransactionMaster Transaction { get; set; } = null!;

    public virtual TransactionLine? TransactionLine { get; set; }
}
