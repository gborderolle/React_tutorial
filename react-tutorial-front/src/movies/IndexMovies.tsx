import { Link } from "react-router-dom";

export default function IndexMovies() {
  return (
  <>
  <h3>Índice Películas</h3>
  <Link to="movies/create">Crear Película</Link>
  </>
  )
}
