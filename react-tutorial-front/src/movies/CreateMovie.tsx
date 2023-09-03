import axios, { AxiosResponse } from "axios";
import FormMovie from "./FormMovie";
import { movieCreationDTO, moviesPostGetDTO } from "./movie.model";
import { urlMovies } from "../utils/endpoints";
import { useNavigate } from "react-router-dom";
import ShowErrors from "../utils/ShowErrors";
import { useEffect, useState } from "react";
import { genreDTO } from "../genres/genre.model";
import { cinemaDTO } from "../cinemas/cinema.model";
import Loading from "../utils/Loading";
import { ConvertMovieToFormData } from "../utils/FormDataUtils";

export default function CreateMovie() {
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  const [noSelectedGenres, setNoSelectedGenres] = useState<genreDTO[]>([]);
  const [noSelectedCinemas, setNoSelectedCinemas] = useState<cinemaDTO[]>([]);
  const [loaded, setLoaded] = useState(false);

  async function createMovie(movie: movieCreationDTO) {
    try {
      //const formData = ConvertMovieToFormData(movie);

      const config = {
        headers: {
          "x-version": "2",
          "Content-Type": "multipart/form-data", // importante si endpoint recibe "[FromForm]"
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

  useEffect(() => {
    axios
      .get(`${urlMovies}/postget`)
      .then((response: AxiosResponse<moviesPostGetDTO>) => {
        setNoSelectedGenres(response.data.genres);
        setNoSelectedCinemas(response.data.cinemas);
        setLoaded(true);
      });
  }, []);

  return (
    <>
      <ShowErrors errors={errors} />
      {loaded ? (
        <FormMovie
          formName="Crear película"
          model={{ title: "", onCinema: true }}
          onSubmit={async (values) => {
            await createMovie(values);
          }}
          selectedGenres={[]}
          noSelectedGenres={noSelectedGenres} //
          selectedCinemas={[]}
          noSelectedCinemas={noSelectedCinemas} //
          selectedActors={[]}
        />
      ) : (
        <Loading />
      )}
    </>
  );
}
