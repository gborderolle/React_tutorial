import axios from "axios";
import Button from "../utils/Button";
import IndexEntity from "../utils/IndexEntity";
import { urlAccounts } from "../utils/endpoints";
import { userDTO } from "./auth.model";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import showConfirm from "../utils/ShowConfirm";
import showSuccess from "../messages/ShowSuccess";

export default function IndexUsers() {
    const navigate = useNavigate(); // sirve para navegar entre las páginas
    const [errors, setErrors] = useState<string[]>([]);

    async function makeAdmin(id: string) {
        await editAdmin(`${urlAccounts}/makeAdmin`, id);
    }

    async function removeAdmin(id: string) {
        await editAdmin(`${urlAccounts}/deleteAdmin`, id);
    }

    async function editAdmin(url: string, id: string) {
        try {
            const url_values = url;
            const config_values = {
                headers: {
                    "x-version": "2",
                    "Content-Type": "application/json",
                },
            };
            await axios.post(url_values, JSON.stringify(id), config_values);

            showSuccess('Creación correcta');
            setTimeout(() => {
                navigate("/");
            }, 2000);
        } catch (error: any) {
            if (error.response && error.response.data) {
                setErrors(error.response.data);
            } else {
                // handle other errors or set a default error message
                setErrors(["An unexpected error occurred."]);
            }
        }
    }

    return (
        <>
            <IndexEntity<userDTO>  // Asegúrate de que 'UserDTO' esté importado o definido en tu archivo
                url={`${urlAccounts}/users`}
                title="Usuarios"
            >
                {users => (
                    <>
                        <thead>
                            <tr>
                                <th></th>
                                <th>Nombre</th>
                            </tr>
                        </thead>
                        <tbody>
                            {users?.map(user => (
                                <tr key={user.id}>
                                    <td>
                                        <Button
                                            className="btn btn-sm btn-primary me-2"
                                            onClick={() => showConfirm(() => makeAdmin(user.id), `¿Desea hacer a ${user.email} admin?`, 'Realizar')}
                                        >
                                            Hacer Admin
                                        </Button>
                                        <Button
                                            className="btn btn-sm btn-danger"
                                            onClick={() => showConfirm(() => removeAdmin(user.id), `¿Desea remover a ${user.email} como admin?`, 'Realizar')}
                                        >
                                            Remover Admin
                                        </Button>
                                    </td>
                                    <td>
                                        {user.email}
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </>
                )}
            </IndexEntity>

        </>
    );
}
