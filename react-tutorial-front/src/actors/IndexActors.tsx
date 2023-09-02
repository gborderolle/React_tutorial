import IndexEntity from "../utils/IndexEntity";
import { actorDTO } from "./actor.model";
import { urlActors } from "../utils/endpoints";

export default function IndexActors() {
  return (
    <>
      <IndexEntity<actorDTO>
        url={urlActors}
        urlCreate="create"
        title="Actors"
        entityName="Actor"
      >
        {(actors, buttons) => (
          <>
            <thead>
              <tr>
                <th>#</th>
                <th>Foto</th>
                <th>Nombre</th>
                <th>Nacimiento</th>
                <th>Acciones</th>
              </tr>
            </thead>
            <tbody>
              {Array.isArray(actors) &&
                actors.map((actor, index) => (
                  <tr key={actor.id}>
                    <td>{index + 1}</td>
                    <td>
                      <img src={actor.photoURL} alt="Foto del actor." />
                    </td>
                    <td>{actor.name}</td>
                    <td>{actor.born?.toString()}</td>
                    <td>{buttons(`actors/edit/${actor.id}`, actor.id)}</td>
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
