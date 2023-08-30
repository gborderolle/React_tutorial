import { useNavigate, useParams } from "react-router-dom";

export default function EditReview() {
  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  if (isNaN(id)) {
    navigate("/genres");
    return null;
  }

  return (
    <>
      <h3>Modificar Género</h3>
      <h4>El id es {id}</h4>
    </>
  );
}
