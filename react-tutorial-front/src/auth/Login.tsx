import FormAuth from "./FormAuth";
import { authResponse, userCredential } from "./auth.model";
import axios from "axios";
import { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { urlAccounts } from "../utils/endpoints";
import ShowErrors from "../utils/ShowErrors";
import { getClaims, saveTokenLocalStorage } from "./ManageJWT";
import AuthenticationContext from "./AuthenticationContext";
import { APIResponse } from "../utils/ApiResponse";
import showToastMessage from "../messages/ShowSuccess";
import Loading from "../utils/Loading";
import { handleErrors } from "../utils/HandleErrors";

export default function Login() {
  const { update } = useContext(AuthenticationContext);
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false); // Nuevo estado para manejar la carga

  async function login(credentials: userCredential) {
    setIsLoading(true); // Activar el estado de carga

    try {
      const url_values = `${urlAccounts}/login`;
      const config_values = {
        headers: {
          "x-version": "2",
        },
      };
      const response = await axios.post<APIResponse<authResponse>>(
        url_values,
        credentials,
        config_values
      );

      if (response.data.isSuccess) {
        saveTokenLocalStorage(response.data.result);
        update(getClaims());

        showToastMessage({
          title: "Login correcto",
          icon: "success",
          callback: () => {
            navigate("/");
          },
        });
      } else {
        setErrors(response.data.errorMessages);
      }
    } catch (error: any) {
      handleErrors(error, setErrors);
    } finally {
      setIsLoading(false); // Desactivar el estado de carga
    }
  }

  return (
    <>
      <h3>Login</h3>
      <ShowErrors errors={errors}></ShowErrors>
      <FormAuth
        model={{ email: "", password: "" }}
        onSubmit={async (values) => await login(values)}
      />
      {isLoading ? <Loading /> : null}{" "}
      {/* Muestra el componente de carga si isLoading es true */}
    </>
  );
}
