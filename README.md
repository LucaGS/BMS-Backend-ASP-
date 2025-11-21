# DotNet8.ScalarWebApi

 ASP.NET Core 8 Web API for BMS with JWT auth, green area/tree management, inspections, and image storage. The solution includes `DotNet8.ScalarWebApi.Tests` for both unit and lightweight integration coverage.

## Business Services
- `AuthService`: register/login with hashed passwords and JWT issuance.
- `CurrentUserService`: extracts user id/identity state from the current HTTP context.
- `GreenAreaService`: create and list green areas scoped to the requesting user.
- `TreeService`: prevent duplicate tree numbers per user, create trees, and query by user/green area.
- `InspectionService`: create inspections and link them to trees.
- `ImageService`: store and retrieve tree images.

## Testing
- Unit + integration tests live in `DotNet8.ScalarWebApi.Tests`. They use EF Core InMemory and `WebApplicationFactory` for API-level checks.
- Run all tests: `dotnet test`
- Key coverage:
  - Auth token includes user id claim and endpoints behave (POST-only login).
  - Services cover green area creation/filtering, tree uniqueness, inspection creation/validation, image retrieval, and current user resolution.

## Notes
- Test isolation relies on unique in-memory DB names; no external dependencies required.
﻿
