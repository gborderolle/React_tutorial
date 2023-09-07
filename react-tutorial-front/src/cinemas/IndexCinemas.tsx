import IndexEntity from "../utils/IndexEntity";
import { cinemaDTO } from "./cinema.model";
import { urlCinemas } from "../utils/endpoints";

export default function IndexCinemas() {
  return (
    <>
      <IndexEntity<cinemaDTO>
        url={urlCinemas}
        urlCreate="create"
        title="Cine"
        entityName="Cinema"
      >
        {(cinemas, buttons) => (
          <>
            <thead>
              <tr>
                <th>#</th>
                <th>Nombre</th>
                <th>Acciones</th>
              </tr>
            </thead>
            <tbody>
              {Array.isArray(cinemas) &&
                cinemas.map((cinema, index) => (
                  <tr key={cinema.id}>
                    <td>{index + 1}</td>
                    <td>{cinema.name}</td>
                    <td>{buttons(`edit/${cinema.id}`, cinema.id)}</td>
                    {/* le paso la función buttons() que es parte del hijo */}
                  </tr>
                ))}
            </tbody>
          </>
        )}
      </IndexEntity >
    </>
  );
}
