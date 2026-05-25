MioSystem.TravelApp Connection Fix v2

Bu paket BAT parser hatasini duzeltir.

Neden oldu?
- SQL_SERVER degeri LocalDB ise icinde parantez var: (localdb)\MSSQLLocalDB
- Eski BAT dosyasinda IF (...) ELSE (...) bloklari vardi.
- CMD, parantezli server adini blok sonu gibi okuyabildi.
- Bu yuzden 'MSSQLLocalDB was unexpected at this time' hatasi olustu.

Ne yapacaksin?
1. Bu zip icindeki dosyalari proje klasorunun uzerine kopyala.
2. 00_SetVariables.bat dosyasini Notepad ile ac.
3. SQL_SERVER ve DB_AUTH ayarlarini duzelt.
4. 00_ShowCurrentSettings.bat calistir.
5. 00_TestDatabaseConnection.bat calistir.

Tavsiye:
Projeyi Downloads altindan degil su klasorden calistir:
C:\WorkSpaces\MioSystem.TravelApp
