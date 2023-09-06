import axios, { AxiosResponse, isAxiosError } from "axios";
import FormMovie from "./FormMovie";
import { urlMovies } from "../utils/endpoints";
import { movieCreationDTO, movieDTO, moviePutGetDTO } from "./movie.model";
import { ConvertMovieToFormData } from "../utils/FormDataUtils";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Loading from "../utils/Loading";
import ShowErrors from "../utils/ShowErrors";
import moment from "moment";

export default function EditMovie() {
  const navigate = useNavigate();
  const { id }: any = useParams();
  const [errors, setErrors] = useState<string[]>([]);

  const [moviePutGet, setMoviePutGet] = useState<moviePutGetDTO>();
  const [movie, setMovie] = useState<movieCreationDTO>();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const url_values = `${urlMovies}/putget/${id}`;
        const param_values = {};
        const response: AxiosResponse<moviePutGetDTO> = await axios.get(
          url_values,
          {
            headers: { "x-version": "2" },
            params: param_values,
          }
        );
        if (response && response.data) {
          const { movie } = response.data;
          const model: movieCreationDTO = {
            title: movie.title,
            onCinema: movie.onCinema,
            trailer: movie.trailer,
            posterURL: movie.posterURL,
            description: movie.description,
            premiere: moment(movie.premiere).toDate(),
          };

          setMovie(model);
          setMoviePutGet(response.data);
        } else {
          throw new Error("Formato de datos inesperado de la API.");
        }
      } catch (error: any) {
        if (error.response && error.response.data) {
          setErrors([error.response.data]); // Asegúrate de que esto es un array
        } else {
          setErrors([error.message || "Ha ocurrido un error inesperado."]);
        }
      }
    };

    fetchData();
  }, [id]);

  const editMovie = async (editMovie: movieCreationDTO) => {
    try {
      const url_values = `${urlMovies}/${id}`;
      const formData = ConvertMovieToFormData(editMovie);
      await axios.put<ApiResponse<any>>(url_values, formData, {
        headers: {
          "x-version": "2",
          "Content-Type": "multipart/form-data", // importante si endpoint recibe "[FromForm]"
        },
      });
      navigate("/movies");
    } catch (error) {
      if (isAxiosError(error) && error.response) {
        setErrors(error.response.data);
      } else {
        setErrors(["An unexpected error occurred."]);
      }
    }
  };

  return (
    <>
      <ShowErrors errors={errors}></ShowErrors>
      {movie && moviePutGet ? (
        <FormMovie
          formName="Modificar película"
          noSelectedGenres={moviePutGet.noSelectedGenres}
          selectedGenres={moviePutGet.selectedGenres}
          noSelectedCinemas={moviePutGet.noSelectedCinemas}
          selectedCinemas={moviePutGet.selectedCinemas}
          selectedActors={moviePutGet.actorMovieDTO || []}
          model={movie}
          onSubmit={async (values) => await editMovie(values)}
        />
      ) : (
        <Loading />
      )}
    </>
  );
}

interface ApiResponse<T> {
  isSuccess: boolean;
  result: T;
}
