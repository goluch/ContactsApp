# ContactsApp

Wymagania:
* ASP.NET Core Runtime 8.0.X lub SDK 8.0.X
* Node.js

Instalacja vnm i Node.js (Windows):
* https://github.com/coreybutler/nvm-windows/releases/download/1.1.12/nvm-setup.exe
* nvm install latest (instaluje najnowsz¹ wersjê node.js)
* nvm use X.X.X (okreœla która wersja ma byæ u¿ywana, wymagane s¹ uprawnienia administratora)
* nvm ls - listuje zainstalowane wersje oraz pokazuje aktywn¹

Pobranie archiwum:
* git clone https://github.com/goluch/ContactsApp

Uruchomienie backend i frontend (zalecane z poziomu VS):
* Otówrz solucjê
* Ustaw w projekcie startowym WebApp pferefowany sposób uruchomienia: Docker/Kestrell/IIS Express
* Uruchom WebApp (F5)
* W eksploratorze solucji w menu kontekstowym projektu frontend/src/client wybierz: Debuguj -> Uruchom nowe wyst¹pienie
* Alternatywnie do 2 poprzednich podpunktów, ustaw we w³aœciwoœciach solucji w opcji wiele projektów startowych akcje WebApp i client na Uruchom

> Uwaga w pilku konfiguracyjnym "vite.config.ts" vite nale¿y zmieniæ port pod którym widoczny jest baackend na w³aœciwy:
> 
> const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
> env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:[TUTAJ_USTAWIÆ_PORT]';

* Uruchomienie backend lokalnie z cli:
* dotnet restore ContactsApp\src\WebApp\WebApp.csproj
* dotnet run ContactsApp\src\WebApp\WebApp.csproj
* dotnet run --project ContactsApp\src\WebApp\WebApp.csproj
* Dokumentacja API widoczna pod URL: http://localhost:[port]/swagger/index.html

Uruchomienie backend frontend:
* cd ContactsApp\src\Client
* npm install
* npm run dev
* Frontend widoczny pod URL: https://localhost:[port]/

Wykorzystane biblioteki (backend):
* AutoMapper
* FluentValidation
* Microsoft.AspNetCore.OpenApi
* Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
* Microsoft.AspNetCore.Identity.EntityFrameworkCore
* Microsoft.AspNetCore.Identity.UI
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Sqlite
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.Extensions.Configuration.Abstractions
* Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore
* Swashbuckle.AspNetCore
* DocumentFormat.OpenXml

Wykorzystane frameworki i wtyczki (frontend):
* Vue 3 + Typescript + Vite
* Vuex
* VueGoodTable
* Bootstrap
