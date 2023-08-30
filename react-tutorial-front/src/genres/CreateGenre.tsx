import { useNavigate } from "react-router-dom";
import Button from "../utils/Button";

export default function CreateGenre() {
    const navigate = useNavigate();
    return (
        <>
            <h3>Crear Género</h3>
            <Button onClick={() => navigate('/genres')}>Guardar</Button>
        </>
    );
}
