// Editar: Clase 120: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26020780#overview
// Borrar: Clase 121: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26021230#overview

import IndexEntity from "../utils/IndexEntity";
import { genreDTO } from "./genre.model";
import { urlGenres } from "../utils/endpoints";

export default function IndexGenres() {
  return (
    <>
      <IndexEntity<genreDTO>
        url={urlGenres}
        urlCreate="create"
        title="Géneros"
        entityName="Género"
        urlBack="/genres"
      >
        {(genres, buttons) => (
          <>
            <thead>
              <tr>
                <th>#</th>
                <th>Nombre</th>
                <th>Acciones</th>
              </tr>
            </thead>
            <tbody>
              {Array.isArray(genres) &&
                genres.map((genre, index) => (
                  <tr key={genre.id}>
                    <td>{index + 1}</td>
                    <td>{genre.name}</td>
                    <td>{buttons(`edit/${genre.id}`, genre.id)}</td>{" "}
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
