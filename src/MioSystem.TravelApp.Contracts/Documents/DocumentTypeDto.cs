namespace MioSystem.TravelApp.Contracts.Documents;

public sealed class DocumentTypeDto
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string ResourceKey { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public int? CategoryId { get; set; }
    public string? CategoryCode { get; set; }
    public string? CategoryName { get; set; }
    public string? AllowedExtensions { get; set; }
    public int? MaxFileSizeMb { get; set; }
    public bool RequiresIssueDate { get; set; }
    public bool RequiresExpiryDate { get; set; }
    public bool HasDocumentNo { get; set; }
    public bool IsReusable { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}