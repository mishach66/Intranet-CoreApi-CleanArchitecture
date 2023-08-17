IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE TABLE [Cities] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Version] int NULL,
        [DateCreated] datetime2 NULL,
        [CreatedBy] uniqueidentifier NULL,
        [DateUpdated] datetime2 NULL,
        [UpdatedBy] uniqueidentifier NULL,
        [DateDeleted] datetime2 NULL,
        [DeletedBy] uniqueidentifier NULL,
        CONSTRAINT [PK_Cities] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE TABLE [News] (
        [Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Author] nvarchar(max) NOT NULL,
        [Date] datetime2 NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [Hyperlink] nvarchar(max) NOT NULL,
        [Version] int NULL,
        [DateCreated] datetime2 NULL,
        [CreatedBy] uniqueidentifier NULL,
        [DateUpdated] datetime2 NULL,
        [UpdatedBy] uniqueidentifier NULL,
        [DateDeleted] datetime2 NULL,
        [DeletedBy] uniqueidentifier NULL,
        CONSTRAINT [PK_News] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE TABLE [Sexes] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Version] int NULL,
        [DateCreated] datetime2 NULL,
        [CreatedBy] uniqueidentifier NULL,
        [DateUpdated] datetime2 NULL,
        [UpdatedBy] uniqueidentifier NULL,
        [DateDeleted] datetime2 NULL,
        [DeletedBy] uniqueidentifier NULL,
        CONSTRAINT [PK_Sexes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE TABLE [Vacancies] (
        [Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Author] nvarchar(max) NOT NULL,
        [PublicationDate] datetime2 NOT NULL,
        [JobDescripRequirement] nvarchar(max) NOT NULL,
        [Hyperlink] nvarchar(max) NOT NULL,
        [Deadline] datetime2 NOT NULL,
        [Version] int NULL,
        [DateCreated] datetime2 NULL,
        [CreatedBy] uniqueidentifier NULL,
        [DateUpdated] datetime2 NULL,
        [UpdatedBy] uniqueidentifier NULL,
        [DateDeleted] datetime2 NULL,
        [DeletedBy] uniqueidentifier NULL,
        CONSTRAINT [PK_Vacancies] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE TABLE [Branches] (
        [Id] uniqueidentifier NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [FullAddress] nvarchar(max) NOT NULL,
        [CityId] uniqueidentifier NOT NULL,
        [Version] int NULL,
        [DateCreated] datetime2 NULL,
        [CreatedBy] uniqueidentifier NULL,
        [DateUpdated] datetime2 NULL,
        [UpdatedBy] uniqueidentifier NULL,
        [DateDeleted] datetime2 NULL,
        [DeletedBy] uniqueidentifier NULL,
        CONSTRAINT [PK_Branches] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Branches_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE TABLE [Employees] (
        [Id] uniqueidentifier NOT NULL,
        [Givenname] nvarchar(max) NULL,
        [Surname] nvarchar(max) NULL,
        [IdNumber] nvarchar(max) NULL,
        [SurnameGivenname] nvarchar(max) NULL,
        [GivennameSurname] nvarchar(max) NULL,
        [DateOfBirth] datetime2 NULL,
        [Department] nvarchar(max) NULL,
        [Position] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [MobilePhone] nvarchar(max) NULL,
        [WorkPhone] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [AdditionalInfo] nvarchar(max) NULL,
        [ImageName] nvarchar(max) NULL,
        [CityId] uniqueidentifier NOT NULL,
        [SexId] uniqueidentifier NULL,
        [BranchId] uniqueidentifier NULL,
        [Version] int NULL,
        [DateCreated] datetime2 NULL,
        [CreatedBy] uniqueidentifier NULL,
        [DateUpdated] datetime2 NULL,
        [UpdatedBy] uniqueidentifier NULL,
        [DateDeleted] datetime2 NULL,
        [DeletedBy] uniqueidentifier NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Employees_Branches_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Branches] ([Id]),
        CONSTRAINT [FK_Employees_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]),
        CONSTRAINT [FK_Employees_Sexes_SexId] FOREIGN KEY ([SexId]) REFERENCES [Sexes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE INDEX [IX_Branches_CityId] ON [Branches] ([CityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE INDEX [IX_Employees_BranchId] ON [Employees] ([BranchId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE INDEX [IX_Employees_CityId] ON [Employees] ([CityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    CREATE INDEX [IX_Employees_SexId] ON [Employees] ([SexId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112103816_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230112103816_InitialCreate', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112120911_Languages')
BEGIN
    ALTER TABLE [Employees] ADD [Language] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112120911_Languages')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230112120911_Languages', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112121110_NullableLanguages')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'Language');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Employees] ALTER COLUMN [Language] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112121110_NullableLanguages')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230112121110_NullableLanguages', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230614115919_BranchDelete-Behavior')
BEGIN
    ALTER TABLE [Employees] DROP CONSTRAINT [FK_Employees_Branches_BranchId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230614115919_BranchDelete-Behavior')
BEGIN
    ALTER TABLE [Employees] ADD CONSTRAINT [FK_Employees_Branches_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Branches] ([Id]) ON DELETE SET NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230614115919_BranchDelete-Behavior')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230614115919_BranchDelete-Behavior', N'7.0.1');
END;
GO

COMMIT;
GO

