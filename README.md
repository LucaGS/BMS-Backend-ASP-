# BMS Backend API (.NET 8)
Backend fuer ein Baum-Management-System mit JWT-gesicherter REST-API, Domain-Modell fuer Gruenflaechen/Baeume/Inspektionen/Bilder und sauberem Testing-Setup.

## Was Arbeitgeber hier sehen
- Mehrmandantenfaehige Domaene: Alle Entities sind an den angemeldeten User gebunden (`CurrentUserService`, Controller-Guards via JWT).
- Datenhaltung: EF Core, InMemory-DB fuer lokale Entwicklung; PostgreSQL + automatische Migrationen fuer Stage/Prod.
- Validierte Fachlogik: Keine doppelten Baum-Nummern pro User (`Tree` Index, `TreeService`), Inspektionen inkl. Krone/Stamm/Wurzelbereich und Folge-Intervall.
- API-Oberflaeche: Swagger/Scalar im Dev-Modus, wohldefinierte Controller fuer Auth, Gruenflaechen, Baeume, Inspektionen, Bilder und baumpflegerische Massnahmen.
- Tests als Sicherheitsnetz: Unit- und Integrationstests pruefen Auth-Flow, Services und Endpunkte mit `WebApplicationFactory` und EF InMemory.

## Architektur in Kurzform
- Einstieg: `Program.cs` richtet Controller, CORS, JWT-Validation, DB-Kontext und Auto-Migrationen (nur echte DB) ein.
- Domaene: `Entities/` modelliert Baeume (inkl. Geo/Fachdaten), Inspektionen mit Teilpruefungen, Bilder und Massnahmen.
- Services: `AuthService`, `GreenAreaService`, `TreeService`, `InspectionService`, `ImageService`, `ArboriculturalMeasuresService` kapseln Fachlogik und User-Scoping.
- Controller: CRUD-Endpunkte unter `Controllers/` mit Pfaden wie `api/Trees/Create`, `api/Inspections/ByTreeId/{id}`, `api/Images/GetImages/{treeId}`.
- Datenzugriff: `Data/AppDbContext` mit EF Core; Index auf (`UserId`, `Number`) bei `Tree` verhindert Nummern-Duplikate pro Nutzer.

## Setup & Run
Voraussetzungen: .NET 8 SDK, optional PostgreSQL.

Lokales Dev (InMemory-DB):
1. `dotnet restore`
2. `dotnet run`
3. Swagger/Scalar-Doku im Dev-Modus unter `/openapi/v1.json` bzw. UI ueber Scalar.

Stage/Prod mit PostgreSQL:
1. Environment setzen: `PGHOST`, `PGPORT`, `PGDATABASE`, `PGUSER`, `POSTGRES_PASSWORD`. Optional `CORS_ALLOWED_ORIGINS` fuer Frontends.
2. `ASPNETCORE_ENVIRONMENT=Production` (Migrationen laufen beim Start).
3. `dotnet run`

Auth nutzen:
1. `POST /api/Auth/Register` mit `Username`, `Password`, `Email`.
2. `POST /api/Auth/Login` -> JWT aus `token` nehmen und als `Authorization: Bearer <token>` fuer geschuetzte Endpunkte senden.

## Tests
- Alle Tests: `dotnet test`
- Abdeckung: Token-Handling und HTTP-Methoden-Guarding (`AuthEndpointTests`), Benutzerkontext (`CurrentUserServiceTests`), Gruenflaechen/Baeume/Inspektionen/Bilder/Massnahmen-Services (inkl. Konflikt- und Besitz-Pruefungen), InMemory-Kontext-Isolation.

## API-Schwerpunkte
- Gruenflaechen: Anlegen, Listen, Aktualisieren, Loeschen pro Nutzer.
- Baeume: Nummern-Validierung pro User, Filter nach Gruenflaeche, letzter erstellter Baum, vollstaendige Update- und Delete-Pfade.
- Inspektionen: Erstellen mit Teilpruefungen (Krone/Stamm/Wurzel), Intervall-Planung, CRUD pro Baum/User.
- Bilder: Hochladen, Listen, Update, Delete pro Baum/User.
- Massnahmen: CRUD fuer baumpflegerische Massnahmen auf Inspektionen.
