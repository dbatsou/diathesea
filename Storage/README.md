# Updating the database

Add / Remove entities and create a new migration using the following command (make sure you are at the root folder of the solution)

dotnet ef migrations add <MigrationName> -p Storage/ -s API/

#SQLite

By default SQLite does not enforce foreign key constraint, if browsing the db
PRAGMA foreign_keys = ON; needs to be run to enforce

also it can be enforced via the connection string by appending ;foreign keys=true;
