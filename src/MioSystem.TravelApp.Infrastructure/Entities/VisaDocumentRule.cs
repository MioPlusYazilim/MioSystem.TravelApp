using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VisaDocumentRule
{
    public long Id { get; set; }

    public string CountryCode { get; set; } = null!;

    public string? VisaType { get; set; }

    public int DocumentTypeId { get; set; }

    public bool IsRequired { get; set; }

    public bool IsReusableAllowed { get; set; }

    public bool MustBeValidOnTravelDate { get; set; }

    public int? MinValidityDaysAfterTravel { get; set; }

    public int? RequiredBeforeDays { get; set; }

    public int SortOrder { get; set; }

    public string? Note { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<TransactionVisaDocument> TransactionVisaDocuments { get; set; } = new List<TransactionVisaDocument>();
}
