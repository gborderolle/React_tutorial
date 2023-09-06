import axios from "axios";
import FormActor from "./FormActor";
import { actorCreationDTO } from "./actor.model";
import { urlActors } from "../utils/endpoints";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import ShowErrors from "../utils/ShowErrors";

export default function CreateActor() {
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  async function createActor(actor: actorCreationDTO) {
    try {
      const url_values = urlActors;
      const config_values = {
        headers: {
          "x-version": "2",
          "Content-Type": "multipart/form-data", // importante si endpoint recibe "[FromForm]"
        },
      };
      await axios.post(url_values, actor, config_values);

      navigate("/actors");
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
      <ShowErrors errors={errors} />
      <FormActor
        formName="Crear actor"
        model={{ name: "" }}
        onSubmit={async (values) => {
          await createActor(values);
        }}
      />
    </>
  );
}
