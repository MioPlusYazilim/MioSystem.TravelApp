using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class DocumentType
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string ResourceKey { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? AllowedExtensions { get; set; }

    public int? MaxFileSizeMb { get; set; }

    public bool RequiresIssueDate { get; set; }

    public bool RequiresExpiryDate { get; set; }

    public bool HasDocumentNo { get; set; }

    public bool IsReusable { get; set; }

    public int SortOrder { get; set; }

    public bool IsSystem { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SysLookupItem? Category { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<TransactionVisaDocument> TransactionVisaDocuments { get; set; } = new List<TransactionVisaDocument>();

    public virtual ICollection<VisaDocumentRule> VisaDocumentRules { get; set; } = new List<VisaDocumentRule>();
}
