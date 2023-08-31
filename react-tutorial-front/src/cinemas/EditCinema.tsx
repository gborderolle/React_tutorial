import { useNavigate, useParams } from "react-router-dom";
import FormCinema from "./FormCinema";

export default function EditCinema() {
  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  if (isNaN(id)) {
    navigate("/cinemas");
    return null;
  }

  return (
    <>
      <FormCinema model={{ name: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
    </>
  );
}

