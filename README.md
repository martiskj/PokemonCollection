# Kom i gang
## Sett opp databaseservier
Kj�r en lokal database med f.eks. docker:

```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(#)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

## Databasemigrering
For � kunne kj�re databasemigreringer lokalt, trenger man [Entity Framework Core sin CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). Installer med f�lgende kommando:

```
dotnet tool install --global dotnet-ef
```

### Kj�re migreringsscriptene for en database
F�r � kj�re migreringsscriptene mot en database, legg til korrekt connection string i appsettings.json og kj�r f�lgende kommando fra rotmappa:

```
dotnet ef database update --project PokemonCollection.Infrastructure --startup-project PokemonCollection.Api
```

## Kj�r applikasjonen
```
dotnet run --project PokemonCollection.Api
```