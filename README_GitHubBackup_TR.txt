MioSystem.TravelApp - GitHub Yedekleme

1) GitHub'da yeni repository olustur.
   Repository name: MioSystem.TravelApp
   Public/Private: Tercihen Private
   README, .gitignore veya license ekleme. Bos repository olsun.

2) Bu paketteki dosyalari proje ana klasorune kopyala:
   C:\WorkSpaces\MioSystem.TravelApp

3) 90_Git_Settings.bat dosyasini ac.
   GIT_REMOTE_URL dogru mu kontrol et.

   Ornek:
   set "GIT_REMOTE_URL=https://github.com/suleymanaydin58/MioSystem.TravelApp.git"

4) Sirayla calistir:
   91_Git_Check.bat
   92_Git_Init_LocalRepository.bat
   93_Git_SetRemote.bat
   94_Git_Backup_Push.bat

5) Sonraki yedeklemelerde sadece sunu calistirman yeterli:
   94_Git_Backup_Push.bat

ONEMLI:
- appsettings.Development.json GitHub'a gitmemeli.
- SQL sifreleri GitHub'a gitmemeli.
- pfx, pem, key, sertifika ve database dosyalari GitHub'a gitmemeli.
- GitHub yedekleme kod icindir; MSSQL database yedegi ayrica .bak olarak alinmalidir.
