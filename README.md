# diathesea

# Build Status

.NET

![example workflow](https://github.com/dbatsou/diathesea/actions/workflows/dotnet.yml/badge.svg)

# Application Settings

DevOptions:DeleteAndRecreateDBOnStartup : bool, Delete and recreate the database file (if one exists)

# Database Providers

The database provider can be set via the ConnectionStrings object in appsettings.json

Supported:

| Name                       | Requirement                                           |
| -------------------------- | ----------------------------------------------------- |
| SQLite                     | Set ConnectionStrings:SQLite to the connection string |
| InMemory (testing purpose) | Set ConnectionStrings:UseInMemory to "true"           |
