

# Databasemigrering
For � kunne kj�re databasemigreringer lokalt, trenger man [Entity Framework Core sin CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). Installer med f�lgende kommando:

```
dotnet tool install --global dotnet-ef
```

## Legge til nytt migreringsscript
For � legge til nytt migreringsscript, gj�r n�dvendige endringer p� domenemodellene og kj�r f�lgende kommando fra rotmappa:

```
dotnet ef migrations add CreateGroupAndFavorites --project PokemonCollection.Infrastructure --startup-project PokemonCollection.Api
```

## Kj�re migreringsscriptene for en database
F�r � kj�re migreringsscriptene mot en database, legg til korrekt connection string i appsettings.json og kj�r f�lgende kommando fra rotmappa:

```
dotnet ef database update --project PokemonCollection.Infrastructure --startup-project PokemonCollection.Api
```