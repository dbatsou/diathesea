# Updating the database

Add / Remove entities and create a new migration using the following command (make sure you are at the root folder of the solution)

dotnet ef migrations add <MigrationName> -p Storage/ -s API/ 