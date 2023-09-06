import axios from "axios";
import { urlAccounts } from "../utils/endpoints";
import FormAuth from "./FormAuth";
import { authResponse, userCredential as userCredential } from "./auth.model";
import { useNavigate } from "react-router-dom";
import { useContext, useState } from "react";
import ShowErrors from "../utils/ShowErrors";
import { saveTokenLocalStorage, getClaims } from "./ManageJWT";
import AuthenticationContext from "./AuthenticationContext";

export default function Register() {
  const { update } = useContext(AuthenticationContext);
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  async function register(credentials: userCredential) {
    try {
      const url_values = `${urlAccounts}/register`;
      const config_values = {
        headers: {
          "x-version": "2",
        },
      };
      const response = await axios.post<authResponse>(
        url_values,
        credentials,
        config_values
      );

      saveTokenLocalStorage(response.data);
      update(getClaims());
      navigate("/");
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
      <h3>Registro</h3>
      <ShowErrors errors={errors} />
      <FormAuth
        model={{ email: "", password: "" }}
        onSubmit={async (values) => await register(values)}
      />
    </>
  );
}
