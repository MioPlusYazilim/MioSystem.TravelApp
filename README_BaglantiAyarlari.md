# MioSystem.TravelApp - Database Bağlantı Ayarları

Bağlantı ayarlarının ana dosyası:

```bat
00_SetVariables.bat
```

Önce bu dosyayı Notepad ile açıp düzenle.

## 1) SQL Server seçimi

### Varsayılan instance

```bat
set "SQL_SERVER=."
```

### SQL Express

```bat
set "SQL_SERVER=.\SQLEXPRESS"
```

### LocalDB

```bat
set "SQL_SERVER=(localdb)\MSSQLLocalDB"
```

### Uzak SQL Server

```bat
set "SQL_SERVER=192.168.1.10,1433"
```

## 2) Windows Authentication

Windows kullanıcın SQL Server'a yetkiliyse:

```bat
set "DB_AUTH=WINDOWS"
```

Bu durumda kullanıcı adı ve şifre dikkate alınmaz.

## 3) SQL kullanıcı adı / şifre

SQL kullanıcı adı ve şifreyle bağlanmak istiyorsan:

```bat
set "DB_AUTH=SQL"
set "DB_USER=sa"
set "DB_PASSWORD=SeninSifren"
```

Dikkat: `.bat` dosyalarında `&`, `%`, `^` gibi karakterler sorun çıkarabilir.
İlk kurulum için daha sade bir SQL şifresiyle test etmek daha kolaydır.

## 4) Fiziksel database dosya yolu

Boş bırakırsan SQL Server kendi default data/log yolunu kullanır:

```bat
set "SQL_DATA_PATH="
set "SQL_LOG_PATH="
```

Özel yol vermek istersen:

```bat
set "SQL_DATA_PATH=C:\SqlData"
set "SQL_LOG_PATH=C:\SqlLog"
```

Bu klasörleri önceden oluştur ve SQL Server servis kullanıcısının bu klasörlere yazma izni olduğundan emin ol.

## 5) Kontrol sırası

```bat
00_ShowCurrentSettings.bat
00_TestDatabaseConnection.bat
06_CreateConfigFiles.bat
20_RunDatabaseScripts.bat
50_EF_DatabaseFirst_Scaffold.bat
```

`06_CreateConfigFiles.bat` artık `appsettings.Development.json` dosyasını `00_SetVariables.bat` içindeki connection string'e göre otomatik üretir.
