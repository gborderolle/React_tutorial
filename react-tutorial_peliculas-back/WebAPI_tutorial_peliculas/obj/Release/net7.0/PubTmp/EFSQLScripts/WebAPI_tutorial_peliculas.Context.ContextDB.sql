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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Biography', N'Born', N'Creation', N'Name', N'PhotoURL', N'Update') AND [object_id] = OBJECT_ID(N'[Actor]'))
        SET IDENTITY_INSERT [Actor] ON;
    EXEC(N'INSERT INTO [Actor] ([Id], [Biography], [Born], [Creation], [Name], [PhotoURL], [Update])
    VALUES (1, NULL, ''1962-01-17T00:00:00.0000000'', ''2023-09-08T21:54:40.4400535-03:00'', N''Jim Carrey'', N''https://www.gettyimages.com/photos/jim-carrey'', ''2023-09-08T21:54:40.4400536-03:00''),
    (2, NULL, ''1965-04-04T00:00:00.0000000'', ''2023-09-08T21:54:40.4400540-03:00'', N''Robert Downey Jr'', N''https://www.gettyimages.com/photos/robert-downey-jr'', ''2023-09-08T21:54:40.4400540-03:00''),
    (3, NULL, ''1981-06-13T00:00:00.0000000'', ''2023-09-08T21:54:40.4400542-03:00'', N''Chris Evans'', N''https://www.gettyimages.com/photos/chris-evans-robert-downey-jr'', ''2023-09-08T21:54:40.4400542-03:00''),
    (4, NULL, ''1975-06-04T00:00:00.0000000'', ''2023-09-08T21:54:40.4400543-03:00'', N''Angelina Jolie'', N''https://www.gettyimages.com/photos/angelina-jolie'', ''2023-09-08T21:54:40.4400544-03:00''),
    (5, NULL, ''1967-10-28T00:00:00.0000000'', ''2023-09-08T21:54:40.4400545-03:00'', N''Julia Roberts'', N''https://www.gettyimages.com/photos/julia-roberts'', ''2023-09-08T21:54:40.4400545-03:00''),
    (6, NULL, ''1990-07-02T00:00:00.0000000'', ''2023-09-08T21:54:40.4400546-03:00'', N''Margot Robbie'', N''https://www.gettyimages.com/photos/margot-robbie'', ''2023-09-08T21:54:40.4400547-03:00''),
    (7, NULL, ''1963-12-18T00:00:00.0000000'', ''2023-09-08T21:54:40.4400548-03:00'', N''Brad Pitt'', N''https://www.gettyimages.com/photos/brad-pitt'', ''2023-09-08T21:54:40.4400564-03:00''),
    (8, NULL, ''1974-04-28T00:00:00.0000000'', ''2023-09-08T21:54:40.4400582-03:00'', N''Penelope Cruz'', N''https://www.gettyimages.com/photos/penelope-cruz'', ''2023-09-08T21:54:40.4400582-03:00''),
    (9, NULL, ''1984-11-22T00:00:00.0000000'', ''2023-09-08T21:54:40.4400583-03:00'', N''Scarlett Johansson'', N''https://www.gettyimages.com/photos/scarlett-johansson'', ''2023-09-08T21:54:40.4400584-03:00''),
    (10, NULL, ''1986-05-16T00:00:00.0000000'', ''2023-09-08T21:54:40.4400585-03:00'', N''Megan Fox'', N''https://www.gettyimages.com/photos/megan-fox'', ''2023-09-08T21:54:40.4400587-03:00''),
    (11, NULL, ''1975-06-04T00:00:00.0000000'', ''2023-09-08T21:54:40.4400588-03:00'', N''Angelina Jolie'', N''https://www.gettyimages.com/photos/angelina-jolie'', ''2023-09-08T21:54:40.4400589-03:00''),
    (12, NULL, ''1969-02-11T00:00:00.0000000'', ''2023-09-08T21:54:40.4400590-03:00'', N''Jennifer Aniston'', N''https://www.gettyimages.com/photos/jennifer-aniston'', ''2023-09-08T21:54:40.4400591-03:00''),
    (13, NULL, ''1988-11-06T00:00:00.0000000'', ''2023-09-08T21:54:40.4400592-03:00'', N''Emma Stone'', N''https://www.gettyimages.com/photos/emma-stone'', ''2023-09-08T21:54:40.4400593-03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Biography', N'Born', N'Creation', N'Name', N'PhotoURL', N'Update') AND [object_id] = OBJECT_ID(N'[Actor]'))
        SET IDENTITY_INSERT [Actor] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''bef4cbd4-1f2b-472f-a1e2-e1a901f6808c'', NULL, N''Admin'', N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''c2ee6493-5a73-46f3-a3f2-46d1d11d7176'', 0, N''6a918447-ae55-41a4-bafe-8c5a66850618'', N''admin@testing.com'', CAST(0 AS bit), CAST(0 AS bit), NULL, N''admin@testing.com'', N''admin@testing.com'', N''AQAAAAIAAYagAAAAEOWOPHfI51qfO0s1H3hQ/tAFuG6k3Y3isnhrmTH+bZrKRkkc/MoakXiGAlbGa3AVbA=='', NULL, CAST(0 AS bit), N''79828cae-02bb-40c0-bcba-96fc231d3682'', CAST(0 AS bit), N''admin@testing.com''),
    (N''e0765c93-676c-4199-b7ee-d7877c471821'', 0, N''f26daae1-f9af-492b-8449-905012801675'', N''user@testing.com'', CAST(0 AS bit), CAST(0 AS bit), NULL, N''user@testing.com'', N''user@testing.com'', N''AQAAAAIAAYagAAAAEDEY/EXTYq1qfTWu6csLPdWpEg1N9a1nvgvYULFlIo25GJAEQm/+0/Hk70PVoaOe+g=='', NULL, CAST(0 AS bit), N''6d6329d5-2d59-4599-8772-d38e4d9a46a7'', CAST(0 AS bit), N''user@testing.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Location', N'Name', N'Update') AND [object_id] = OBJECT_ID(N'[Cinema]'))
        SET IDENTITY_INSERT [Cinema] ON;
    EXEC(N'INSERT INTO [Cinema] ([Id], [Creation], [Location], [Name], [Update])
    VALUES (1, ''2023-09-08T21:54:40.4403440-03:00'', geography::Parse(''POINT (-56.13621764762051 -34.90292421243134)''), N''Moviecenter'', ''2023-09-08T21:54:40.4403444-03:00''),
    (2, ''2023-09-08T21:54:40.4403482-03:00'', geography::Parse(''POINT (-56.14677015960076 -34.90889872353638)''), N''LIFE Cinemas'', ''2023-09-08T21:54:40.4403482-03:00''),
    (3, ''2023-09-08T21:54:40.4403486-03:00'', geography::Parse(''POINT (-56.1566407649374 -34.91871301506793)''), N''Casablanca'', ''2023-09-08T21:54:40.4403487-03:00''),
    (4, ''2023-09-08T21:54:40.4403493-03:00'', geography::Parse(''POINT (-56.2010689038137 -34.90849834167495)''), N''Cinemateca'', ''2023-09-08T21:54:40.4403493-03:00''),
    (5, ''2023-09-08T21:54:40.4403496-03:00'', geography::Parse(''POINT (-56.15886454873049 -34.923823012219856)''), N''Punta Carretas Shopping'', ''2023-09-08T21:54:40.4403496-03:00''),
    (21, ''2023-09-08T21:54:40.4403508-03:00'', geography::Parse(''POINT (-56.164532 -34.901112)''), N''AMC Times Square'', ''2023-09-08T21:54:40.4403508-03:00''),
    (22, ''2023-09-08T21:54:40.4403511-03:00'', geography::Parse(''POINT (-56.168498 -34.914314)''), N''Regal LA Live'', ''2023-09-08T21:54:40.4403511-03:00''),
    (23, ''2023-09-08T21:54:40.4403515-03:00'', geography::Parse(''POINT (-56.18133 -34.905004)''), N''Cineplex Chicago'', ''2023-09-08T21:54:40.4403515-03:00''),
    (24, ''2023-09-08T21:54:40.4403517-03:00'', geography::Parse(''POINT (-56.153841 -34.920369)''), N''AMC Miami Beach'', ''2023-09-08T21:54:40.4403518-03:00''),
    (25, ''2023-09-08T21:54:40.4403521-03:00'', geography::Parse(''POINT (-56.150231 -34.916723)''), N''Cineworld Houston'', ''2023-09-08T21:54:40.4403522-03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Location', N'Name', N'Update') AND [object_id] = OBJECT_ID(N'[Cinema]'))
        SET IDENTITY_INSERT [Cinema] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Name', N'Update') AND [object_id] = OBJECT_ID(N'[Genre]'))
        SET IDENTITY_INSERT [Genre] ON;
    EXEC(N'INSERT INTO [Genre] ([Id], [Creation], [Name], [Update])
    VALUES (1, ''2023-09-08T21:54:40.4400301-03:00'', N''Aventura'', ''2023-09-08T21:54:40.4400330-03:00''),
    (2, ''2023-09-08T21:54:40.4400330-03:00'', N''Animación'', ''2023-09-08T21:54:40.4400331-03:00''),
    (3, ''2023-09-08T21:54:40.4400331-03:00'', N''Suspenso'', ''2023-09-08T21:54:40.4400332-03:00''),
    (4, ''2023-09-08T21:54:40.4400332-03:00'', N''Romance'', ''2023-09-08T21:54:40.4400333-03:00''),
    (5, ''2023-09-08T21:54:40.4400334-03:00'', N''Terror'', ''2023-09-08T21:54:40.4400334-03:00''),
    (6, ''2023-09-08T21:54:40.4400335-03:00'', N''Comedia'', ''2023-09-08T21:54:40.4400335-03:00''),
    (7, ''2023-09-08T21:54:40.4400336-03:00'', N''Sci-fi'', ''2023-09-08T21:54:40.4400337-03:00''),
    (8, ''2023-09-08T21:54:40.4400338-03:00'', N''Documental'', ''2023-09-08T21:54:40.4400338-03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Name', N'Update') AND [object_id] = OBJECT_ID(N'[Genre]'))
        SET IDENTITY_INSERT [Genre] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Description', N'OnCinema', N'PosterURL', N'Premiere', N'Title', N'Trailer', N'Update') AND [object_id] = OBJECT_ID(N'[Movie]'))
        SET IDENTITY_INSERT [Movie] ON;
    EXEC(N'INSERT INTO [Movie] ([Id], [Creation], [Description], [OnCinema], [PosterURL], [Premiere], [Title], [Trailer], [Update])
    VALUES (1, ''2023-09-08T21:54:40.4401057-03:00'', N''Un viaje interestelar en busca de un nuevo hogar para la humanidad.'', CAST(1 AS bit), N''https://m.media-amazon.com/images/I/A1JVqNMI7UL._AC_UF894,1000_QL80_.jpg'', ''2014-11-07T00:00:00.0000000'', N''Interstellar'', N''https://www.youtube.com/watch?v=2LqzF5WauAw'', ''2023-09-08T21:54:40.4401064-03:00''),
    (2, ''2023-09-08T21:54:40.4401068-03:00'', N''La vida de un hombre es un reality show televisado las 24 horas.'', CAST(1 AS bit), N''https://flxt.tmsimg.com/assets/p20974_p_v10_aq.jpg'', ''1998-06-05T00:00:00.0000000'', N''The Truman Show'', N''https://www.youtube.com/watch?v=dpDhYDiHxgU'', ''2023-09-08T21:54:40.4401068-03:00''),
    (3, ''2023-09-08T21:54:40.4401069-03:00'', N''Un adolescente viaja al pasado y al futuro en un DeLorean modificado.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/thumb/c/c2/Back_to_the_Future_Part_II.jpg/220px-Back_to_the_Future_Part_II.jpg'', ''1989-11-22T00:00:00.0000000'', N''Back to the future'', N''https://www.youtube.com/watch?v=qvsgGtivCgs'', ''2023-09-08T21:54:40.4401070-03:00''),
    (4, ''2023-09-08T21:54:40.4401072-03:00'', N''Agentes secretos protegen a la Tierra de amenazas extraterrestres.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/f/fb/Men_in_Black_Poster.jpg'', ''1997-07-02T00:00:00.0000000'', N''Men in black'', N''https://www.youtube.com/watch?v=UxUTTrU6PA4'', ''2023-09-08T21:54:40.4401072-03:00''),
    (5, ''2023-09-08T21:54:40.4401073-03:00'', N''Un payaso asesino siembra el terror en la noche de Halloween.'', CAST(1 AS bit), N''https://m.media-amazon.com/images/M/MV5BYmMxNzA0OTUtOTJiOS00NTc4LWJmNTItMGM3OWE0N2Y0NjhjXkEyXkFqcGdeQXVyMTg5NjU4NjE@._V1_FMjpg_UX1000_.jpg'', ''2018-03-15T00:00:00.0000000'', N''Terrifier'', N''https://www.youtube.com/watch?v=fN5j1MtGO2Q'', ''2023-09-08T21:54:40.4401074-03:00''),
    (6, ''2023-09-08T21:54:40.4401075-03:00'', N''Un grupo de amigos se ve atrapado en un festival pagano en Suecia.'', CAST(1 AS bit), N''https://grandillusioncinema.org/wp-content/uploads/2023/06/midsommar.jpg'', ''2019-07-03T00:00:00.0000000'', N''Midsommar'', N''https://www.youtube.com/watch?v=1Vnghdsjmd0'', ''2023-09-08T21:54:40.4401075-03:00''),
    (7, ''2023-09-08T21:54:40.4401077-03:00'', N''Una familia del siglo XVII enfrenta fuerzas sobrenaturales en su granja.'', CAST(1 AS bit), N''https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/The_Witch_poster.png/220px-The_Witch_poster.png'', ''2023-06-08T21:54:40.4401078-03:00'', N''The Witch'', N''https://www.youtube.com/watch?v=iQXmlf3Sefg'', ''2023-09-08T21:54:40.4401077-03:00''),
    (8, ''2023-09-08T21:54:40.4401086-03:00'', N''Dos investigadores paranormales toman un caso de posesión demoníaca.'', CAST(1 AS bit), N''https://upload.wikimedia.org/wikipedia/en/thumb/9/9b/The_Conjuring_The_Devil_Made_Me_Do_It_poster.jpeg/220px-The_Conjuring_The_Devil_Made_Me_Do_It_poster.jpeg'', ''2023-07-08T21:54:40.4401087-03:00'', N''The Conjuring: The Devil Made Me Do It'', N''https://www.youtube.com/watch?v=YDGw1MTEe9k'', ''2023-09-08T21:54:40.4401086-03:00''),
    (9, ''2023-09-08T21:54:40.4401089-03:00'', N''Una familia debe sobrevivir en un mundo invadido por criaturas que cazan por el sonido.'', CAST(1 AS bit), N''https://upload.wikimedia.org/wikipedia/en/thumb/a/a0/A_Quiet_Place_Part_II.jpeg/220px-A_Quiet_Place_Part_II.jpeg'', ''2023-05-08T21:54:40.4401090-03:00'', N''A Quiet Place Part II'', N''https://www.youtube.com/watch?v=XEMwSdne6UE'', ''2023-09-08T21:54:40.4401089-03:00''),
    (11, ''2023-09-08T21:54:40.4401091-03:00'', N''Un programador descubre que la realidad es una simulación creada por máquinas inteligentes.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg'', ''2003-09-08T21:54:40.4401092-03:00'', N''The Matrix'', N''https://www.youtube.com/watch?v=m8e-FF8MsqU'', ''2023-09-08T21:54:40.4401091-03:00''),
    (12, ''2023-09-08T21:54:40.4401094-03:00'', N''Un cazador de replicantes debe encontrar y ''''retirar'''' a cuatro androides que han regresado a la Tierra.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/5/53/Blade_Runner_poster.jpg'', ''1993-09-08T21:54:40.4401095-03:00'', N''Blade Runner'', N''https://www.youtube.com/watch?v=eogpIG53Cis'', ''2023-09-08T21:54:40.4401095-03:00''),
    (13, ''2023-09-08T21:54:40.4401096-03:00'', N''Un ladrón de sueños toma un último trabajo para implantar una idea en la mente de un ejecutivo.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg'', ''2013-09-08T21:54:40.4401098-03:00'', N''Inception'', N''https://www.youtube.com/watch?v=YoHD9XEInc0'', ''2023-09-08T21:54:40.4401097-03:00''),
    (14, ''2023-09-08T21:54:40.4401099-03:00'', N''Un androide asesino viaja al pasado para eliminar a la madre del líder de la resistencia humana.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/7/70/Terminator1984movieposter.jpg'', ''1983-09-08T21:54:40.4401100-03:00'', N''The Terminator'', N''https://www.youtube.com/watch?v=k64P4l2Wmeg'', ''2023-09-08T21:54:40.4401099-03:00''),
    (15, ''2023-09-08T21:54:40.4401101-03:00'', N''Un joven granjero se une a la rebelión para derrotar al malévolo Imperio Galáctico.'', CAST(0 AS bit), N''https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg'', ''1983-09-08T21:54:40.4401102-03:00'', N''Star Wars: Episode IV - A New Hope'', N''https://www.youtube.com/watch?v=vZ734NWnAHA'', ''2023-09-08T21:54:40.4401101-03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Creation', N'Description', N'OnCinema', N'PosterURL', N'Premiere', N'Title', N'Trailer', N'Update') AND [object_id] = OBJECT_ID(N'[Movie]'))
        SET IDENTITY_INSERT [Movie] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
        SET IDENTITY_INSERT [AspNetUserClaims] ON;
    EXEC(N'INSERT INTO [AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId])
    VALUES (1, N''role'', N''admin'', N''c2ee6493-5a73-46f3-a3f2-46d1d11d7176'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
        SET IDENTITY_INSERT [AspNetUserClaims] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_ActorMovie_MovieId] ON [ActorMovie] ([MovieId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_MovieCinema_CinemaId] ON [MovieCinema] ([CinemaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_MovieGenre_GenreId] ON [MovieGenre] ([GenreId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_Rating_MovieId] ON [Rating] ([MovieId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_Rating_UserId] ON [Rating] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_Review_MovieId] ON [Review] ([MovieId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    CREATE INDEX [IX_Review_UserId] ON [Review] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909005440_migracion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230909005440_migracion', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717094-03:00'', [Update] = ''2023-09-08T22:19:19.4717095-03:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717098-03:00'', [Update] = ''2023-09-08T22:19:19.4717098-03:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717100-03:00'', [Update] = ''2023-09-08T22:19:19.4717100-03:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717101-03:00'', [Update] = ''2023-09-08T22:19:19.4717102-03:00''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717102-03:00'', [Update] = ''2023-09-08T22:19:19.4717103-03:00''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717105-03:00'', [Update] = ''2023-09-08T22:19:19.4717105-03:00''
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717106-03:00'', [Update] = ''2023-09-08T22:19:19.4717122-03:00''
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717278-03:00'', [Update] = ''2023-09-08T22:19:19.4717278-03:00''
    WHERE [Id] = 8;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717279-03:00'', [Update] = ''2023-09-08T22:19:19.4717280-03:00''
    WHERE [Id] = 9;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717282-03:00'', [Update] = ''2023-09-08T22:19:19.4717282-03:00''
    WHERE [Id] = 10;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717283-03:00'', [Update] = ''2023-09-08T22:19:19.4717283-03:00''
    WHERE [Id] = 11;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717284-03:00'', [Update] = ''2023-09-08T22:19:19.4717285-03:00''
    WHERE [Id] = 12;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Actor] SET [Creation] = ''2023-09-08T22:19:19.4717286-03:00'', [Update] = ''2023-09-08T22:19:19.4717287-03:00''
    WHERE [Id] = 13;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''d002f4aa-e8ac-4ec1-a497-dc6fab370a1e'', [PasswordHash] = N''AQAAAAIAAYagAAAAEBY628okvokH3NcRevXOML3Lagtgr45MveA4hgcDmX6nukAvlkAcUc4qVgJDcbrcWA=='', [SecurityStamp] = N''55385dc2-20f9-40a5-837d-66ad6faf4e54'', [UserName] = N''Sr.Admin''
    WHERE [Id] = N''c2ee6493-5a73-46f3-a3f2-46d1d11d7176'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ec4b6993-a051-4c96-bb46-c994d8aa4444'', [PasswordHash] = N''AQAAAAIAAYagAAAAEA5bC949hfbsCnyHXFhoUWjzPMPVMZG1YC3tx5lRB7p1OZT4YoGDp3Sf4sSqLkXp3Q=='', [SecurityStamp] = N''29e08a25-e304-4734-aac4-45ce5977b207'', [UserName] = N''Sr.Normal''
    WHERE [Id] = N''e0765c93-676c-4199-b7ee-d7877c471821'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4719824-03:00'', [Update] = ''2023-09-08T22:19:19.4719827-03:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4719881-03:00'', [Update] = ''2023-09-08T22:19:19.4719881-03:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4719885-03:00'', [Update] = ''2023-09-08T22:19:19.4719886-03:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4719983-03:00'', [Update] = ''2023-09-08T22:19:19.4719983-03:00''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4719986-03:00'', [Update] = ''2023-09-08T22:19:19.4719986-03:00''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4719996-03:00'', [Update] = ''2023-09-08T22:19:19.4719996-03:00''
    WHERE [Id] = 21;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4719999-03:00'', [Update] = ''2023-09-08T22:19:19.4719999-03:00''
    WHERE [Id] = 22;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4720002-03:00'', [Update] = ''2023-09-08T22:19:19.4720002-03:00''
    WHERE [Id] = 23;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4720005-03:00'', [Update] = ''2023-09-08T22:19:19.4720005-03:00''
    WHERE [Id] = 24;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Cinema] SET [Creation] = ''2023-09-08T22:19:19.4720008-03:00'', [Update] = ''2023-09-08T22:19:19.4720008-03:00''
    WHERE [Id] = 25;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Genre] SET [Creation] = ''2023-09-08T22:19:19.4716801-03:00'', [Update] = ''2023-09-08T22:19:19.4716829-03:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Genre] SET [Creation] = ''2023-09-08T22:19:19.4716830-03:00'', [Update] = ''2023-09-08T22:19:19.4716831-03:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Genre] SET [Creation] = ''2023-09-08T22:19:19.4716831-03:00'', [Update] = ''2023-09-08T22:19:19.4716832-03:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Genre] SET [Creation] = ''2023-09-08T22:19:19.4716832-03:00'', [Update] = ''2023-09-08T22:19:19.4716833-03:00''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Genre] SET [Creation] = ''2023-09-08T22:19:19.4716833-03:00'', [Update] = ''2023-09-08T22:19:19.4716834-03:00''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Genre] SET [Creation] = ''2023-09-08T22:19:19.4716835-03:00'', [Update] = ''2023-09-08T22:19:19.4716835-03:00''
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Genre] SET [Creation] = ''2023-09-08T22:19:19.4716836-03:00'', [Update] = ''2023-09-08T22:19:19.4716837-03:00''
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Genre] SET [Creation] = ''2023-09-08T22:19:19.4716837-03:00'', [Update] = ''2023-09-08T22:19:19.4716838-03:00''
    WHERE [Id] = 8;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717627-03:00'', [Update] = ''2023-09-08T22:19:19.4717628-03:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717631-03:00'', [Update] = ''2023-09-08T22:19:19.4717631-03:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717633-03:00'', [Update] = ''2023-09-08T22:19:19.4717633-03:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717635-03:00'', [Update] = ''2023-09-08T22:19:19.4717635-03:00''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717636-03:00'', [Update] = ''2023-09-08T22:19:19.4717637-03:00''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717638-03:00'', [Update] = ''2023-09-08T22:19:19.4717639-03:00''
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717640-03:00'', [Premiere] = ''2023-06-08T22:19:19.4717641-03:00'', [Update] = ''2023-09-08T22:19:19.4717641-03:00''
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717652-03:00'', [Premiere] = ''2023-07-08T22:19:19.4717653-03:00'', [Update] = ''2023-09-08T22:19:19.4717653-03:00''
    WHERE [Id] = 8;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717668-03:00'', [Premiere] = ''2023-05-08T22:19:19.4717669-03:00'', [Update] = ''2023-09-08T22:19:19.4717668-03:00''
    WHERE [Id] = 9;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717671-03:00'', [Premiere] = ''2003-09-08T22:19:19.4717672-03:00'', [Update] = ''2023-09-08T22:19:19.4717671-03:00''
    WHERE [Id] = 11;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717676-03:00'', [Premiere] = ''1993-09-08T22:19:19.4717677-03:00'', [Update] = ''2023-09-08T22:19:19.4717677-03:00''
    WHERE [Id] = 12;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717679-03:00'', [Premiere] = ''2013-09-08T22:19:19.4717680-03:00'', [Update] = ''2023-09-08T22:19:19.4717679-03:00''
    WHERE [Id] = 13;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717681-03:00'', [Premiere] = ''1983-09-08T22:19:19.4717682-03:00'', [Update] = ''2023-09-08T22:19:19.4717681-03:00''
    WHERE [Id] = 14;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    EXEC(N'UPDATE [Movie] SET [Creation] = ''2023-09-08T22:19:19.4717683-03:00'', [Premiere] = ''1983-09-08T22:19:19.4717684-03:00'', [Update] = ''2023-09-08T22:19:19.4717683-03:00''
    WHERE [Id] = 15;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909011919_migracion2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230909011919_migracion2', N'7.0.10');
END;
GO

COMMIT;
GO

