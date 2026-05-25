# MioSystem.TravelApp - Proje Yapilandirma Paketi

Bu paket, projeyi kucuk ve kontrol edilebilir `.bat` dosyalariyla kurmak icin hazirlandi.

## Onerilen Kullanim

Paket icindeki dosyalari bos bir klasore ac:

`C:\WorkSpaces\MioSystem.TravelApp`

Sonra sirayla calistir:

```bat
01_CheckEnvironment.bat
02_CreateSolutionAndProjects.bat
03_AddProjectReferences.bat
04_AddNugetPackages.bat
05_CreateProjectFolders.bat
06_CreateConfigFiles.bat
40_InstallEfTool.bat
30_BuildSolution.bat
```

Database icin:

```bat
20_RunDatabaseScripts.bat
```

Entity/DbContext uretmek icin database hazir olduktan sonra:

```bat
50_EF_DatabaseFirst_Scaffold.bat
```

## Tek Seferde Kurulum

Kontrol ederek gitmek daha dogru. Ama istersen proje iskeleti icin sunu da calistirabilirsin:

```bat
99_RunAll_ProjectSetup.bat
```

## Degistirilecek Ana Dosya

SQL Server ismin farkliysa sadece su dosyayi duzenle:

```bat
00_SetVariables.bat
```

Ornek:

```bat
set "SQL_SERVER=.\SQLEXPRESS"
```

veya

```bat
set "SQL_SERVER=(localdb)\MSSQLLocalDB"
```

## Database Adi

Proje adi:

`MioSystem.TravelApp`

SQL Server database adi:

`MioSystem_TravelApp`

Nokta yerine alt cizgi kullanildi; script, backup ve connection string tarafinda daha temizdir.
