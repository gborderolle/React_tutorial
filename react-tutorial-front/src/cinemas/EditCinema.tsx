import { useNavigate, useParams } from "react-router-dom";

export default function EditCinema() {
    const navigate = useNavigate();
    const { id }: any = useParams(); // Para leer parámetros de la URL
  
    if (isNaN(id)) {
      navigate("/cinemas");
      return null;
    }
  
    return (
      <>
        <h3>Modificar Cine</h3>
        <h4>El id es {id}</h4>
      </>
    );
  }

