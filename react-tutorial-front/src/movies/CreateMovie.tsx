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
import { APIResponse, ResponseId } from "../utils/ApiResponse";

export default function CreateMovie() {
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  const [noSelectedGenres, setNoSelectedGenres] = useState<genreDTO[]>([]);
  const [noSelectedCinemas, setNoSelectedCinemas] = useState<cinemaDTO[]>([]);
  const [loaded, setLoaded] = useState(false);

  async function createMovie(movie: movieCreationDTO) {
    try {
      const url_values = urlMovies;
      const formData = ConvertMovieToFormData(movie);
      const config = {
        headers: {
          "x-version": "2",
          "Content-Type": "multipart/form-data", // importante si endpoint recibe "[FromForm]"
        },
      };
      const response = await axios.post<APIResponse<ResponseId>>(
        url_values,
        formData,
        config
      );
      if (response.data.isSuccess) {
        navigate(`/movies/${response.data.result.id}`);
        setLoaded(true);
      } else {
        setErrors(response.data.errorMessages);
      }
    } catch (error: any) {
      if (
        error.response &&
        error.response.data &&
        error.response.data.errorMessages
      ) {
        setErrors(error.response.data.errorMessages);
      } else {
        setErrors(["Se produjo un error inesperado."]);
      }
    }
  }

  useEffect(() => {
    const url_values = `${urlMovies}/postget`;
    const param_values = {};
    axios
      .get(url_values, {
        headers: { "x-version": "2" },
        params: param_values,
      })
      .then((response: AxiosResponse<moviesPostGetDTO>) => {
        setNoSelectedGenres(response.data.result.genres);
        setNoSelectedCinemas(response.data.result.cinemas);
        setLoaded(true);
      })
      .catch((error: any) => {
        if (error.response && error.response.data) {
          setErrors([error.response.data]); // Asegúrate de que esto es un array
        } else {
          setErrors([error.message || "An unexpected error occurred."]);
        }
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
