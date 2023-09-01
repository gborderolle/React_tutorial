import { useNavigate, useParams } from "react-router-dom";
import FormReview from "./FormReview";

export default function EditReview() {
  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  if (isNaN(id)) {
    navigate("/reviews");
    return null;
  }

  return (
    <>
      <FormReview
        formName="Modificar review"
        model={{ name: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
    </>
  );
}
