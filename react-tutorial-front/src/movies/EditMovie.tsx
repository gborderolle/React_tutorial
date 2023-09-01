import { useNavigate, useParams } from "react-router-dom";
import FormMovie from "./FormMovie";

export default function EditMovie() {
  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  if (isNaN(id)) {
    navigate("/movies");
    return null;
  }

  return (
    <>
      <FormMovie
        formName="Modificar película"
        model={{ title: "", onCinema: true }}
        onSubmit={async (values) => {
          console.log(values);
        }}
      />
    </>
  )
}
