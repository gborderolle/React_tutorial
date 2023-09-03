import FormCinema from "./FormCinema";
import EditEntity from "../utils/EditEntity";
import { urlCinemas } from "../utils/endpoints";
import { cinemaCreationDTO, cinemaDTO } from "./cinema.model";

export default function EditCinema() {
  return (
    <EditEntity<cinemaCreationDTO, cinemaDTO>
      url={urlCinemas}
      urlIndex="/cinemas"
      entityName="Cines"
    >
      {(entity, editEntity) => (
        <FormCinema
          formName="Modificar cine"
          model={entity}
          onSubmit={(values) => editEntity(values)}
        />
      )}
    </EditEntity>
  );
}
