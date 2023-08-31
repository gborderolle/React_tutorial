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
      <FormMovie model={{ title: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
    </>
  );
}
