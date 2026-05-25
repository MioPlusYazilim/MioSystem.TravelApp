# MioSystem.TravelApp Database Naming

## Project / Solution

- Solution name: `MioSystem.TravelApp`
- API project: `MioSystem.TravelApp.Api`
- Domain project: `MioSystem.TravelApp.Domain`
- Infrastructure project: `MioSystem.TravelApp.Infrastructure`
- Application project: `MioSystem.TravelApp.Application`

## Database

- SQL Server database name: `MioSystem_TravelApp`
- Reason: SQL Server allows dots in database names, but underscores are cleaner for scripts, backup names, connection strings and tooling.

## Connection String Key

```json
"MioSystemTravelAppDb": "Server=.;Database=MioSystem_TravelApp;Trusted_Connection=True;TrustServerCertificate=True;"
```

## Main Table Naming

- `Sys*` = system, lookup, localization
- `Company*` = company setup
- `Customer*` = customer setup
- `Request*` = customer demand/request process
- `RequestOffer*` = alternative offer process
- `Transaction*` = sale/refund/reissue/void/operation process
- `Invoice*` = invoice
- `Payment*` = collection/payment
- `CurrentAccount*` = accounting ledger/current account

## Object Naming

- Primary key: `PK_TableName`
- Foreign key: `FK_ChildTable_ParentTable_ColumnName`
- Default constraint: `DF_TableName_ColumnName`
- Unique constraint: `UQ_TableName_ColumnName`
- Index: `IX_TableName_ColumnName`
- View: `vw_Module_Purpose`
- Stored procedure: `usp_Module_Action`
- Function: `ufn_Module_Action`

## Multilanguage Rule

Do not store user-visible text inside business tables.

Correct:
- `StatusID`
- `StatusCode`
- `ResourceKey`

Wrong:
- `StatusName = 'Satışa Çevrildi'`

Views should return `ResourceKey`.
Stored procedures may accept `@LanguageCode` for report/export outputs.
