using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI_tutorial_peliculas.Migrations
{
    /// <inheritdoc />
    public partial class migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Born = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnCinema = table.Column<bool>(type: "bit", nullable: false),
                    Premiere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PosterURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCinema",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCinema", x => new { x.MovieId, x.CinemaId });
                    table.ForeignKey(
                        name: "FK_MovieCinema_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCinema_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "Biography", "Born", "Creation", "Name", "PhotoURL", "Update" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1962, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3846), "Jim Carrey", "https://www.gettyimages.com/photos/jim-carrey", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3848) },
                    { 2, null, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3852), "Robert Downey Jr", "https://www.gettyimages.com/photos/robert-downey-jr", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3852) },
                    { 3, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3854), "Chris Evans", "https://www.gettyimages.com/photos/chris-evans-robert-downey-jr", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3854) },
                    { 4, null, new DateTime(1975, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3855), "Angelina Jolie", "https://www.gettyimages.com/photos/angelina-jolie", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3855) },
                    { 5, null, new DateTime(1967, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3857), "Julia Roberts", "https://www.gettyimages.com/photos/julia-roberts", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3857) },
                    { 6, null, new DateTime(1990, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3859), "Margot Robbie", "https://www.gettyimages.com/photos/margot-robbie", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3859) },
                    { 7, null, new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3860), "Brad Pitt", "https://www.gettyimages.com/photos/brad-pitt", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3871) },
                    { 8, null, new DateTime(1974, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3887), "Penelope Cruz", "https://www.gettyimages.com/photos/penelope-cruz", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3888) },
                    { 9, null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3889), "Scarlett Johansson", "https://www.gettyimages.com/photos/scarlett-johansson", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3889) },
                    { 10, null, new DateTime(1986, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3891), "Megan Fox", "https://www.gettyimages.com/photos/megan-fox", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3891) },
                    { 11, null, new DateTime(1975, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3892), "Angelina Jolie", "https://www.gettyimages.com/photos/angelina-jolie", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3892) },
                    { 12, null, new DateTime(1969, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3894), "Jennifer Aniston", "https://www.gettyimages.com/photos/jennifer-aniston", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3894) },
                    { 13, null, new DateTime(1988, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3895), "Emma Stone", "https://www.gettyimages.com/photos/emma-stone", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3896) }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bef4cbd4-1f2b-472f-a1e2-e1a901f6808c", null, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c2ee6493-5a73-46f3-a3f2-46d1d11d7176", 0, "03123e52-6965-453a-acb8-5b873b29de29", "admin@testing.com", false, false, null, "admin@testing.com", "admin@testing.com", "AQAAAAIAAYagAAAAEDv2/fNOwTLh+B+fLGuqfVCQ/p5OkWw63DI2uyeud7Q5JD8DiuaxiDtKmiULF1vJPw==", null, false, "87432b62-522b-46ff-a7b9-e20ac2287c71", false, "Sr.Admin" },
                    { "e0765c93-676c-4199-b7ee-d7877c471821", 0, "cd40e3db-d1ed-4b08-830b-c8c551544da2", "user@testing.com", false, false, null, "user@testing.com", "user@testing.com", "AQAAAAIAAYagAAAAEBYtAgxipuXRKGh1VKonVJXTPyoNpD1w1DE+U+oxgg3mis8+fSvZA3TW20PFn5ZRxA==", null, false, "16bfccb1-86af-4cd7-a856-5f2e561502a1", false, "Sr.Normal" }
                });

            migrationBuilder.InsertData(
                table: "Cinema",
                columns: new[] { "Id", "Creation", "Location", "Name", "Update" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6396), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.13621764762051 -34.90292421243134)"), "Moviecenter", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6403) },
                    { 2, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6434), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.14677015960076 -34.90889872353638)"), "LIFE Cinemas", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6435) },
                    { 3, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6438), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.1566407649374 -34.91871301506793)"), "Casablanca", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6439) },
                    { 4, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6443), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.2010689038137 -34.90849834167495)"), "Cinemateca", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6444) },
                    { 5, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6447), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.15886454873049 -34.923823012219856)"), "Punta Carretas Shopping", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6448) },
                    { 21, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6451), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.164532 -34.901112)"), "AMC Times Square", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6452) },
                    { 22, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6455), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.168498 -34.914314)"), "Regal LA Live", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6456) },
                    { 23, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6459), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.18133 -34.905004)"), "Cineplex Chicago", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6460) },
                    { 24, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6463), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.153841 -34.920369)"), "AMC Miami Beach", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6464) },
                    { 25, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6467), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-56.150231 -34.916723)"), "Cineworld Houston", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(6468) }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Creation", "Name", "Update" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3648), "Aventura", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3680) },
                    { 2, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3681), "Animación", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3682) },
                    { 3, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3683), "Suspenso", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3683) },
                    { 4, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3684), "Romance", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3684) },
                    { 5, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3685), "Terror", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3685) },
                    { 6, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3686), "Comedia", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3687) },
                    { 7, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3687), "Sci-fi", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3688) },
                    { 8, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3688), "Documental", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(3689) }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Creation", "Description", "OnCinema", "PosterURL", "Premiere", "Title", "Trailer", "Update" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4154), "Un viaje interestelar en busca de un nuevo hogar para la humanidad.", true, "https://m.media-amazon.com/images/I/A1JVqNMI7UL._AC_UF894,1000_QL80_.jpg", new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar", "https://www.youtube.com/watch?v=2LqzF5WauAw", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4156) },
                    { 2, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4158), "La vida de un hombre es un reality show televisado las 24 horas.", true, "https://flxt.tmsimg.com/assets/p20974_p_v10_aq.jpg", new DateTime(1998, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Truman Show", "https://www.youtube.com/watch?v=dpDhYDiHxgU", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4159) },
                    { 3, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4160), "Un adolescente viaja al pasado y al futuro en un DeLorean modificado.", false, "https://upload.wikimedia.org/wikipedia/en/thumb/c/c2/Back_to_the_Future_Part_II.jpg/220px-Back_to_the_Future_Part_II.jpg", new DateTime(1989, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back to the future", "https://www.youtube.com/watch?v=qvsgGtivCgs", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4161) },
                    { 4, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4162), "Agentes secretos protegen a la Tierra de amenazas extraterrestres.", false, "https://upload.wikimedia.org/wikipedia/en/f/fb/Men_in_Black_Poster.jpg", new DateTime(1997, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Men in black", "https://www.youtube.com/watch?v=UxUTTrU6PA4", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4163) },
                    { 5, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4164), "Un payaso asesino siembra el terror en la noche de Halloween.", true, "https://m.media-amazon.com/images/M/MV5BYmMxNzA0OTUtOTJiOS00NTc4LWJmNTItMGM3OWE0N2Y0NjhjXkEyXkFqcGdeQXVyMTg5NjU4NjE@._V1_FMjpg_UX1000_.jpg", new DateTime(2018, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terrifier", "https://www.youtube.com/watch?v=fN5j1MtGO2Q", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4164) },
                    { 6, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4166), "Un grupo de amigos se ve atrapado en un festival pagano en Suecia.", true, "https://grandillusioncinema.org/wp-content/uploads/2023/06/midsommar.jpg", new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midsommar", "https://www.youtube.com/watch?v=1Vnghdsjmd0", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4166) },
                    { 7, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4167), "Una familia del siglo XVII enfrenta fuerzas sobrenaturales en su granja.", true, "https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/The_Witch_poster.png/220px-The_Witch_poster.png", new DateTime(2023, 11, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4169), "The Witch", "https://www.youtube.com/watch?v=iQXmlf3Sefg", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4168) },
                    { 8, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4181), "Dos investigadores paranormales toman un caso de posesión demoníaca.", true, "https://upload.wikimedia.org/wikipedia/en/thumb/9/9b/The_Conjuring_The_Devil_Made_Me_Do_It_poster.jpeg/220px-The_Conjuring_The_Devil_Made_Me_Do_It_poster.jpeg", new DateTime(2023, 12, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4182), "The Conjuring: The Devil Made Me Do It", "https://www.youtube.com/watch?v=YDGw1MTEe9k", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4181) },
                    { 9, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4184), "Una familia debe sobrevivir en un mundo invadido por criaturas que cazan por el sonido.", true, "https://upload.wikimedia.org/wikipedia/en/thumb/a/a0/A_Quiet_Place_Part_II.jpeg/220px-A_Quiet_Place_Part_II.jpeg", new DateTime(2023, 10, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4185), "A Quiet Place Part II", "https://www.youtube.com/watch?v=XEMwSdne6UE", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4184) },
                    { 11, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4186), "Un programador descubre que la realidad es una simulación creada por máquinas inteligentes.", false, "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", new DateTime(2004, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4187), "The Matrix", "https://www.youtube.com/watch?v=m8e-FF8MsqU", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4186) },
                    { 12, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4189), "Un cazador de replicantes debe encontrar y 'retirar' a cuatro androides que han regresado a la Tierra.", false, "https://upload.wikimedia.org/wikipedia/en/5/53/Blade_Runner_poster.jpg", new DateTime(1994, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4191), "Blade Runner", "https://www.youtube.com/watch?v=eogpIG53Cis", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4190) },
                    { 13, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4192), "Un ladrón de sueños toma un último trabajo para implantar una idea en la mente de un ejecutivo.", false, "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg", new DateTime(2014, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4193), "Inception", "https://www.youtube.com/watch?v=YoHD9XEInc0", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4193) },
                    { 14, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4194), "Un androide asesino viaja al pasado para eliminar a la madre del líder de la resistencia humana.", false, "https://upload.wikimedia.org/wikipedia/en/7/70/Terminator1984movieposter.jpg", new DateTime(1984, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4196), "The Terminator", "https://www.youtube.com/watch?v=k64P4l2Wmeg", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4195) },
                    { 15, new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4197), "Un joven granjero se une a la rebelión para derrotar al malévolo Imperio Galáctico.", false, "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg", new DateTime(1984, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4198), "Star Wars: Episode IV - A New Hope", "https://www.youtube.com/watch?v=vZ734NWnAHA", new DateTime(2024, 2, 3, 17, 46, 45, 33, DateTimeKind.Local).AddTicks(4197) }
                });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[,]
                {
                    { 1, 1, "superhero", 1 },
                    { 1, 4, "antagonist", 2 },
                    { 2, 1, "supervillian", 2 },
                    { 2, 5, "hero", 1 },
                    { 3, 2, "main character", 1 },
                    { 3, 5, "sidekick", 2 },
                    { 4, 2, "supporting role", 2 },
                    { 5, 3, "protagonist", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "role", "admin", "c2ee6493-5a73-46f3-a3f2-46d1d11d7176" });

            migrationBuilder.InsertData(
                table: "MovieCinema",
                columns: new[] { "CinemaId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 4 },
                    { 1, 5 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 5, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 1, 5 },
                    { 5, 5 },
                    { 5, 6 },
                    { 3, 8 },
                    { 5, 8 },
                    { 3, 9 },
                    { 5, 9 },
                    { 5, 11 },
                    { 7, 11 },
                    { 5, 12 },
                    { 7, 12 },
                    { 7, 13 },
                    { 7, 14 },
                    { 7, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MovieId",
                table: "ActorMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCinema_CinemaId",
                table: "MovieCinema",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_MovieId",
                table: "Rating",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieId",
                table: "Review",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MovieCinema");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cinema");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
