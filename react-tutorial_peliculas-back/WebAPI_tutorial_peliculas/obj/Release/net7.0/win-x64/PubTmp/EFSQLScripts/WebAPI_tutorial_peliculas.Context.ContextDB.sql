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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [Actor] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Creation] datetime2 NOT NULL,
        [Update] datetime2 NOT NULL,
        [Biography] nvarchar(max) NULL,
        [PhotoURL] nvarchar(max) NULL,
        [Born] datetime2 NOT NULL,
        CONSTRAINT [PK_Actor] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [Cinema] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Creation] datetime2 NOT NULL,
        [Update] datetime2 NOT NULL,
        [Location] geography NULL,
        CONSTRAINT [PK_Cinema] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [Genre] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Creation] datetime2 NOT NULL,
        [Update] datetime2 NOT NULL,
        CONSTRAINT [PK_Genre] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [Movie] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Creation] datetime2 NOT NULL,
        [Update] datetime2 NOT NULL,
        [OnCinema] bit NOT NULL,
        [Premiere] datetime2 NOT NULL,
        [PosterURL] nvarchar(max) NULL,
        [Trailer] nvarchar(max) NULL,
        CONSTRAINT [PK_Movie] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [ActorMovie] (
        [ActorId] int NOT NULL,
        [MovieId] int NOT NULL,
        [Character] nvarchar(max) NULL,
        [Order] int NOT NULL,
        CONSTRAINT [PK_ActorMovie] PRIMARY KEY ([ActorId], [MovieId]),
        CONSTRAINT [FK_ActorMovie_Actor_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Actor] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ActorMovie_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [MovieCinema] (
        [MovieId] int NOT NULL,
        [CinemaId] int NOT NULL,
        CONSTRAINT [PK_MovieCinema] PRIMARY KEY ([MovieId], [CinemaId]),
        CONSTRAINT [FK_MovieCinema_Cinema_CinemaId] FOREIGN KEY ([CinemaId]) REFERENCES [Cinema] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieCinema_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [MovieGenre] (
        [MovieId] int NOT NULL,
        [GenreId] int NOT NULL,
        CONSTRAINT [PK_MovieGenre] PRIMARY KEY ([MovieId], [GenreId]),
        CONSTRAINT [FK_MovieGenre_Genre_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genre] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieGenre_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [Rating] (
        [Id] int NOT NULL IDENTITY,
        [Score] int NOT NULL,
        [MovieId] int NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Rating] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Rating_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Rating_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE TABLE [Review] (
        [Id] int NOT NULL IDENTITY,
        [Creation] datetime2 NOT NULL,
        [Update] datetime2 NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [Score] int NOT NULL,
        [MovieId] int NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_Review] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Review_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Review_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Biography', N'Born', N'Creation', N'Name', N'PhotoURL', N'Update') AND [object_id] = OBJECT_ID(N'[Actor]'))
        SET IDENTITY_INSERT [Actor] ON;
    EXEC(N'INSERT INTO [Actor] ([Id], [Biography], [Born], [Creation], [Name], [PhotoURL], [Update])
    VALUES (1, NULL, ''1962-01-17T00:00:00.0000000'', ''2023-09-16T19:47:48.5928750-03:00'', N''Jim Carrey'', N''https://www.gettyimages.com/photos/jim-carrey'', ''2023-09-16T19:47:48.5928750-03:00''),
    (2, NULL, ''1965-04-04T00:00:00.0000000'', ''2023-09-16T19:47:48.5928758-03:00'', N''Robert Downey Jr'', N''https://www.gettyimages.com/photos/robert-downey-jr'', ''2023-09-16T19:47:48.5928758-03:00''),
    (3, NULL, ''1981-06-13T00:00:00.0000000'', ''2023-09-16T19:47:48.5928761-03:00'', N''Chris Evans'', N''https://www.gettyimages.com/photos/chris-evans-robert-downey-jr'', ''2023-09-16T19:47:48.5928761-03:00''),
    (4, NULL, ''1975-06-04T00:00:00.0000000'', ''2023-09-16T19:47:48.5928763-03:00'', N''Angelina Jolie'', N''https://www.gettyimages.com/photos/angelina-jolie'', ''2023-09-16T19:47:48.5928763-03:00''),
    (5, NULL, ''1967-10-28T00:00:00.0000000'', ''2023-09-16T19:47:48.5928765-03:00'', N''Julia Roberts'', N''https://www.gettyimages.com/photos/julia-roberts'', ''2023-09-16T19:47:48.5928766-03:00''),
    (6, NULL, ''1990-07-02T00:00:00.0000000'', ''2023-09-16T19:47:48.5928767-03:00'', N''Margot Robbie'', N''https://www.gettyimages.com/photos/margot-robbie'', ''2023-09-16T19:47:48.5928768-03:00''),
    (7, NULL, ''1963-12-18T00:00:00.0000000'', ''2023-09-16T19:47:48.5928769-03:00'', N''Brad Pitt'', N''https://www.gettyimages.com/photos/brad-pitt'', ''2023-09-16T19:47:48.5928779-03:00''),
    (8, NULL, ''1974-04-28T00:00:00.0000000'', ''2023-09-16T19:47:48.5928790-03:00'', N''Penelope Cruz'', N''https://www.gettyimages.com/photos/penelope-cruz'', ''2023-09-16T19:47:48.5928790-03:00''),
    (9, NULL, ''1984-11-22T00:00:00.0000000'', ''2023-09-16T19:47:48.5928822-03:00'', N''Scarlett Johansson'', N''https://www.gettyimages.com/photos/scarlett-johansson'', ''2023-09-16T19:47:48.5928822-03:00''),
    (10, NULL, ''1986-05-16T00:00:00.0000000'', ''2023-09-16T19:47:48.5928824-03:00'', N''Megan Fox'', N''https://www.gettyimages.com/photos/megan-fox'', ''2023-09-16T19:47:48.5928825-03:00''),
    (11, NULL, ''1975-06-04T00:00:00.0000000'', ''2023-09-16T19:47:48.5928826-03:00'', N''Angelina Jolie'', N''https://www.gettyimages.com/photos/angelina-jolie'', ''2023-09-16T19:47:48.5928827-03:00''),
    (12, NULL, ''1969-02-11T00:00:00.0000000'', ''2023-09-16T19:47:48.5928828-03:00'', N''Jennifer Aniston'', N''https://www.gettyimages.com/photos/jennifer-aniston'', ''2023-09-16T19:47:48.5928829-03:00''),
    (13, NULL, ''1988-11-06T00:00:00.0000000'', ''2023-09-16T19:47:48.5928830-03:00'', N''Emma Stone'', N''https://www.gettyimages.com/photos/emma-stone'', ''2023-09-16T19:47:48.5928831-03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Biography', N'Born', N'Creation', N'Name', N'PhotoURL', N'Update') AND [object_id] = OBJECT_ID(N'[Actor]'))
        SET IDENTITY_INSERT [Actor] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''bef4cbd4-1f2b-472f-a1e2-e1a901f6808c'', NULL, N''Admin'', N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''c2ee6493-5a73-46f3-a3f2-46d1d11d7176'', 0, N''0008c700-0e36-4ff8-b59d-375e199f7234'', N''admin@testing.com'', CAST(0 AS bit), CAST(0 AS bit), NULL, N''admin@testing.com'', N''admin@testing.com'', N''AQAAAAIAAYagAAAAEAhoh7nykmiijA45NJ8HC+mEzv222dHU74FikamllwTLdRegA/lTC2bhBK78Tsxaqg=='', NULL, CAST(0 AS bit), N''92d0831d-1616-467b-a5db-3fce583e91ea'', CAST(0 AS bit), N''Sr.Admin''),
    (N''e0765c93-676c-4199-b7ee-d7877c471821'', 0, N''90e360ad-ce71-4d0e-b903-d7e2eea2530f'', N''user@testing.com'', CAST(0 AS bit), CAST(0 AS bit), NULL, N''user@testing.com'', N''user@testing.com'', N''AQAAAAIAAYagAAAAEPtFDvczry/ewvtUbUuyoFSUe0CBzOh+sgFLhfG/FY40GY5ylohAk494VQCDhu3RYA=='', NULL, CAST(0 AS bit), N''ed80218f-0709-4fcd-8c2f-01588effb33f'', CAST(0 AS bit), N''Sr.Normal'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Location', N'Name', N'Update') AND [object_id] = OBJECT_ID(N'[Cinema]'))
        SET IDENTITY_INSERT [Cinema] ON;
    EXEC(N'INSERT INTO [Cinema] ([Id], [Creation], [Location], [Name], [Update])
    VALUES (1, ''2023-09-16T19:47:48.5932064-03:00'', geography::Parse(''POINT (-56.13621764762051 -34.90292421243134)''), N''Moviecenter'', ''2023-09-16T19:47:48.5932071-03:00''),
    (2, ''2023-09-16T19:47:48.5932125-03:00'', geography::Parse(''POINT (-56.14677015960076 -34.90889872353638)''), N''LIFE Cinemas'', ''2023-09-16T19:47:48.5932125-03:00''),
    (3, ''2023-09-16T19:47:48.5932131-03:00'', geography::Parse(''POINT (-56.1566407649374 -34.91871301506793)''), N''Casablanca'', ''2023-09-16T19:47:48.5932131-03:00''),
    (4, ''2023-09-16T19:47:48.5932135-03:00'', geography::Parse(''POINT (-56.2010689038137 -34.90849834167495)''), N''Cinemateca'', ''2023-09-16T19:47:48.5932135-03:00''),
    (5, ''2023-09-16T19:47:48.5932139-03:00'', geography::Parse(''POINT (-56.15886454873049 -34.923823012219856)''), N''Punta Carretas Shopping'', ''2023-09-16T19:47:48.5932140-03:00''),
    (21, ''2023-09-16T19:47:48.5932184-03:00'', geography::Parse(''POINT (-56.164532 -34.901112)''), N''AMC Times Square'', ''2023-09-16T19:47:48.5932184-03:00''),
    (22, ''2023-09-16T19:47:48.5932189-03:00'', geography::Parse(''POINT (-56.168498 -34.914314)''), N''Regal LA Live'', ''2023-09-16T19:47:48.5932189-03:00''),
    (23, ''2023-09-16T19:47:48.5932192-03:00'', geography::Parse(''POINT (-56.18133 -34.905004)''), N''Cineplex Chicago'', ''2023-09-16T19:47:48.5932193-03:00''),
    (24, ''2023-09-16T19:47:48.5932197-03:00'', geography::Parse(''POINT (-56.153841 -34.920369)''), N''AMC Miami Beach'', ''2023-09-16T19:47:48.5932197-03:00''),
    (25, ''2023-09-16T19:47:48.5932201-03:00'', geography::Parse(''POINT (-56.150231 -34.916723)''), N''Cineworld Houston'', ''2023-09-16T19:47:48.5932201-03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Location', N'Name', N'Update') AND [object_id] = OBJECT_ID(N'[Cinema]'))
        SET IDENTITY_INSERT [Cinema] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Name', N'Update') AND [object_id] = OBJECT_ID(N'[Genre]'))
        SET IDENTITY_INSERT [Genre] ON;
    EXEC(N'INSERT INTO [Genre] ([Id], [Creation], [Name], [Update])
    VALUES (1, ''2023-09-16T19:47:48.5928581-03:00'', N''Aventura'', ''2023-09-16T19:47:48.5928622-03:00''),
    (2, ''2023-09-16T19:47:48.5928627-03:00'', N''Animación'', ''2023-09-16T19:47:48.5928628-03:00''),
    (3, ''2023-09-16T19:47:48.5928629-03:00'', N''Suspenso'', ''2023-09-16T19:47:48.5928629-03:00''),
    (4, ''2023-09-16T19:47:48.5928630-03:00'', N''Romance'', ''2023-09-16T19:47:48.5928631-03:00''),
    (5, ''2023-09-16T19:47:48.5928632-03:00'', N''Terror'', ''2023-09-16T19:47:48.5928632-03:00''),
    (6, ''2023-09-16T19:47:48.5928633-03:00'', N''Comedia'', ''2023-09-16T19:47:48.5928634-03:00''),
    (7, ''2023-09-16T19:47:48.5928635-03:00'', N''Sci-fi'', ''2023-09-16T19:47:48.5928636-03:00''),
    (8, ''2023-09-16T19:47:48.5928637-03:00'', N''Documental'', ''2023-09-16T19:47:48.5928637-03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Name', N'Update') AND [object_id] = OBJECT_ID(N'[Genre]'))
        SET IDENTITY_INSERT [Genre] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Description', N'OnCinema', N'PosterURL', N'Premiere', N'Title', N'Trailer', N'Update') AND [object_id] = OBJECT_ID(N'[Movie]'))
        SET IDENTITY_INSERT [Movie] ON;
    EXEC(N'INSERT INTO [Movie] ([Id], [Creation], [Description], [OnCinema], [PosterURL], [Premiere], [Title], [Trailer], [Update])
    VALUES (1, ''2023-09-16T19:47:48.5929011-03:00'', N''Un viaje interestelar en busca de un nuevo hogar para la humanidad.'', CAST(1 AS bit), N''https://m.media-amazon.com/images/I/A1JVqNMI7UL._AC_UF894,1000_QL80_.jpg'', ''2014-11-07T00:00:00.0000000'', N''Interstellar'', N''https://www.youtube.com/watch?v=2LqzF5WauAw'', ''2023-09-16T19:47:48.5929012-03:00''),
    (2, ''2023-09-16T19:47:48.5929019-03:00'', N''La vida de un hombre es un reality show televisado las 24 horas.'', CAST(1 AS bit), N''https://flxt.tmsimg.com/assets/p20974_p_v10_aq.jpg'', ''1998-06-05T00:00:00.0000000'', N''The Truman Show'', N''https://www.youtube.com/watch?v=dpDhYDiHxgU'', ''2023-09-16T19:47:48.5929019-03:00''),
    (3, ''2023-09-16T19:47:48.5929022-03:00'', N''Un adolescente viaja al pasado y al futuro en un DeLorean modificado.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/thumb/c/c2/Back_to_the_Future_Part_II.jpg/220px-Back_to_the_Future_Part_II.jpg'', ''1989-11-22T00:00:00.0000000'', N''Back to the future'', N''https://www.youtube.com/watch?v=qvsgGtivCgs'', ''2023-09-16T19:47:48.5929023-03:00''),
    (4, ''2023-09-16T19:47:48.5929025-03:00'', N''Agentes secretos protegen a la Tierra de amenazas extraterrestres.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/f/fb/Men_in_Black_Poster.jpg'', ''1997-07-02T00:00:00.0000000'', N''Men in black'', N''https://www.youtube.com/watch?v=UxUTTrU6PA4'', ''2023-09-16T19:47:48.5929025-03:00''),
    (5, ''2023-09-16T19:47:48.5929027-03:00'', N''Un payaso asesino siembra el terror en la noche de Halloween.'', CAST(1 AS bit), N''https://m.media-amazon.com/images/M/MV5BYmMxNzA0OTUtOTJiOS00NTc4LWJmNTItMGM3OWE0N2Y0NjhjXkEyXkFqcGdeQXVyMTg5NjU4NjE@._V1_FMjpg_UX1000_.jpg'', ''2018-03-15T00:00:00.0000000'', N''Terrifier'', N''https://www.youtube.com/watch?v=fN5j1MtGO2Q'', ''2023-09-16T19:47:48.5929028-03:00''),
    (6, ''2023-09-16T19:47:48.5929029-03:00'', N''Un grupo de amigos se ve atrapado en un festival pagano en Suecia.'', CAST(1 AS bit), N''https://grandillusioncinema.org/wp-content/uploads/2023/06/midsommar.jpg'', ''2019-07-03T00:00:00.0000000'', N''Midsommar'', N''https://www.youtube.com/watch?v=1Vnghdsjmd0'', ''2023-09-16T19:47:48.5929030-03:00''),
    (7, ''2023-09-16T19:47:48.5929032-03:00'', N''Una familia del siglo XVII enfrenta fuerzas sobrenaturales en su granja.'', CAST(1 AS bit), N''https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/The_Witch_poster.png/220px-The_Witch_poster.png'', ''2023-06-16T19:47:48.5929034-03:00'', N''The Witch'', N''https://www.youtube.com/watch?v=iQXmlf3Sefg'', ''2023-09-16T19:47:48.5929033-03:00''),
    (8, ''2023-09-16T19:47:48.5929044-03:00'', N''Dos investigadores paranormales toman un caso de posesión demoníaca.'', CAST(1 AS bit), N''https://upload.wikimedia.org/wikipedia/en/thumb/9/9b/The_Conjuring_The_Devil_Made_Me_Do_It_poster.jpeg/220px-The_Conjuring_The_Devil_Made_Me_Do_It_poster.jpeg'', ''2023-07-16T19:47:48.5929046-03:00'', N''The Conjuring: The Devil Made Me Do It'', N''https://www.youtube.com/watch?v=YDGw1MTEe9k'', ''2023-09-16T19:47:48.5929045-03:00''),
    (9, ''2023-09-16T19:47:48.5929047-03:00'', N''Una familia debe sobrevivir en un mundo invadido por criaturas que cazan por el sonido.'', CAST(1 AS bit), N''https://upload.wikimedia.org/wikipedia/en/thumb/a/a0/A_Quiet_Place_Part_II.jpeg/220px-A_Quiet_Place_Part_II.jpeg'', ''2023-05-16T19:47:48.5929049-03:00'', N''A Quiet Place Part II'', N''https://www.youtube.com/watch?v=XEMwSdne6UE'', ''2023-09-16T19:47:48.5929048-03:00''),
    (11, ''2023-09-16T19:47:48.5929050-03:00'', N''Un programador descubre que la realidad es una simulación creada por máquinas inteligentes.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg'', ''2003-09-16T19:47:48.5929052-03:00'', N''The Matrix'', N''https://www.youtube.com/watch?v=m8e-FF8MsqU'', ''2023-09-16T19:47:48.5929051-03:00''),
    (12, ''2023-09-16T19:47:48.5929054-03:00'', N''Un cazador de replicantes debe encontrar y ''''retirar'''' a cuatro androides que han regresado a la Tierra.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/5/53/Blade_Runner_poster.jpg'', ''1993-09-16T19:47:48.5929056-03:00'', N''Blade Runner'', N''https://www.youtube.com/watch?v=eogpIG53Cis'', ''2023-09-16T19:47:48.5929054-03:00''),
    (13, ''2023-09-16T19:47:48.5929057-03:00'', N''Un ladrón de sueños toma un último trabajo para implantar una idea en la mente de un ejecutivo.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg'', ''2013-09-16T19:47:48.5929059-03:00'', N''Inception'', N''https://www.youtube.com/watch?v=YoHD9XEInc0'', ''2023-09-16T19:47:48.5929058-03:00''),
    (14, ''2023-09-16T19:47:48.5929060-03:00'', N''Un androide asesino viaja al pasado para eliminar a la madre del líder de la resistencia humana.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/7/70/Terminator1984movieposter.jpg'', ''1983-09-16T19:47:48.5929062-03:00'', N''The Terminator'', N''https://www.youtube.com/watch?v=k64P4l2Wmeg'', ''2023-09-16T19:47:48.5929061-03:00''),
    (15, ''2023-09-16T19:47:48.5929063-03:00'', N''Un joven granjero se une a la rebelión para derrotar al malévolo Imperio Galáctico.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg'', ''1983-09-16T19:47:48.5929065-03:00'', N''Star Wars: Episode IV - A New Hope'', N''https://www.youtube.com/watch?v=vZ734NWnAHA'', ''2023-09-16T19:47:48.5929064-03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Description', N'OnCinema', N'PosterURL', N'Premiere', N'Title', N'Trailer', N'Update') AND [object_id] = OBJECT_ID(N'[Movie]'))
        SET IDENTITY_INSERT [Movie] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ActorId', N'MovieId', N'Character', N'Order') AND [object_id] = OBJECT_ID(N'[ActorMovie]'))
        SET IDENTITY_INSERT [ActorMovie] ON;
    EXEC(N'INSERT INTO [ActorMovie] ([ActorId], [MovieId], [Character], [Order])
    VALUES (1, 1, N''superhero'', 1),
    (1, 4, N''antagonist'', 2),
    (2, 1, N''supervillian'', 2),
    (2, 5, N''hero'', 1),
    (3, 2, N''main character'', 1),
    (3, 5, N''sidekick'', 2),
    (4, 2, N''supporting role'', 2),
    (5, 3, N''protagonist'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ActorId', N'MovieId', N'Character', N'Order') AND [object_id] = OBJECT_ID(N'[ActorMovie]'))
        SET IDENTITY_INSERT [ActorMovie] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
        SET IDENTITY_INSERT [AspNetUserClaims] ON;
    EXEC(N'INSERT INTO [AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId])
    VALUES (1, N''role'', N''admin'', N''c2ee6493-5a73-46f3-a3f2-46d1d11d7176'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
        SET IDENTITY_INSERT [AspNetUserClaims] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CinemaId', N'MovieId') AND [object_id] = OBJECT_ID(N'[MovieCinema]'))
        SET IDENTITY_INSERT [MovieCinema] ON;
    EXEC(N'INSERT INTO [MovieCinema] ([CinemaId], [MovieId])
    VALUES (1, 1),
    (2, 1),
    (1, 2),
    (2, 3),
    (3, 3),
    (4, 4),
    (1, 5),
    (5, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CinemaId', N'MovieId') AND [object_id] = OBJECT_ID(N'[MovieCinema]'))
        SET IDENTITY_INSERT [MovieCinema] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenreId', N'MovieId') AND [object_id] = OBJECT_ID(N'[MovieGenre]'))
        SET IDENTITY_INSERT [MovieGenre] ON;
    EXEC(N'INSERT INTO [MovieGenre] ([GenreId], [MovieId])
    VALUES (1, 1),
    (2, 1),
    (2, 2),
    (5, 2),
    (3, 3),
    (3, 4),
    (4, 4),
    (1, 5),
    (5, 5),
    (5, 6),
    (3, 8),
    (5, 8),
    (3, 9),
    (5, 9),
    (5, 11),
    (7, 11),
    (5, 12),
    (7, 12),
    (7, 13),
    (7, 14),
    (7, 15)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenreId', N'MovieId') AND [object_id] = OBJECT_ID(N'[MovieGenre]'))
        SET IDENTITY_INSERT [MovieGenre] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_ActorMovie_MovieId] ON [ActorMovie] ([MovieId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_MovieCinema_CinemaId] ON [MovieCinema] ([CinemaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_MovieGenre_GenreId] ON [MovieGenre] ([GenreId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_Rating_MovieId] ON [Rating] ([MovieId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_Rating_UserId] ON [Rating] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_Review_MovieId] ON [Review] ([MovieId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    CREATE INDEX [IX_Review_UserId] ON [Review] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230916224748_migracion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230916224748_migracion', N'7.0.10');
END;
GO

COMMIT;
GO

