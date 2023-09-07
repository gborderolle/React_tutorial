// Configuración de rutas
// Clase 64: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858264#overview

import LandingPage from "./LandingPage";
import CreateActor from "./actors/CreateActor";
import EditActor from "./actors/EditActor";
import IndexActors from "./actors/IndexActors";
import IndexUsers from "./auth/IndexUsers";
import Login from "./auth/Login";
import Register from "./auth/Register";
import CreateCinema from "./cinemas/CreateCinema";
import EditCinema from "./cinemas/EditCinema";
import IndexCinemas from "./cinemas/IndexCinemas";
import CreateGenre from "./genres/CreateGenre";
import EditGenre from "./genres/EditGenre";
import IndexGenres from "./genres/IndexGenres";
import CreateMovie from "./movies/CreateMovie";
import DetailsMovie from "./movies/DetailsMovie";
import EditMovie from "./movies/EditMovie";
import FilterMovies from "./movies/FilterMovies";
import IndexMovies from "./movies/IndexMovies";
import CreateReview from "./reviews/CreateReview";
import EditReview from "./reviews/EditReview";
import IndexReviews from "./reviews/IndexReviews";
import RedirectToLanding from "./utils/RedirectToLanding";

const paths = [
  { path: "/genres/edit/:id", component: EditGenre, isAdmin: true },
  { path: "/genres/create", component: CreateGenre, isAdmin: true },
  { path: "/genres", component: IndexGenres, isAdmin: true },

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

  { path: "/", component: LandingPage },
  { path: "*", component: RedirectToLanding },
];

export default paths;
