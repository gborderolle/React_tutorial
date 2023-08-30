import { Link } from "react-router-dom";

export default function IndexGenres() {
  return (
  <>
  <h3>Índice Géneros</h3>
  <Link to="genres/create">Crear Género</Link>
  <Link to="genres/edit">Editar Género</Link>
  </>
  )
}
