import Dashboard from "./views/Dashboard";
import Landing from "./views/landing/LandingPage";
import Typography from "./views/Typography.js";
import Icons from "./views/Icons.js";
import Maps from "./views/Maps.js";
import Notifications from "./views/Notifications.js";
import IndexGenres from "./models/genres/IndexGenres";
import View from "./views/global/View";
import IndexMovies from "./models/movies/IndexMovies";
import IndexActors from "./models/actors/IndexActors";
import IndexCinemas from "./models/cinemas/IndexCinemas";

const dashboardRoutes = [
  {
    path: "/dashboard",
    name: "Dashboard",
    icon: "nc-icon nc-chart-pie-35",
    component: Dashboard,
    layout: "",
  },
  {
    path: "/landing",
    name: "Cartelera",
    icon: "nc-icon nc-button-play",
    component: Landing,
    layout: "",
  },
  {
    path: "/genres",
    name: "Géneros",
    icon: "nc-icon nc-tag-content",
    component: IndexGenres,
    layout: "",
  },
  {
    path: "/movies",
    name: "Películas",
    icon: "nc-icon nc-bullet-list-67",
    component: IndexMovies,
    layout: "",
  },
  {
    path: "/actors",
    name: "Actores",
    icon: "nc-icon nc-circle-09",
    component: IndexActors,
    layout: "",
  },
  {
    path: "/cinemas",
    name: "Cines",
    icon: "nc-icon nc-atom",
    component: IndexCinemas,
    layout: "",
  },
  {
    path: "/maps",
    name: "Reviews",
    icon: "nc-icon nc-notes",
    component: Maps,
    layout: "/admin",
  },
  {
    path: "/notifications",
    name: "Filtrar películas",
    icon: "nc-icon nc-zoom-split",
    component: Notifications,
    layout: "/admin",
  },
  {
    path: "/notifications",
    name: "Administración",
    icon: "nc-icon nc-settings-90",
    component: Notifications,
    layout: "/admin",
  },
];

export default dashboardRoutes;
