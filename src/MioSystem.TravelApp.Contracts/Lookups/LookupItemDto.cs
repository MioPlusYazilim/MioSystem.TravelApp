namespace MioSystem.TravelApp.Contracts.Lookups;

public sealed class LookupItemDto
{
    public int Id { get; set; }
    public string GroupCode { get; set; } = "";
    public string ItemCode { get; set; } = "";
    public string? Value { get; set; }
    public string ResourceKey { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public int SortOrder { get; set; }
    public bool IsDefault { get; set; }
}