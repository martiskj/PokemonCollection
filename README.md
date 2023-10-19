# Kom i gang
## Sett opp databaseservier
Kjør en lokal database med f.eks. docker:

```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(#)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

## Databasemigrering
For å kunne kjøre databasemigreringer lokalt, trenger man [Entity Framework Core sin CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). Installer med følgende kommando:

```
dotnet tool install --global dotnet-ef
```

### Kjøre migreringsscriptene for en database
Får å kjøre migreringsscriptene mot en database, legg til korrekt connection string i appsettings.json og kjør følgende kommando fra rotmappa:

```
dotnet ef database update --project PokemonCollection.Infrastructure --startup-project PokemonCollection.Api
```

## Kjør applikasjonen
```
dotnet run --project PokemonCollection.Api
```