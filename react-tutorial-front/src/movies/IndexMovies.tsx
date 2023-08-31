import { Link } from "react-router-dom";

export default function IndexMovies() {
  return (
    <>
      <h3>Índice Películas</h3>
      <ol className="list-group list-group-numbered">
        <li className="list-group-item d-flex justify-content-between align-items-start">
          <div className="ms-2 me-auto">
            <Link to="/movies/create">Crear</Link>
          </div>
        </li>
        <li className="list-group-item d-flex justify-content-between align-items-start">
          <div className="ms-2 me-auto">
            <Link to="/movies/edit">Modificar</Link>
          </div>
        </li>
        <li className="list-group-item d-flex justify-content-between align-items-start">
          <div className="ms-2 me-auto">
            <Link to="/movies/filter">Filtrar</Link>
          </div>
        </li>
      </ol>
    </>
  );
}
