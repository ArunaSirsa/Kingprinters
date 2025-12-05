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

CREATE TABLE [Staffs] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [State] nvarchar(max) NULL,
    [Pin] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [Business] nvarchar(max) NULL,
    [GST] nvarchar(max) NULL,
    [Bank] nvarchar(max) NULL,
    [Branch] nvarchar(max) NULL,
    [IFSC] nvarchar(max) NULL,
    [AccountNo] nvarchar(max) NULL,
    CONSTRAINT [PK_Staffs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251103054631_InitialCreate', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Staffs] ADD [Password] nvarchar(max) NULL;
GO

ALTER TABLE [Staffs] ADD [Username] nvarchar(max) NULL;
GO

ALTER TABLE [Staffs] ADD [stafftype] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251103061340_Updatestaff', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [PaperQualities] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_PaperQualities] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [States] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [CourierPrices] (
    [Id] int NOT NULL IDENTITY,
    [PaperQualityId] int NOT NULL,
    [Quantity] int NOT NULL,
    [StateId] int NOT NULL,
    [Rate] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_CourierPrices] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CourierPrices_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [States] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_CourierPrices_StateId] ON [CourierPrices] ([StateId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251103094119_CreateStateandpaperandcouries', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251104053425_cate', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Subcategories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Type] nvarchar(max) NOT NULL,
    [Lamination] nvarchar(max) NOT NULL,
    [UVOption] nvarchar(max) NOT NULL,
    [FoilOption] nvarchar(max) NOT NULL,
    [DieCutOption] nvarchar(max) NOT NULL,
    [ProductionTime] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Subcategories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Subcategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Subcategories_CategoryId] ON [Subcategories] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251104060936_subcat', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [States] ADD [status] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Staffs] ADD [status] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [CourierPrices] ADD [status] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Categories] ADD [Status] nvarchar(max) NOT NULL DEFAULT N'';
GO

CREATE INDEX [IX_CourierPrices_PaperQualityId] ON [CourierPrices] ([PaperQualityId]);
GO

ALTER TABLE [CourierPrices] ADD CONSTRAINT [FK_CourierPrices_PaperQualities_PaperQualityId] FOREIGN KEY ([PaperQualityId]) REFERENCES [PaperQualities] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251109150233_add-migration status', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251109155810_alltable', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[States]') AND [c].[name] = N'status');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [States] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [States] DROP COLUMN [status];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Staffs]') AND [c].[name] = N'status');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Staffs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Staffs] DROP COLUMN [status];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourierPrices]') AND [c].[name] = N'status');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [CourierPrices] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [CourierPrices] DROP COLUMN [status];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'Status');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Categories] DROP COLUMN [Status];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251109155950_stt', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251109160050_stcat', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251109160315_fg', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [CourierPrices] ADD [status] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251109160547_df', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [States] ADD [status] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Staffs] ADD [status] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Categories] ADD [status] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251109160824_hj', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Subcategories] ADD [status] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251109161056_jk', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Subcategories] ADD [ItemId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Categories] ADD [ItemId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Items] (
    [Id] int NOT NULL IDENTITY,
    [ItemName] nvarchar(max) NOT NULL,
    [status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Subcategories_ItemId] ON [Subcategories] ([ItemId]);
GO

CREATE INDEX [IX_Categories_ItemId] ON [Categories] ([ItemId]);
GO

ALTER TABLE [Categories] ADD CONSTRAINT [FK_Categories_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Subcategories] ADD CONSTRAINT [FK_Subcategories_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251111061432_item', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subcategories]') AND [c].[name] = N'Description');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Subcategories] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Subcategories] DROP COLUMN [Description];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subcategories]') AND [c].[name] = N'DieCutOption');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Subcategories] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Subcategories] DROP COLUMN [DieCutOption];
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subcategories]') AND [c].[name] = N'FoilOption');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Subcategories] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Subcategories] DROP COLUMN [FoilOption];
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subcategories]') AND [c].[name] = N'Lamination');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Subcategories] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Subcategories] DROP COLUMN [Lamination];
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subcategories]') AND [c].[name] = N'ProductionTime');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Subcategories] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Subcategories] DROP COLUMN [ProductionTime];
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subcategories]') AND [c].[name] = N'Type');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Subcategories] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Subcategories] DROP COLUMN [Type];
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subcategories]') AND [c].[name] = N'UVOption');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Subcategories] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Subcategories] DROP COLUMN [UVOption];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251111064725_lo', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Subcategories] DROP CONSTRAINT [FK_Subcategories_Items_ItemId];
GO

DROP INDEX [IX_Subcategories_ItemId] ON [Subcategories];
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subcategories]') AND [c].[name] = N'ItemId');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Subcategories] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Subcategories] DROP COLUMN [ItemId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251111065411_vb', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Categories] DROP CONSTRAINT [FK_Categories_Items_ItemId];
GO

DROP INDEX [IX_Categories_ItemId] ON [Categories];
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'ItemId');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Categories] DROP COLUMN [ItemId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251111065455_tg', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251111065908_er', N'6.0.0');
GO

COMMIT;
GO

