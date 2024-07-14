# ContactsApp

Wymagania:
    ASP.NET Core Runtime 8.0.X lub SDK 8.0.X
    Node.js

Instalacja vnm i Node.js (Windows):
    https://github.com/coreybutler/nvm-windows/releases/download/1.1.12/nvm-setup.exe
    nvm install latest (instaluje najnowsz¹ wersjê node.js)
    nvm use X.X.X (okreœla która wersja ma byæ u¿ywana, wymagane s¹ uprawnienia administratora)
    nvm ls - listuje zainstalowane wersje oraz pokazuje aktywn¹

Pobranie archiwum:
    git clone https://github.com/goluch/ContactsApp

Uruchomienie backend kokalnie z cli:
    dotnet restore ContactsApp\src\WebApp\WebApp.csproj
    dotnet run ContactsApp\src\WebApp\WebApp.csproj
    dotnet run --project ContactsApp\src\WebApp\WebApp.csproj
    Dokumentacja API widoczna pod URL: http://localhost:[port]/swagger/index.html

Uruchomienie backend w kontenerze (zalecane z poziomu VS):

Uruchomienie backend w kontenerze z cli:
    dotnet restore ContactsApp\src\WebApp\WebApp.csproj
    docker build ContactsApp\src\WebApp\. (nie dzia³a)

Uruchomienie backend frontend:
    cd ContactsApp\src\Client
    npm install
    npm run dev
    Frontend widoczny pod URL: https://localhost:[port]/

    Uwaga w pilku konfiguracyjnym "vite.config.ts" vite nale¿y zmieniæ port pod którym widoczny jest baackend na w³aœciwy:

    const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:[TUTAJ_USTAWIÆ_PORT]';

Wykorzystane biblioteki (backend):
    AutoMapper
    FluentValidation
    Microsoft.AspNetCore.OpenApi
    Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
    Microsoft.AspNetCore.Identity.EntityFrameworkCore
    Microsoft.AspNetCore.Identity.UI
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.Design
    Microsoft.EntityFrameworkCore.Sqlite
    Microsoft.EntityFrameworkCore.Tools
    Microsoft.Extensions.Configuration.Abstractions
    Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore
    Swashbuckle.AspNetCore

Wykorzystane frameworki (frontend):
    Vue.js