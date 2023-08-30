import { useNavigate, useParams } from "react-router-dom";

export default function EditMovie() {
  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  if (isNaN(id)) {
    navigate("/movies");
    return null;
  }

  return (
    <>
      <h3>Modificar Película</h3>
      <h4>El id es {id}</h4>
    </>
  );
}
