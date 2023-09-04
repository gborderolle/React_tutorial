// Configuración de rutas
// Clase 64: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858264#overview

import LandingPage from "./LandingPage";
import CreateActor from "./actors/CreateActor";
import EditActor from "./actors/EditActor";
import IndexActors from "./actors/IndexActors";
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
  { path: "/genres/edit/:id", component: EditGenre },
  { path: "/genres/create", component: CreateGenre },
  { path: "/genres", component: IndexGenres },

  { path: "/movies/edit/:id", component: EditMovie },
  { path: "/movies/:id", component: DetailsMovie },
  { path: "/movies/filter", component: FilterMovies },
  { path: "/movies/create", component: CreateMovie },
  { path: "/movies", component: IndexMovies },

  { path: "/actors/edit/:id", component: EditActor },
  { path: "/actors/create", component: CreateActor },
  { path: "/actors", component: IndexActors },

  { path: "/cinemas/edit/:id", component: EditCinema },
  { path: "/cinemas/create", component: CreateCinema },
  { path: "/cinemas", component: IndexCinemas },

  { path: "/reviews/edit/:id", component: EditReview },
  { path: "/reviews/create", component: CreateReview },
  { path: "/reviews", component: IndexReviews },

  { path: "/", component: LandingPage },
  { path: "*", component: RedirectToLanding },
];

export default paths;
