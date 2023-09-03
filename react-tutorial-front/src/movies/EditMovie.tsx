import FormMovie from "./FormMovie";
import EditEntity from "../utils/EditEntity";
import { urlMovies } from "../utils/endpoints";
import { movieCreationDTO, movieDTO } from "./movie.model";
import {
  ConvertActorToFormData,
  ConvertMovieToFormData,
} from "../utils/FormDataUtils";

export default function EditMovie() {
  return (
    <EditEntity<movieCreationDTO, movieDTO>
      url={urlMovies}
      urlIndex="/movies"
      entityName="Movies"
      transformFormData={ConvertMovieToFormData}
    >
      {(entity, editEntity) => (
        <FormMovie
          formName="Modificar película"
          model={entity}
          onSubmit={(values) => editEntity(values)}
          noSelectedGenres={[]}
          selectedGenres={[]}
          noSelectedCinemas={[]}
          selectedCinemas={[]}
          selectedActors={[]}
        />
      )}
    </EditEntity>
  );
}
