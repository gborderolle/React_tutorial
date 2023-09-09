import axios from "axios";
import { urlAccounts } from "../utils/endpoints";
import FormAuth from "./FormAuth";
import { authResponse, userCredential as userCredential } from "./auth.model";
import { useNavigate } from "react-router-dom";
import { useContext, useState } from "react";
import ShowErrors from "../utils/ShowErrors";
import { saveTokenLocalStorage, getClaims } from "./ManageJWT";
import AuthenticationContext from "./AuthenticationContext";
import { APIResponse } from "../utils/ApiResponse";
import { handleErrors } from "../utils/HandleErrors";

export default function Register() {
  const { update } = useContext(AuthenticationContext);
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  async function register(credentials: userCredential) {
    const url_values = `${urlAccounts}/register`;
    const config_values = {
      headers: {
        "x-version": "2",
      },
    };

    try {
      const response = await axios.post<APIResponse<authResponse>>(
        url_values,
        credentials,
        config_values
      );

      if (response.data.isSuccess) {
        saveTokenLocalStorage(response.data.result);
        update(getClaims());
        navigate("/");
      } else {
        setErrors(response.data.errorMessages);
      }
    } catch (error: any) {
      handleErrors(error, setErrors);
    }
  }

  return (
    <>
      <h3>Registro</h3>
      <ShowErrors errors={errors} />
      <FormAuth
        model={{ email: "", password: "" }}
        onSubmit={async (values) => await register(values)}
      />
    </>
  );
}
