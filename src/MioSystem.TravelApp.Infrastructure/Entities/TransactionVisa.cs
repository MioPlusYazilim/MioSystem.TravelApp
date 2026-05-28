using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class TransactionVisa
{
    public long Id { get; set; }

    public long TransactionId { get; set; }

    public long? TransactionLineId { get; set; }

    public string ApplicantFirstName { get; set; } = null!;

    public string ApplicantLastName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string? VisaType { get; set; }

    public string? ApplicationNo { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public string? StatusNote { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TransactionMaster Transaction { get; set; } = null!;

    public virtual TransactionLine? TransactionLine { get; set; }

    public virtual ICollection<TransactionVisaDocument> TransactionVisaDocuments { get; set; } = new List<TransactionVisaDocument>();
}
