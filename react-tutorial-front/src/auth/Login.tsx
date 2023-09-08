import { FormikHelpers } from "formik";
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
import showSuccess from "../messages/ShowSuccess";

export default function Login() {
  const { update } = useContext(AuthenticationContext);
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  async function login(credentials: userCredential) {
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

      saveTokenLocalStorage(response.data.result);
      update(getClaims());

      showSuccess('Login correcto');
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
      <h3>Login</h3>
      <ShowErrors errors={errors}></ShowErrors>
      <FormAuth
        model={{ email: "", password: "" }}
        onSubmit={async (values) => await login(values)}
      />
    </>
  );
}
