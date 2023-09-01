// Leer variables de la URL
// Clase 67: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858580#overview

import { useNavigate, useParams } from "react-router-dom";
import Button from "../utils/Button";
import FormActor from "../actors/FormActor";
import FormGenre from "./FormGenre";

export default function EditGenre() {
  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  if (isNaN(id)) {
    navigate("/genres");
    return null;
  }

  return (
    <>
      <FormGenre
        formName="Modificar género"
        model={{ name: ""}}
        onSubmit={async (values) => {
          console.log(values);
        }}
      />
    </>
  )
}
