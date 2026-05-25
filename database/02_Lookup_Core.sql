USE [MioSystem_TravelApp];
GO

/*
    Lookup foundation:
    All fixed values are stored as Code + ResourceKey.
    UI/API/report layers translate ResourceKey by language.
*/

IF OBJECT_ID(N'dbo.SysLookupGroup', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SysLookupGroup
    (
        ID INT IDENTITY(1,1) NOT NULL,
        Code NVARCHAR(100) NOT NULL,          -- RequestStatus, OfferStatus, ServiceType
        ResourceKey NVARCHAR(250) NULL,
        Description NVARCHAR(500) NULL,
        SortOrder INT NOT NULL CONSTRAINT DF_SysLookupGroup_SortOrder DEFAULT(0),
        IsSystem BIT NOT NULL CONSTRAINT DF_SysLookupGroup_IsSystem DEFAULT(1),
        IsActive BIT NOT NULL CONSTRAINT DF_SysLookupGroup_IsActive DEFAULT(1),
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_SysLookupGroup_CreatedAt DEFAULT(SYSDATETIME()),

        CONSTRAINT PK_SysLookupGroup PRIMARY KEY CLUSTERED (ID),
        CONSTRAINT UQ_SysLookupGroup_Code UNIQUE (Code)
    );
END
GO

IF OBJECT_ID(N'dbo.SysLookupItem', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SysLookupItem
    (
        ID INT IDENTITY(1,1) NOT NULL,
        GroupID INT NOT NULL,
        Code NVARCHAR(100) NOT NULL,
        Value NVARCHAR(100) NULL,
        ResourceKey NVARCHAR(250) NOT NULL,
        SortOrder INT NOT NULL CONSTRAINT DF_SysLookupItem_SortOrder DEFAULT(0),
        IsDefault BIT NOT NULL CONSTRAINT DF_SysLookupItem_IsDefault DEFAULT(0),
        IsSystem BIT NOT NULL CONSTRAINT DF_SysLookupItem_IsSystem DEFAULT(1),
        IsActive BIT NOT NULL CONSTRAINT DF_SysLookupItem_IsActive DEFAULT(1),
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_SysLookupItem_CreatedAt DEFAULT(SYSDATETIME()),

        CONSTRAINT PK_SysLookupItem PRIMARY KEY CLUSTERED (ID),
        CONSTRAINT FK_SysLookupItem_SysLookupGroup
            FOREIGN KEY (GroupID) REFERENCES dbo.SysLookupGroup(ID),
        CONSTRAINT UQ_SysLookupItem_Group_Code UNIQUE(GroupID, Code)
    );

    CREATE INDEX IX_SysLookupItem_GroupID_SortOrder
        ON dbo.SysLookupItem(GroupID, SortOrder, ID);
END
GO

CREATE OR ALTER VIEW dbo.vw_SysLookupItem
AS
SELECT
    i.ID,
    g.Code AS GroupCode,
    i.Code AS ItemCode,
    i.Value,
    i.ResourceKey,
    i.SortOrder,
    i.IsDefault,
    i.IsActive
FROM dbo.SysLookupItem i
INNER JOIN dbo.SysLookupGroup g ON g.ID = i.GroupID;
GO

CREATE OR ALTER PROCEDURE dbo.usp_SysLookup_GetItems
(
    @GroupCode NVARCHAR(100),
    @LanguageCode NVARCHAR(10) = N'tr-TR'
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
        i.ID,
        GroupCode = g.Code,
        ItemCode = i.Code,
        i.Value,
        i.ResourceKey,
        DisplayName = COALESCE(rt.Value, rtd.Value, i.Code),
        i.SortOrder,
        i.IsDefault
    FROM dbo.SysLookupGroup g
    INNER JOIN dbo.SysLookupItem i ON i.GroupID = g.ID
    LEFT JOIN dbo.SysResource r ON r.ResourceKey = i.ResourceKey
    LEFT JOIN dbo.SysResourceTranslation rt
        ON rt.ResourceID = r.ID
       AND rt.LanguageID = @LanguageID
    LEFT JOIN dbo.SysResourceTranslation rtd
        ON rtd.ResourceID = r.ID
       AND rtd.LanguageID = @DefaultLanguageID
    WHERE g.Code = @GroupCode
      AND g.IsActive = 1
      AND i.IsActive = 1
    ORDER BY i.SortOrder, i.ID;
END
GO
