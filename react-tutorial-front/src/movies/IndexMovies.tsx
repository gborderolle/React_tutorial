import IndexEntity from "../utils/IndexEntity";
import { movieDTO } from "./movie.model";
import { urlMovies } from "../utils/endpoints";
import { Link, NavLink } from "react-router-dom";

export default function IndexMovies() {
  return (
    <>
      <IndexEntity<movieDTO>
        url={urlMovies}
        urlCreate="create"
        title="Películas"
        entityName="Película"
        urlBack="/movies"
      >
        {(movies, buttons) => (
          <>
            <thead>
              <tr>
                <th>#</th>
                <th>Título</th>
                <th>Poster</th>
                <th>Descripción</th>
                <th>Acciones</th>
              </tr>
            </thead>
            <tbody>
              {Array.isArray(movies) &&
                movies.map((movie, index) => (
                  <tr key={movie.id}>
                    <td>{index + 1}</td>
                    <td>
                      <Link
                        key={movie.id}
                        to={`/movies/${movie.id}`}
                        className="m-2"
                      >
                        {movie.title}
                      </Link>
                    </td>
                    <td>
                      <div className="actor-image-container">
                        <img
                          src={movie.posterURL}
                          alt="Poster de la película."
                          className="img-fluid rounded"
                        />
                      </div>
                    </td>
                    <td>{movie.description}</td>
                    <td>{buttons(`edit/${movie.id}`, movie.id)}</td>
                  </tr>
                ))}
            </tbody>
          </>
        )}
      </IndexEntity>
    </>
  );
}