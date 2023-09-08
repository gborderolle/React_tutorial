import axios from "axios";
import FormGenre from "./FormGenre";
import { genreCreationDTO } from "./genre.model";
import { urlGenres } from "../utils/endpoints";
import { useNavigate } from "react-router-dom";
import ShowErrors from "../utils/ShowErrors";
import { useState } from "react";
import showSuccess from "../messages/ShowSuccess";

export default function CreateGenre() {
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  async function createGenre(genre: genreCreationDTO) {
    try {
      const url_values = urlGenres;
      const config_values = {
        headers: {
          "x-version": "2",
        },
      };
      await axios.post(url_values, genre, config_values);

      showSuccess('Creación correcta');
      setTimeout(() => {
        navigate("/genres");
      }, 2000);
    } catch (error: any) {
      if (error.response && error.response.data) {
        setErrors([error.response.data]); // Asegúrate de que esto es un array
      } else {
        setErrors([error.message || "An unexpected error occurred."]);
      }
    }
  }

  return (
    <>
      <ShowErrors errors={errors} />
      <FormGenre
        formName="Crear género"
        model={{ name: "" }}
        onSubmit={async (values) => {
          await createGenre(values);
        }}
      />
    </>
  );
}
