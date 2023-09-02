import IndexEntity from "../utils/IndexEntity";
import { movieDTO } from "./movie.model";
import { urlMovies } from "../utils/endpoints";

export default function IndexMovies() {
  return (
    <>
      <IndexEntity<movieDTO>
        url={urlMovies}
        urlCreate="create"
        title="Películas"
        entityName="Película"
      >
        {(movies, buttons) => (
          <>
            <thead>
              <tr>
                <th>#</th>
                <th>Título</th>
                <th>Descripción</th>
                <th>Acciones</th>
              </tr>
            </thead>
            <tbody>
              {Array.isArray(movies) &&
                movies.map((movie, index) => (
                  <tr key={movie.id}>
                    <td>{index + 1}</td>
                    <td>{movie.title}</td>
                    <td>{movie.description}</td>
                    <td>{buttons(`movies/edit/${movie.id}`, movie.id)}</td>
                    {/* le paso la función buttons() que es parte del hijo */}
                  </tr>
                ))}
            </tbody>
          </>
        )}
      </IndexEntity>
    </>
  );
}



{/* <li className="list-group-item d-flex justify-content-between align-items-start">
              <div className="ms-2 me-auto">
                <Link to="/movies/filter">Filtrar</Link>
              </div>
            </li> */}