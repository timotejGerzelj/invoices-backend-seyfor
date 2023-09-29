# Aplikacija za upravljanje racunov v .Net

Preprosta spletna aplikacija v C# .Net za upravljanje racunov, ustvarjena za izziv InvoiceApp v podjetju Seyfor!

## Kazalo vsebine
- [Motivacija](#motivacija)
- [Začetek](#začetek)
  - [Namestitev](#namestitev)
  - [Zagon aplikacije](#zagon-aplikacije)
    - [Kako zaženete aplikacijo](#kako-zazenete-aplikacijo)
- [Predpostavke](#predpostavke)
- [Kaj bi spremenil](#kaj-bi-spremenil)

## Motivacija

Ta projekt je bil ustvarjen kot del izziva med delovnim tednom, v okviru postopka za zaposlitev. Aplikacija vsebuje kreiranje več tabel v bazi podatkov in vstavljanje več vrstic, kot je določeno v nalogi. Aplikacija tudi obvladuje pridobivanje, kreiranje in posodabljanje računov ter vrstic računov, ter pridobivanje organizacij, strank in artiklov.

## Začetek
Potrebovali boste:
1. PostgreSQL
2. C# (Dotnet Core Entity)

### Namestitev
- Namestite PostgreSQL iz [postgresql.org](https://www.postgresql.org/download/) in nastavite bazo podatkov. Priporočam uporabo imena baze `todoappcomland`.

### Zagon aplikacije
Uporabite že dani migraciji:
1. `cd ToDoApp-BE`
2. Zaženite `dotnet restore`
3. Dodajte datoteko `appsettings.json` v korensko mapo in dodajte naslednjo vsebino:
   `json
   {
       "Logging": {
           "LogLevel": {
               "Default": "Information",
               "Microsoft.AspNetCore": "Warning"
           }
       },
       "ConnectionStrings": {
           "WebApiDatabase": "Host=localhost; Database=; Username=; Password=;"
       },
       "AllowedHosts": "*"
   }`
4. Zaženite `dotnet run`
5. Za izvrševanje migracij poženite `dotnet ef database update`

### Predpostavke
- Odločil sem se za uporabo vzorca `repository`, saj je učinkovit način za ločevanje skrbi (Separation of Concerns).
- Nisem implementiral brisanja za nobenega od modelov, saj to ni bilo navedeno v navodilih in ker način, kako so navodila opisala potek aplikacije, se mi ni zdelo potrebno.

### Kaj bi spremenil
- Implementiral bi testiranje enot.
- Spremenil bi, kako pošiljam podatke računa (priložil bi vse vrstice računa, ki mu pripadajo).
