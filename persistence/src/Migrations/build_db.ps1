
# DatabaseType supported values: MySql, SqlServer, Sqlite. If not provided then default is used (mysql)
param(
    [String]$databaseType = $null,
    [String]$migrationName = $null,
    [Boolean]$dropDatabase = $true,
    [Boolean]$applyMigration = $true
)

If($databaseType -eq "" -and $databaseType -eq [String]::Empty) {
    $databaseType = "mysql"
}

$databaseType = $databaseType.ToLower()

If($migrationName -eq "" -and $migrationName -eq [String]::Empty) {
    $migrationName = "InitialMigration"
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

If(Test-Path $migrationPath) {
    Remove-Item -LiteralPath $migrationPath -Force -Recurse
}

$dropDatabaseCommand = "dotnet ef database drop --context $dbContext --project $migrationProject"
$addMigrationCommand = "dotnet ef migrations add $migrationName --context $dbContext --project $migrationProject --output-dir $migrationOutputDirectory"
$updateDbCommand = "dotnet ef database update --project $migrationProject --context $dbContext"
$createScriptCommand = "dotnet ef migrations script --context $dbContext --project $migrationProject -o '$migrationPath\$migrationName.sql' --idempotent"

If($dropDatabase -eq $true) {
    iex $dropDatabaseCommand
}

iex $addMigrationCommand
iex $createScriptCommand

If($applyMigration -eq $true) {
    iex $updateDbCommand
}
