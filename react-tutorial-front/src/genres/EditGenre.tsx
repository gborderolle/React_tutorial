import { useParams } from "react-router-dom"

export default function EditGenre() {
    const { id }: any = useParams();

    return (
        <><h3>Modificar Género</h3>
            <h4>El id es {id}</h4></>
    )
}