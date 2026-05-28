namespace MioSystem.TravelApp.Contracts.Lookups;

public sealed class LookupGroupDto
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string? ResourceKey { get; set; }
    public string? Description { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}