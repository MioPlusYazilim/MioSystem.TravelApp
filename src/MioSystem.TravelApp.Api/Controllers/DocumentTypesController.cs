using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MioSystem.TravelApp.Infrastructure.Data;
using MioSystem.TravelApp.Contracts.Documents;

namespace MioSystem.TravelApp.Api.Controllers;

[ApiController]
[Route("api/document-types")]
public class DocumentTypesController : ControllerBase
{
    private readonly TravelAppDbContext _db;

    public DocumentTypesController(TravelAppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetDocumentTypes(
        [FromQuery] string languageCode = "tr-TR",
        [FromQuery] string? categoryCode = null,
        CancellationToken cancellationToken = default)
    {
        languageCode = NormalizeLanguageCode(languageCode);

        var result = new List<DocumentTypeDto>();
        var connection = _db.Database.GetDbConnection();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandText = """
            DECLARE @LanguageID INT;

            SELECT TOP 1
                @LanguageID = ID
            FROM dbo.SysLanguage
            WHERE Code = @LanguageCode
              AND IsActive = 1;

            SELECT
                dt.ID,
                dt.Code,
                dt.ResourceKey,
                DisplayName = COALESCE(tr.Value, dt.Code),
                dt.CategoryID,
                CategoryCode = cat.Code,
                CategoryName = COALESCE(catTr.Value, cat.Code),
                dt.AllowedExtensions,
                dt.MaxFileSizeMB,
                dt.RequiresIssueDate,
                dt.RequiresExpiryDate,
                dt.HasDocumentNo,
                dt.IsReusable,
                dt.SortOrder,
                dt.IsActive
            FROM dbo.DocumentType dt
            LEFT JOIN dbo.SysResource res
                ON res.ResourceKey = dt.ResourceKey
            LEFT JOIN dbo.SysResourceTranslation tr
                ON tr.ResourceID = res.ID
               AND tr.LanguageID = @LanguageID
            LEFT JOIN dbo.SysLookupItem cat
                ON cat.ID = dt.CategoryID
            LEFT JOIN dbo.SysResource catRes
                ON catRes.ResourceKey = cat.ResourceKey
            LEFT JOIN dbo.SysResourceTranslation catTr
                ON catTr.ResourceID = catRes.ID
               AND catTr.LanguageID = @LanguageID
            WHERE dt.IsActive = 1
              AND (@CategoryCode IS NULL OR cat.Code = @CategoryCode)
            ORDER BY dt.SortOrder, dt.Code;
            """;

        AddParameter(command, "@LanguageCode", languageCode);
        AddParameter(command, "@CategoryCode", string.IsNullOrWhiteSpace(categoryCode) ? null : categoryCode);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new DocumentTypeDto
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Code = reader.GetString(reader.GetOrdinal("Code")),
                ResourceKey = reader.GetString(reader.GetOrdinal("ResourceKey")),
                DisplayName = reader.GetString(reader.GetOrdinal("DisplayName")),
                CategoryId = GetNullableInt(reader, "CategoryID"),
                CategoryCode = GetNullableString(reader, "CategoryCode"),
                CategoryName = GetNullableString(reader, "CategoryName"),
                AllowedExtensions = GetNullableString(reader, "AllowedExtensions"),
                MaxFileSizeMb = GetNullableInt(reader, "MaxFileSizeMB"),
                RequiresIssueDate = reader.GetBoolean(reader.GetOrdinal("RequiresIssueDate")),
                RequiresExpiryDate = reader.GetBoolean(reader.GetOrdinal("RequiresExpiryDate")),
                HasDocumentNo = reader.GetBoolean(reader.GetOrdinal("HasDocumentNo")),
                IsReusable = reader.GetBoolean(reader.GetOrdinal("IsReusable")),
                SortOrder = reader.GetInt32(reader.GetOrdinal("SortOrder")),
                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
            });
        }

        return Ok(result);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetDocumentTypeByCode(
        string code,
        [FromQuery] string languageCode = "tr-TR",
        CancellationToken cancellationToken = default)
    {
        languageCode = NormalizeLanguageCode(languageCode);

        var result = await GetDocumentTypeInternal(code, languageCode, cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    private async Task<DocumentTypeDto?> GetDocumentTypeInternal(
        string code,
        string languageCode,
        CancellationToken cancellationToken)
    {
        var connection = _db.Database.GetDbConnection();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandText = """
            DECLARE @LanguageID INT;

            SELECT TOP 1
                @LanguageID = ID
            FROM dbo.SysLanguage
            WHERE Code = @LanguageCode
              AND IsActive = 1;

            SELECT TOP 1
                dt.ID,
                dt.Code,
                dt.ResourceKey,
                DisplayName = COALESCE(tr.Value, dt.Code),
                dt.CategoryID,
                CategoryCode = cat.Code,
                CategoryName = COALESCE(catTr.Value, cat.Code),
                dt.AllowedExtensions,
                dt.MaxFileSizeMB,
                dt.RequiresIssueDate,
                dt.RequiresExpiryDate,
                dt.HasDocumentNo,
                dt.IsReusable,
                dt.SortOrder,
                dt.IsActive
            FROM dbo.DocumentType dt
            LEFT JOIN dbo.SysResource res
                ON res.ResourceKey = dt.ResourceKey
            LEFT JOIN dbo.SysResourceTranslation tr
                ON tr.ResourceID = res.ID
               AND tr.LanguageID = @LanguageID
            LEFT JOIN dbo.SysLookupItem cat
                ON cat.ID = dt.CategoryID
            LEFT JOIN dbo.SysResource catRes
                ON catRes.ResourceKey = cat.ResourceKey
            LEFT JOIN dbo.SysResourceTranslation catTr
                ON catTr.ResourceID = catRes.ID
               AND catTr.LanguageID = @LanguageID
            WHERE dt.Code = @Code
              AND dt.IsActive = 1;
            """;

        AddParameter(command, "@LanguageCode", languageCode);
        AddParameter(command, "@Code", code);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new DocumentTypeDto
        {
            Id = reader.GetInt32(reader.GetOrdinal("ID")),
            Code = reader.GetString(reader.GetOrdinal("Code")),
            ResourceKey = reader.GetString(reader.GetOrdinal("ResourceKey")),
            DisplayName = reader.GetString(reader.GetOrdinal("DisplayName")),
            CategoryId = GetNullableInt(reader, "CategoryID"),
            CategoryCode = GetNullableString(reader, "CategoryCode"),
            CategoryName = GetNullableString(reader, "CategoryName"),
            AllowedExtensions = GetNullableString(reader, "AllowedExtensions"),
            MaxFileSizeMb = GetNullableInt(reader, "MaxFileSizeMB"),
            RequiresIssueDate = reader.GetBoolean(reader.GetOrdinal("RequiresIssueDate")),
            RequiresExpiryDate = reader.GetBoolean(reader.GetOrdinal("RequiresExpiryDate")),
            HasDocumentNo = reader.GetBoolean(reader.GetOrdinal("HasDocumentNo")),
            IsReusable = reader.GetBoolean(reader.GetOrdinal("IsReusable")),
            SortOrder = reader.GetInt32(reader.GetOrdinal("SortOrder")),
            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
        };
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

    private static void AddParameter(DbCommand command, string name, object? value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value ?? DBNull.Value;
        command.Parameters.Add(parameter);
    }

    private static string? GetNullableString(DbDataReader reader, string columnName)
    {
        var ordinal = reader.GetOrdinal(columnName);
        return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
    }

    private static int? GetNullableInt(DbDataReader reader, string columnName)
    {
        var ordinal = reader.GetOrdinal(columnName);
        return reader.IsDBNull(ordinal) ? null : reader.GetInt32(ordinal);
    }
}
