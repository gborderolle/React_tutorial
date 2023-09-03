import FormReview from "./FormReview";
import EditEntity from "../utils/EditEntity";
import { urlReviews } from "../utils/endpoints";
import { reviewCreationDTO, reviewDTO } from "./review.model";

export default function EditReview() {
  return (
    <EditEntity<reviewCreationDTO, reviewDTO>
      url={urlReviews}
      urlIndex="/reviews" // Fixed the backslash to forward slash
      entityName="reviews"
    >
      {(entity, editEntity) => (
        <FormReview
          formName="Modificar review"
          model={entity}
          onSubmit={(values) => editEntity(values)}
        />
      )}
    </EditEntity>
  );
}
