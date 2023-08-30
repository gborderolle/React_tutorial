// Configuración de rutas
// Clase 64: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858264#overview

import LandingPage from "./LandingPage";
import IndexActors from "./actors/IndexActors";
import IndexCinemas from "./cinemas/IndexCinemas";
import CreateGenre from "./genres/CreateGenre";
import EditGenre from "./genres/EditGenre";
import IndexGenres from "./genres/IndexGenres";
import CreateMovie from "./movies/CreateMovie";
import EditMovie from "./movies/EditMovie";
import IndexMovies from "./movies/IndexMovies";
import CreateReview from "./reviews/CreateReview";
import EditReview from "./reviews/EditReview";
import IndexReviews from "./reviews/IndexReviews";

const paths=[
    {path:'/genres/create', component: CreateGenre},
    {path:'/genres/edit/:id(\\d+)', component: EditGenre}, //"\\d+" int
    {path:'/genres', component: IndexGenres},

    {path:'/movies/create', component: CreateMovie},
    {path:'/movies/edit/:id(\\d+)', component: EditMovie},
    {path:'/movies', component: IndexMovies},

    {path:'/actors/create', component: CreateMovie},
    {path:'/actors/edit/:id(\\d+)', component: EditMovie},
    {path:'/actors', component: IndexActors},

    {path:'/cinemas/create', component: CreateMovie},
    {path:'/cinemas/edit/:id(\\d+)', component: EditMovie},
    {path:'/cinemas', component: IndexCinemas},

    {path:'/reviews/create', component: CreateReview},
    {path:'/reviews/edit/:id(\\d+)', component: EditReview},
    {path:'/reviews', component: IndexReviews},

{path:'/', component: LandingPage},
];

export default paths;