# MioSystem.TravelApp - Database First Calisma Sirasi

Bu projede once database tasarimi tamamlanacak, sonra entity ve DbContext database'den uretilecek.

## Sira

1. `00_CreateDatabase.sql`
2. `01_Localization_Core.sql`
3. `02_Lookup_Core.sql`
4. `03_Seed_RequestWorkflow_Localization.sql`
5. Request / Offer tablolarinin eklenmesi
6. Transaction / Accounting tablolarinin eklenmesi
7. View ve stored procedure tasarimi
8. `50_EF_DatabaseFirst_Scaffold.bat` ile entity uretimi

## Coklu Dil Karari

- Tablolarda gorunen metin saklanmaz.
- Sabitlerde `Code` ve `ResourceKey` saklanir.
- View'lar dil bagimsiz olur ve `ResourceKey` dondurur.
- Rapor stored procedure'leri gerekirse `@LanguageCode` parametresi alir.
- API cevaplari `messageCode + message` seklinde dondurulur.

## EF Scaffold Notu

Scaffold dosyalari su klasore uretilir:

`src/MioSystem.TravelApp.Infrastructure/Data`

Entity dosyalari:

`src/MioSystem.TravelApp.Infrastructure/Data/Entities`

DbContext:

`src/MioSystem.TravelApp.Infrastructure/Data/TravelAppDbContext.cs`
