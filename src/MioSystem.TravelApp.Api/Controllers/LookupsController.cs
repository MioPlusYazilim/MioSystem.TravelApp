using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MioSystem.TravelApp.Infrastructure.Data;
using MioSystem.TravelApp.Contracts.Lookups;

namespace MioSystem.TravelApp.Api.Controllers;

[ApiController]
[Route("api/lookups")]
public class LookupsController : ControllerBase
{
    private readonly TravelAppDbContext _db;

    public LookupsController(TravelAppDbContext db)
    {
        _db = db;
    }

    [HttpGet("groups")]
    public async Task<IActionResult> GetGroups(CancellationToken cancellationToken)
    {
        var result = new List<LookupGroupDto>();

        var connection = _db.Database.GetDbConnection();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT ID,Code,ResourceKey,Description,SortOrder,IsActive "+
                               "FROM dbo.SysLookupGroup" +
                               " WHERE IsActive = 1" +
                               " ORDER BY SortOrder, Code;";

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new LookupGroupDto
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Code = reader.GetString(reader.GetOrdinal("Code")),
                ResourceKey = GetNullableString(reader, "ResourceKey"),
                Description = GetNullableString(reader, "Description"),
                SortOrder = reader.GetInt32(reader.GetOrdinal("SortOrder")),
                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
            });
        }

        return Ok(result);
    }

    [HttpGet("{groupCode}")]
    public async Task<IActionResult> GetItems(
        string groupCode,
        [FromQuery] string languageCode = "tr-TR",
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(groupCode))
            return BadRequest("Lookup group code is required.");

        languageCode = NormalizeLanguageCode(languageCode);
        var result = new List<LookupItemDto>();

        var connection = _db.Database.GetDbConnection();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();
        command.CommandText = "dbo.usp_SysLookup_GetItems";
        command.CommandType = CommandType.StoredProcedure;

        var groupCodeParam = command.CreateParameter();
        groupCodeParam.ParameterName = "@GroupCode";
        groupCodeParam.Value = groupCode;
        command.Parameters.Add(groupCodeParam);

        var languageCodeParam = command.CreateParameter();
        languageCodeParam.ParameterName = "@LanguageCode";
        languageCodeParam.Value = languageCode;
        command.Parameters.Add(languageCodeParam);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new LookupItemDto
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                GroupCode = reader.GetString(reader.GetOrdinal("GroupCode")),
                ItemCode = reader.GetString(reader.GetOrdinal("ItemCode")),
                Value = GetNullableString(reader, "Value"),
                ResourceKey = reader.GetString(reader.GetOrdinal("ResourceKey")),
                DisplayName = reader.GetString(reader.GetOrdinal("DisplayName")),
                SortOrder = reader.GetInt32(reader.GetOrdinal("SortOrder")),
                IsDefault = reader.GetBoolean(reader.GetOrdinal("IsDefault"))
            });
        }

        return Ok(result);
    }

    private static string? GetNullableString(DbDataReader reader, string columnName)
    {
        var ordinal = reader.GetOrdinal(columnName);
        return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
    }

    private static string NormalizeLanguageCode(string? languageCode)
    {
        if (string.IsNullOrWhiteSpace(languageCode))
            return "tr-TR";

        var code = languageCode.Trim();

        if (code.Equals("tr", StringComparison.OrdinalIgnoreCase) ||
            code.Equals("tr-TR", StringComparison.OrdinalIgnoreCase))
            return "tr-TR";

        if (code.Equals("en", StringComparison.OrdinalIgnoreCase) ||
            code.Equals("en-US", StringComparison.OrdinalIgnoreCase) ||
            code.Equals("en-EN", StringComparison.OrdinalIgnoreCase) ||
            code.Equals("en-GB", StringComparison.OrdinalIgnoreCase))
            return "en-US";

        return code;
    }
}
