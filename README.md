

# Databasemigrering
For å kunne kjøre databasemigreringer lokalt, trenger man [Entity Framework Core sin CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). Installer med følgende kommando:

```
dotnet tool install --global dotnet-ef
```

## Legge til nytt migreringsscript
For å legge til nytt migreringsscript, gjør nødvendige endringer på domenemodellene og kjør følgende kommando fra rotmappa:

```
dotnet ef migrations add CreateGroupAndFavorites --project PokemonCollection.Infrastructure --startup-project PokemonCollection.Api
```

## Kjøre migreringsscriptene for en database
Får å kjøre migreringsscriptene mot en database, legg til korrekt connection string i appsettings.json og kjør følgende kommando fra rotmappa:

```
dotnet ef database update --project PokemonCollection.Infrastructure --startup-project PokemonCollection.Api
```