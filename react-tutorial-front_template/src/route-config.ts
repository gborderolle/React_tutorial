// Configuración de rutas
// Clase 64: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858264#overview

import LandingPage from "./views/landing/LandingPage";
import RedirectToLanding from "./utils/RedirectToLanding";
import CreateActor from "./models/actors/CreateActor";
import EditActor from "./models/actors/EditActor";
import IndexActors from "./models/actors/IndexActors";
import IndexCinemas from "./models/cinemas/IndexCinemas";
import IndexGenres from "./models/genres/IndexGenres";
import IndexMovies from "./models/movies/IndexMovies";
import CreateCinema from "./models/cinemas/CreateCinema";
import EditCinema from "./models/cinemas/EditCinema";
import CreateGenre from "./models/genres/CreateGenre";
import EditGenre from "./models/genres/EditGenre";
import CreateMovie from "./models/movies/CreateMovie";
import DetailsMovie from "./models/movies/DetailsMovie";
import EditMovie from "./models/movies/EditMovie";
import FilterMovies from "./models/movies/FilterMovies";
import CreateReview from "./models/reviews/CreateReview";
import EditReview from "./models/reviews/EditReview";
import IndexReviews from "./models/reviews/IndexReviews";
import Login from "./auth/Login";
import Register from "./auth/Register";
import IndexUsers from "./auth/IndexUsers";
import AdminLayout from "./layouts/Admin";

const paths = [
  { path: "/genres/edit/:id", component: EditGenre, isAdmin: true },
  { path: "/genres/create", component: CreateGenre, isAdmin: true },
  { path: "/genres", component: IndexGenres },

  { path: "/movies/edit/:id", component: EditMovie, isAdmin: true },
  { path: "/movies/:id", component: DetailsMovie },
  { path: "/movies/filter", component: FilterMovies },
  { path: "/movies/create", component: CreateMovie, isAdmin: true },
  { path: "/movies", component: IndexMovies },

  { path: "/actors/edit/:id", component: EditActor, isAdmin: true },
  { path: "/actors/create", component: CreateActor, isAdmin: true },
  { path: "/actors", component: IndexActors },

  { path: "/cinemas/edit/:id", component: EditCinema, isAdmin: true },
  { path: "/cinemas/create", component: CreateCinema, isAdmin: true },
  { path: "/cinemas", component: IndexCinemas },

  { path: "/reviews/edit/:id", component: EditReview, isAdmin: true },
  { path: "/reviews/create", component: CreateReview, isAdmin: true },
  { path: "/reviews", component: IndexReviews },

  { path: "/register", component: Register },
  { path: "/login", component: Login },
  { path: "/users", component: IndexUsers, isAdmin: true },

  // { path: "/", component: LandingPage },
  { path: "/", component: AdminLayout },
  { path: "*", component: RedirectToLanding },
];

export default paths;
