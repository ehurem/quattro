
# DatabaseType supported values: MySql, SqlServer, Sqlite. If not provided then default is used (MySql)
# UpdateDatabase flag indicates whether to apply new migration or not
# If previous migration is specified then the sql script generated will contain only the difference between new migration and old one.

# Usages: 
#           ./migrations.ps1 -currentMigration MyNewMigration -previousMigration MyOldMigration -databaseType mysql -updateDatabase $true
#           ./migrations.ps1 -currentMigration InitialMigration -databaseType mysql -updateDatabase $true
#           ./migrations.ps1 -currentMigration InitialMigration
# If no params are specified then defaults are used:
#   - CurrentMigration = 'Migration_{RandomNumber}'
#   - PreviousMigration = null
#   - DatabaseType = mysql   
#   - UpdateDatabase = true

param(
    [String]$currentMigration,
    [String]$previousMigration = $null,
    [String]$databaseType = $null,
    [Boolean]$updateDatabase = $true
)

If($databaseType -eq "" -and $databaseType -eq [String]::Empty) {
    $databaseType = "mysql"
}

$databaseType = $databaseType.ToLower()

If($currentMigration -eq "" -and $currentMigration -eq [String]::Empty) {
    $randomRange = 100000..999999
    $randomNumber = Get-Random -InputObject $randomRange
    $currentMigration = "Migration_$randomNumber"
}

$migrationPath = $null
$dbContext = $null
$migrationProject = $null
$migrationOutputDirectory = $null

If($databaseType -eq "sqlserver") {
    $migrationPath = ".\Quattro.Persistence.Migrations\Migrations\SqlServer"
    $dbContext = "QuattroDbContext"
    $migrationProject = ".\Quattro.Persistence.Migrations"
    $migrationOutputDirectory = ".\Migrations\SqlServer"
}
ElseIf($databaseType -eq "mysql") {
    $migrationPath = ".\Quattro.Persistence.Migrations\Migrations\MySql"
    $dbContext = "QuattroMySqlContext"
    $migrationProject = ".\Quattro.Persistence.Migrations"
    $migrationOutputDirectory = ".\Migrations\MySql"
}
ElseIf($databaseType -eq "sqlite") {
    $migrationPath = ".\Quattro.Persistence.Migrations\Migrations\SQLite"
    $dbContext = "QuattroSQLiteContext"
    $migrationProject = ".\Quattro.Persistence.Migrations"
    $migrationOutputDirectory = ".\Migrations\SQLite"
}

$addMigrationCommand = "dotnet ef migrations add $currentMigration --context $dbContext --project $migrationProject --output-dir $migrationOutputDirectory --verbose"
$updateDbCommand = "dotnet ef database update $currentMigration --project $migrationProject --context $dbContext --verbose"

If($previousMigration -eq "" -and $previousMigration -eq [String]::Empty) {
    $createScriptCommand = "dotnet ef migrations script --context $dbContext --project $migrationProject -o '$migrationPath\$currentMigration.sql' --idempotent --verbose"
} Else {
    $createScriptCommand = "dotnet ef migrations script $previousMigration $currentMigration --context $dbContext --project $migrationProject -o '$migrationPath\$currentMigration.sql' --idempotent --verbose"
}

iex $addMigrationCommand
iex $createScriptCommand

If($updateDatabase -eq $true) {
    iex $updateDbCommand
}