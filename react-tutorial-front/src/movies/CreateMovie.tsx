import axios from "axios";
import FormMovie from "./FormMovie";
import { movieCreationDTO } from "./movie.model";
import { urlMovies } from "../utils/endpoints";
import { useNavigate } from "react-router-dom";
import ShowErrors from "../utils/ShowErrors";
import { useState } from "react";

export default function CreateMovie() {
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  async function createMovie(movie: movieCreationDTO) {
    try {
      const config = {
        headers: {
          "x-version": "2",
        },
      };
      await axios.post(urlMovies, movie, config);
      navigate("/movies");
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
      <FormMovie
        formName="Crear película"
        model={{ title: "", onCinema: true }}
        onSubmit={async (values) => {
          await new Promise((r) => setTimeout(r, 1000));
          console.log(values);
        }}
        selectedGenres={[]}
        noSelectedGenres={[]} //
        selectedCinemas={[]}
        noSelectedCinemas={[]} //
        selectedActors={[]}
      />
    </>
  );
}
