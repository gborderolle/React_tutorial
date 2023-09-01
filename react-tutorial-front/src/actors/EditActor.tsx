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
      <FormActor
        formName="Modificar actor"
        model={{ name: "", born: new Date(), 
        photoURL:'https://highprofiles.info/wp-content/uploads/2016/04/Yorke-main-900x600.jpg' }}
        onSubmit={async (values) => {
          console.log(values);
        }}
      />
    </>
  );
}
