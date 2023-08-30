import { Link } from "react-router-dom";

export default function IndexActors() {
  return (
    <>
      <h3>Índice Actores</h3>
      <ol className="list-group list-group-numbered">
        <li className="list-group-item d-flex justify-content-between align-items-start">
          <div className="ms-2 me-auto">
            <Link to="/actors/create">Crear</Link>
          </div>
        </li>
        <li className="list-group-item d-flex justify-content-between align-items-start">
          <div className="ms-2 me-auto">
            <Link to="/actors/edit">Modificar</Link>
          </div>
        </li>
      </ol>
    </>
  );
}
