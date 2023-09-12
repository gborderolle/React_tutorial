using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using WebAPI_tutorial_peliculas.Models;

namespace WebAPI_tutorial_peliculas.Context
{
    public class ContextDB : IdentityDbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

        #region DB Tables

        public DbSet<Actor> Actor { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<ActorMovie> ActorMovie { get; set; }
        public DbSet<MovieCinema> MovieCinema { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Rating> Rating { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActorMovie>()
                .HasKey(v => new { v.ActorId, v.MovieId });

            modelBuilder.Entity<MovieCinema>()
                .HasKey(v => new { v.MovieId, v.CinemaId });

            modelBuilder.Entity<MovieGenre>()
                .HasKey(v => new { v.MovieId, v.GenreId });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            //SeedEntities(modelBuilder); // Datos de prueba
        }

        private static void SeedEntities(ModelBuilder modelBuilder)
        {
            // ---------------- Géneros ---------------------------------------------
            var genre1 = new Genre() { Id = 1, Name = "Aventura" };
            var genre2 = new Genre() { Id = 2, Name = "Animación" };
            var genre3 = new Genre() { Id = 3, Name = "Suspenso" };
            var genre4 = new Genre() { Id = 4, Name = "Romance" };
            var genre5 = new Genre() { Id = 5, Name = "Terror" };
            var genre6 = new Genre() { Id = 6, Name = "Comedia" };
            var genre7 = new Genre() { Id = 7, Name = "Sci-fi" };
            var genre8 = new Genre() { Id = 8, Name = "Documental" };

            modelBuilder.Entity<Genre>().HasData(new List<Genre>
            {
                genre1, genre2, genre3, genre4, genre5, genre6, genre7, genre8
            });

            // ---------------- Actores ---------------------------------------------
            var actor1 = new Actor() { Id = 1, Name = "Jim Carrey", Born = new DateTime(1962, 1, 17), PhotoURL = "https://www.gettyimages.com/photos/jim-carrey" };
            var actor2 = new Actor() { Id = 2, Name = "Robert Downey Jr", Born = new DateTime(1965, 4, 4), PhotoURL = "https://www.gettyimages.com/photos/robert-downey-jr" };
            var actor3 = new Actor() { Id = 3, Name = "Chris Evans", Born = new DateTime(1981, 6, 13), PhotoURL = "https://www.gettyimages.com/photos/chris-evans-robert-downey-jr" };
            var actor4 = new Actor() { Id = 4, Name = "Angelina Jolie", Born = new DateTime(1975, 6, 4), PhotoURL = "https://www.gettyimages.com/photos/angelina-jolie" };
            var actor5 = new Actor() { Id = 5, Name = "Julia Roberts", Born = new DateTime(1967, 10, 28), PhotoURL = "https://www.gettyimages.com/photos/julia-roberts" };
            var actor6 = new Actor() { Id = 6, Name = "Margot Robbie", Born = new DateTime(1990, 7, 2), PhotoURL = "https://www.gettyimages.com/photos/margot-robbie" };
            var actor7 = new Actor() { Id = 7, Name = "Brad Pitt", Born = new DateTime(1963, 12, 18), PhotoURL = "https://www.gettyimages.com/photos/brad-pitt" };
            var actor8 = new Actor() { Id = 8, Name = "Penelope Cruz", Born = new DateTime(1974, 4, 28), PhotoURL = "https://www.gettyimages.com/photos/penelope-cruz" };
            var actor9 = new Actor() { Id = 9, Name = "Scarlett Johansson", Born = new DateTime(1984, 11, 22), PhotoURL = "https://www.gettyimages.com/photos/scarlett-johansson" };
            var actor10 = new Actor() { Id = 10, Name = "Megan Fox", Born = new DateTime(1986, 5, 16), PhotoURL = "https://www.gettyimages.com/photos/megan-fox" };
            var actor11 = new Actor() { Id = 11, Name = "Angelina Jolie", Born = new DateTime(1975, 6, 4), PhotoURL = "https://www.gettyimages.com/photos/angelina-jolie" };
            var actor12 = new Actor() { Id = 12, Name = "Jennifer Aniston", Born = new DateTime(1969, 2, 11), PhotoURL = "https://www.gettyimages.com/photos/jennifer-aniston" };
            var actor13 = new Actor() { Id = 13, Name = "Emma Stone", Born = new DateTime(1988, 11, 6), PhotoURL = "https://www.gettyimages.com/photos/emma-stone" };

            modelBuilder.Entity<Actor>().HasData(new List<Actor>
            {
                actor1, actor2, actor3, actor4, actor5, actor6, actor7, actor8, actor9,actor10, actor11, actor12, actor13
            });

            var movie1 = new Movie() { Id = 1, Title = "Interstellar", OnCinema = true, Premiere = new DateTime(2014, 11, 7), Trailer = "https://www.youtube.com/watch?v=2LqzF5WauAw", PosterURL = "https://m.media-amazon.com/images/I/A1JVqNMI7UL._AC_UF894,1000_QL80_.jpg", Description = "Un viaje interestelar en busca de un nuevo hogar para la humanidad." };
            var movie2 = new Movie() { Id = 2, Title = "The Truman Show", OnCinema = true, Premiere = new DateTime(1998, 6, 5), Trailer = "https://www.youtube.com/watch?v=dpDhYDiHxgU", PosterURL = "https://flxt.tmsimg.com/assets/p20974_p_v10_aq.jpg", Description = "La vida de un hombre es un reality show televisado las 24 horas." };
            var movie3 = new Movie() { Id = 3, Title = "Back to the future", OnCinema = false, Premiere = new DateTime(1989, 11, 22), Trailer = "https://www.youtube.com/watch?v=qvsgGtivCgs", PosterURL = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c2/Back_to_the_Future_Part_II.jpg/220px-Back_to_the_Future_Part_II.jpg", Description = "Un adolescente viaja al pasado y al futuro en un DeLorean modificado." };
            var movie4 = new Movie() { Id = 4, Title = "Men in black", OnCinema = false, Premiere = new DateTime(1997, 7, 2), Trailer = "https://www.youtube.com/watch?v=UxUTTrU6PA4", PosterURL = "https://upload.wikimedia.org/wikipedia/en/f/fb/Men_in_Black_Poster.jpg", Description = "Agentes secretos protegen a la Tierra de amenazas extraterrestres." };
            var movie5 = new Movie() { Id = 5, Title = "Terrifier", OnCinema = true, Premiere = new DateTime(2018, 3, 15), Trailer = "https://www.youtube.com/watch?v=fN5j1MtGO2Q", PosterURL = "https://m.media-amazon.com/images/M/MV5BYmMxNzA0OTUtOTJiOS00NTc4LWJmNTItMGM3OWE0N2Y0NjhjXkEyXkFqcGdeQXVyMTg5NjU4NjE@._V1_FMjpg_UX1000_.jpg", Description = "Un payaso asesino siembra el terror en la noche de Halloween." };
            var movie6 = new Movie() { Id = 6, Title = "Midsommar", OnCinema = true, Premiere = new DateTime(2019, 7, 3), Trailer = "https://www.youtube.com/watch?v=1Vnghdsjmd0", PosterURL = "https://grandillusioncinema.org/wp-content/uploads/2023/06/midsommar.jpg", Description = "Un grupo de amigos se ve atrapado en un festival pagano en Suecia." };
            var movie7 = new Movie() { Id = 7, Title = "The Witch", OnCinema = true, Premiere = DateTime.Now.AddMonths(-3), Trailer = "https://www.youtube.com/watch?v=iQXmlf3Sefg", PosterURL = "https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/The_Witch_poster.png/220px-The_Witch_poster.png", Description = "Una familia del siglo XVII enfrenta fuerzas sobrenaturales en su granja." };
            var movie8 = new Movie() { Id = 8, Title = "The Conjuring: The Devil Made Me Do It", OnCinema = true, Premiere = DateTime.Now.AddMonths(-2), Trailer = "https://www.youtube.com/watch?v=YDGw1MTEe9k", PosterURL = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9b/The_Conjuring_The_Devil_Made_Me_Do_It_poster.jpeg/220px-The_Conjuring_The_Devil_Made_Me_Do_It_poster.jpeg", Description = "Dos investigadores paranormales toman un caso de posesión demoníaca." };
            var movie9 = new Movie() { Id = 9, Title = "A Quiet Place Part II", OnCinema = true, Premiere = DateTime.Now.AddMonths(-4), Trailer = "https://www.youtube.com/watch?v=XEMwSdne6UE", PosterURL = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a0/A_Quiet_Place_Part_II.jpeg/220px-A_Quiet_Place_Part_II.jpeg", Description = "Una familia debe sobrevivir en un mundo invadido por criaturas que cazan por el sonido." };
            var movie11 = new Movie() { Id = 11, Title = "The Matrix", OnCinema = false, Premiere = DateTime.Now.AddYears(-20), Trailer = "https://www.youtube.com/watch?v=m8e-FF8MsqU", PosterURL = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", Description = "Un programador descubre que la realidad es una simulación creada por máquinas inteligentes." };
            var movie12 = new Movie() { Id = 12, Title = "Blade Runner", OnCinema = false, Premiere = DateTime.Now.AddYears(-30), Trailer = "https://www.youtube.com/watch?v=eogpIG53Cis", PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/53/Blade_Runner_poster.jpg", Description = "Un cazador de replicantes debe encontrar y 'retirar' a cuatro androides que han regresado a la Tierra." };
            var movie13 = new Movie() { Id = 13, Title = "Inception", OnCinema = false, Premiere = DateTime.Now.AddYears(-10), Trailer = "https://www.youtube.com/watch?v=YoHD9XEInc0", PosterURL = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg", Description = "Un ladrón de sueños toma un último trabajo para implantar una idea en la mente de un ejecutivo." };
            var movie14 = new Movie() { Id = 14, Title = "The Terminator", OnCinema = false, Premiere = DateTime.Now.AddYears(-40), Trailer = "https://www.youtube.com/watch?v=k64P4l2Wmeg", PosterURL = "https://upload.wikimedia.org/wikipedia/en/7/70/Terminator1984movieposter.jpg", Description = "Un androide asesino viaja al pasado para eliminar a la madre del líder de la resistencia humana." };
            var movie15 = new Movie() { Id = 15, Title = "Star Wars: Episode IV - A New Hope", OnCinema = false, Premiere = DateTime.Now.AddYears(-40), Trailer = "https://www.youtube.com/watch?v=vZ734NWnAHA", PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg", Description = "Un joven granjero se une a la rebelión para derrotar al malévolo Imperio Galáctico." };

            modelBuilder.Entity<Movie>().HasData(new List<Movie>
            {
                movie1, movie2, movie3, movie4, movie5, movie6, movie7, movie8, movie9, movie11, movie12, movie13, movie14, movie15
            });

            modelBuilder.Entity<MovieGenre>().HasData(new List<MovieGenre>
            {
                new MovieGenre(){MovieId=movie1.Id, GenreId=genre1.Id},
                new MovieGenre(){MovieId=movie1.Id, GenreId=genre2.Id},
                new MovieGenre(){MovieId=movie2.Id, GenreId=genre2.Id},
                new MovieGenre(){MovieId=movie2.Id, GenreId=genre5.Id},
                new MovieGenre(){MovieId=movie3.Id, GenreId=genre3.Id},
                new MovieGenre(){MovieId=movie4.Id, GenreId=genre4.Id},
                new MovieGenre(){MovieId=movie4.Id, GenreId=genre3.Id},
                new MovieGenre(){MovieId=movie5.Id, GenreId=genre1.Id},
                new MovieGenre(){MovieId=movie5.Id, GenreId=genre5.Id},
                new MovieGenre(){MovieId=movie6.Id, GenreId=genre5.Id},
                new MovieGenre(){MovieId=movie8.Id, GenreId=genre3.Id},
                new MovieGenre(){MovieId=movie9.Id, GenreId=genre3.Id},
                new MovieGenre(){MovieId=movie11.Id, GenreId=genre7.Id},
                new MovieGenre(){MovieId=movie12.Id, GenreId=genre7.Id},
                new MovieGenre(){MovieId=movie13.Id, GenreId=genre7.Id},
                new MovieGenre(){MovieId=movie14.Id, GenreId=genre7.Id},
                new MovieGenre(){MovieId=movie15.Id, GenreId=genre7.Id},
                new MovieGenre(){MovieId=movie8.Id, GenreId=genre5.Id},
                new MovieGenre(){MovieId=movie9.Id, GenreId=genre5.Id},
                new MovieGenre(){MovieId=movie11.Id, GenreId=genre5.Id},
                new MovieGenre(){MovieId=movie12.Id, GenreId=genre5.Id}
            });

            modelBuilder.Entity<ActorMovie>().HasData(new List<ActorMovie>
            {
                new ActorMovie(){MovieId=movie1.Id, ActorId=actor1.Id, Order=1, Character="superhero"},
                new ActorMovie(){MovieId=movie1.Id, ActorId=actor2.Id, Order=2, Character="supervillian"},
                new ActorMovie(){MovieId=movie2.Id, ActorId=actor3.Id, Order=1, Character="main character"},
                new ActorMovie(){MovieId=movie2.Id, ActorId=actor4.Id, Order=2, Character="supporting role"},
                new ActorMovie(){MovieId=movie3.Id, ActorId=actor5.Id, Order=1, Character="protagonist"},
                new ActorMovie(){MovieId=movie4.Id, ActorId=actor1.Id, Order=2, Character="antagonist"},
                new ActorMovie(){MovieId=movie5.Id, ActorId=actor2.Id, Order=1, Character="hero"},
                new ActorMovie(){MovieId=movie5.Id, ActorId=actor3.Id, Order=2, Character="sidekick"}
            });

            // ---------------- Cines ---------------------------------------------
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            /// Google Maps: latitud y longitud (en ese orden)
            /// Ej. apto: -34.90990874483437, -56.192072498205505
            /// lat: -34.90990874483437, long: -56.192072498205505

            /// NetTopologySuite.Geometries.Point
            /// Coordinate(x: longitude, y: latitude))

            var cine1 = new Cinema() { Id = 1, Name = "Moviecenter", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.90292421243134, x: -56.13621764762051)) };
            var cine2 = new Cinema() { Id = 2, Name = "LIFE Cinemas", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.90889872353638, x: -56.14677015960076)) };
            var cine3 = new Cinema() { Id = 3, Name = "Casablanca", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.91871301506793, x: -56.1566407649374)) };
            var cine4 = new Cinema() { Id = 4, Name = "Cinemateca", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.90849834167495, x: -56.2010689038137)) };
            var cine5 = new Cinema() { Id = 5, Name = "Punta Carretas Shopping", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.923823012219856, x: -56.15886454873049)) };

            var cine21 = new Cinema() { Id = 21, Name = "AMC Times Square", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.901112, x: -56.164532)) };
            var cine22 = new Cinema() { Id = 22, Name = "Regal LA Live", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.914314, x: -56.168498)) };
            var cine23 = new Cinema() { Id = 23, Name = "Cineplex Chicago", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.905004, x: -56.181330)) };
            var cine24 = new Cinema() { Id = 24, Name = "AMC Miami Beach", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.920369, x: -56.153841)) };
            var cine25 = new Cinema() { Id = 25, Name = "Cineworld Houston", Location = geometryFactory.CreatePoint(new Coordinate(y: -34.916723, x: -56.150231)) };


            modelBuilder.Entity<Cinema>().HasData(new List<Cinema>
            {
                cine1, cine2, cine3, cine4, cine5,
                cine21, cine22, cine23, cine24, cine25
            });

            modelBuilder.Entity<MovieCinema>().HasData(new List<MovieCinema>
            {
                new MovieCinema(){MovieId=movie1.Id, CinemaId=cine1.Id},
                new MovieCinema(){MovieId=movie1.Id, CinemaId=cine2.Id},
                new MovieCinema(){MovieId=movie2.Id, CinemaId=cine1.Id},
                new MovieCinema(){MovieId=movie3.Id, CinemaId=cine2.Id},
                new MovieCinema(){MovieId=movie3.Id, CinemaId=cine3.Id},
                new MovieCinema(){MovieId=movie4.Id, CinemaId=cine4.Id},
                new MovieCinema(){MovieId=movie5.Id, CinemaId=cine5.Id},
                new MovieCinema(){MovieId=movie5.Id, CinemaId=cine1.Id},
            });
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            // Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660148#notes
            // Generar GUID: https://guidgenerator.com/online-guid-generator.aspx
            // ---------------- Usuarios ---------------------------------------------
            var rolAdminId = "bef4cbd4-1f2b-472f-a1e2-e1a901f6808c";
            var userAdminId = "c2ee6493-5a73-46f3-a3f2-46d1d11d7176";
            var userNormalId = "e0765c93-676c-4199-b7ee-d7877c471821";

            var rolAdmin = new IdentityRole()
            {
                Id = rolAdminId,
                Name = "Admin",
                NormalizedName = "Admin"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();

            var username1 = "admin@testing.com";
            var userAdmin = new IdentityUser()
            {
                Id = userAdminId,
                UserName = "Sr.Admin",
                NormalizedUserName = username1,
                Email = username1,
                NormalizedEmail = username1,
                PasswordHash = passwordHasher.HashPassword(null, "Aa1234.")
            };

            var username2 = "user@testing.com";
            var userNormal = new IdentityUser()
            {
                Id = userNormalId,
                UserName = "Sr.Normal",
                NormalizedUserName = username2,
                Email = username2,
                NormalizedEmail = username2,
                PasswordHash = passwordHasher.HashPassword(null, "Aa1234.")
            };

            modelBuilder.Entity<IdentityUser>()
                .HasData(userAdmin, userNormal);

            modelBuilder.Entity<IdentityRole>()
                .HasData(rolAdmin);

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>()
                {
                    Id = 1,
                    ClaimType = "role",
                    UserId = userAdminId,
                    ClaimValue = "admin"
                });
        }
    }
}