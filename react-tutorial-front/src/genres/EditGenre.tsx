import FormGenre from "./FormGenre";
import { urlGenres } from "../utils/endpoints";
import { genreCreationDTO, genreDTO } from "./genre.model";
import EditEntity from "../utils/EditEntity";

export default function EditGenre() {
  return (
    <EditEntity<genreCreationDTO, genreDTO>
      url={urlGenres}
      urlIndex="/genres"
      entityName="Géneros"
    >
      {(entity, editEntity) => (
        <FormGenre
          formName="Modificar género"
          model={entity}
          onSubmit={(values) => editEntity(values)}
        />
      )}
    </EditEntity>
  );
}
