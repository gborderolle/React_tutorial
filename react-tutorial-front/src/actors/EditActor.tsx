import { useNavigate, useParams } from "react-router-dom";

export default function EditActor() {
  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  if (isNaN(id)) {
    navigate("/actors");
    return null;
  }

  return (
    <>
      <h3>Modificar Actor</h3>
      <h4>El id es {id}</h4>
    </>
  );
}
