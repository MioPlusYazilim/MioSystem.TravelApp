USE [MioSystem_TravelApp];
GO

/*
    Multilanguage foundation:
    - SysLanguage
    - SysResource
    - SysResourceTranslation

    Rule:
    Business tables should store IDs, Codes and ResourceKeys.
    User-visible names/messages should come from SysResourceTranslation.
*/

IF OBJECT_ID(N'dbo.SysLanguage', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SysLanguage
    (
        ID INT IDENTITY(1,1) NOT NULL,
        Code NVARCHAR(10) NOT NULL,       -- tr-TR, en-US
        ShortCode NVARCHAR(5) NOT NULL,   -- tr, en
        Name NVARCHAR(100) NOT NULL,
        CultureName NVARCHAR(100) NULL,
        SortOrder INT NOT NULL CONSTRAINT DF_SysLanguage_SortOrder DEFAULT(0),
        IsDefault BIT NOT NULL CONSTRAINT DF_SysLanguage_IsDefault DEFAULT(0),
        IsActive BIT NOT NULL CONSTRAINT DF_SysLanguage_IsActive DEFAULT(1),
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_SysLanguage_CreatedAt DEFAULT(SYSDATETIME()),

        CONSTRAINT PK_SysLanguage PRIMARY KEY CLUSTERED (ID),
        CONSTRAINT UQ_SysLanguage_Code UNIQUE (Code),
        CONSTRAINT UQ_SysLanguage_ShortCode UNIQUE (ShortCode)
    );

    CREATE UNIQUE INDEX UX_SysLanguage_OnlyOneDefault
        ON dbo.SysLanguage(IsDefault)
        WHERE IsDefault = 1;
END
GO

IF OBJECT_ID(N'dbo.SysResource', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SysResource
    (
        ID BIGINT IDENTITY(1,1) NOT NULL,
        ResourceKey NVARCHAR(250) NOT NULL,
        ResourceType NVARCHAR(50) NOT NULL, -- Lookup, UiLabel, ApiMessage, ValidationMessage, ReportColumn, Menu, Button
        Description NVARCHAR(500) NULL,
        IsSystem BIT NOT NULL CONSTRAINT DF_SysResource_IsSystem DEFAULT(1),
        IsActive BIT NOT NULL CONSTRAINT DF_SysResource_IsActive DEFAULT(1),
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_SysResource_CreatedAt DEFAULT(SYSDATETIME()),

        CONSTRAINT PK_SysResource PRIMARY KEY CLUSTERED (ID),
        CONSTRAINT UQ_SysResource_ResourceKey UNIQUE (ResourceKey)
    );

    CREATE INDEX IX_SysResource_ResourceType
        ON dbo.SysResource(ResourceType);
END
GO

IF OBJECT_ID(N'dbo.SysResourceTranslation', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SysResourceTranslation
    (
        ID BIGINT IDENTITY(1,1) NOT NULL,
        ResourceID BIGINT NOT NULL,
        LanguageID INT NOT NULL,
        Value NVARCHAR(MAX) NOT NULL,
        IsApproved BIT NOT NULL CONSTRAINT DF_SysResourceTranslation_IsApproved DEFAULT(1),
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_SysResourceTranslation_CreatedAt DEFAULT(SYSDATETIME()),

        CONSTRAINT PK_SysResourceTranslation PRIMARY KEY CLUSTERED (ID),
        CONSTRAINT FK_SysResourceTranslation_SysResource
            FOREIGN KEY (ResourceID) REFERENCES dbo.SysResource(ID),
        CONSTRAINT FK_SysResourceTranslation_SysLanguage
            FOREIGN KEY (LanguageID) REFERENCES dbo.SysLanguage(ID),
        CONSTRAINT UQ_SysResourceTranslation_Resource_Language
            UNIQUE(ResourceID, LanguageID)
    );
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Localization_GetResources
(
    @LanguageCode NVARCHAR(10),
    @ResourceType NVARCHAR(50) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @LanguageID INT;
    DECLARE @DefaultLanguageID INT;

    SELECT @LanguageID = ID
    FROM dbo.SysLanguage
    WHERE Code = @LanguageCode
      AND IsActive = 1;

    SELECT @DefaultLanguageID = ID
    FROM dbo.SysLanguage
    WHERE IsDefault = 1
      AND IsActive = 1;

    SELECT
        r.ResourceKey,
        r.ResourceType,
        Value = COALESCE(rt.Value, rtd.Value, r.ResourceKey)
    FROM dbo.SysResource r
    LEFT JOIN dbo.SysResourceTranslation rt
        ON rt.ResourceID = r.ID
       AND rt.LanguageID = @LanguageID
    LEFT JOIN dbo.SysResourceTranslation rtd
        ON rtd.ResourceID = r.ID
       AND rtd.LanguageID = @DefaultLanguageID
    WHERE r.IsActive = 1
      AND (@ResourceType IS NULL OR r.ResourceType = @ResourceType)
    ORDER BY r.ResourceType, r.ResourceKey;
END
GO
