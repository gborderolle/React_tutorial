import { useNavigate, useParams } from "react-router-dom";
import FormActor from "./FormActor";

export default function EditActor() {
  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  if (isNaN(id)) {
    navigate("/actors");
    return null;
  }

  return (
    <>
      <FormActor model={{ name: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
    </>
  );
}
