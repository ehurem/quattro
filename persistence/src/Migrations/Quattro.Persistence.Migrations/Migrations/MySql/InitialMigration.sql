  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE TABLE `Employees` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `FirstName` text NULL,
        `LastName` text NULL,
        `UserId` int NOT NULL,
        `Phone` text NULL,
        `ImageUrl` text NULL,
        `Birthday` datetime NULL,
        `StartDate` datetime NOT NULL,
        `EndDate` datetime NULL,
        `ManagerId` int NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Employees_Employees_ManagerId` FOREIGN KEY (`ManagerId`) REFERENCES `Employees` (`Id`) ON DELETE RESTRICT
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE TABLE `Roles` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Name` text NULL,
        `Description` text NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE TABLE `Scopes` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Name` text NULL,
        `Description` text NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE TABLE `Statuses` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Name` text NULL,
        `Description` text NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE TABLE `RoleScope` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `RoleId` int NOT NULL,
        `ScopeId` int NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_RoleScope_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_RoleScope_Scopes_ScopeId` FOREIGN KEY (`ScopeId`) REFERENCES `Scopes` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE TABLE `Users` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Email` text NULL,
        `Username` text NULL,
        `Password` text NULL,
        `ProfileId` int NOT NULL,
        `StatusId` int NOT NULL,
        `ProfileId1` int NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Users_Employees_ProfileId1` FOREIGN KEY (`ProfileId1`) REFERENCES `Employees` (`Id`) ON DELETE RESTRICT,
        CONSTRAINT `FK_Users_Statuses_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `Statuses` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE TABLE `TimeClocks` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `UserId` int NOT NULL,
        `StartDate` datetime NOT NULL,
        `Description` text NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_TimeClocks_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE TABLE `UserRole` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `UserId` int NOT NULL,
        `RoleId` int NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_UserRole_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_UserRole_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE INDEX `IX_Employees_ManagerId` ON `Employees` (`ManagerId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE INDEX `IX_RoleScope_RoleId` ON `RoleScope` (`RoleId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE INDEX `IX_RoleScope_ScopeId` ON `RoleScope` (`ScopeId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE INDEX `IX_TimeClocks_UserId` ON `TimeClocks` (`UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE INDEX `IX_UserRole_RoleId` ON `UserRole` (`RoleId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE INDEX `IX_UserRole_UserId` ON `UserRole` (`UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE INDEX `IX_Users_ProfileId1` ON `Users` (`ProfileId1`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    CREATE INDEX `IX_Users_StatusId` ON `Users` (`StatusId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190713183330_InitialMigration')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20190713183330_InitialMigration', '2.2.4-servicing-10062');
END;

