import axios, { AxiosResponse, isAxiosError } from "axios";
import FormMovie from "./FormMovie";
import { urlMovies } from "../utils/endpoints";
import { movieCreationDTO, movieDTO, moviePutGetDTO } from "./movie.model";
import { ConvertMovieToFormData } from "../utils/FormDataUtils";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Loading from "../utils/Loading";
import ShowErrors from "../utils/ShowErrors";

export default function EditMovie() {
  const navigate = useNavigate();
  const { id }: any = useParams();
  const [errors, setErrors] = useState<string[]>([]);

  const initial_moviePutGetDTO: moviePutGetDTO = {
    movie: {
      title: "",
      onCinema: true,
    },
    noSelectedGenres: [],
    selectedGenres: [],
    noSelectedCinemas: [],
    selectedCinemas: [],
    actors: [],
  };

  const [moviePutGet, setMoviePutGet] = useState<moviePutGetDTO>(
    initial_moviePutGetDTO
  );

  const [movie, setMovie] = useState<movieCreationDTO>({
    title: "",
    onCinema: true,
  });

  useEffect(() => {
    const fetchData = async () => {
      const config = {
        headers: {
          "x-version": "2",
        },
      };
      let urlcompleta = `${urlMovies}/${id}`;
      console.log("request: " + urlcompleta);

      try {
        const response: AxiosResponse<moviePutGetDTO> = await axios.get(
          urlcompleta,
          config
        );
        if (response && response.data) {
          const model: movieCreationDTO = {
            title: response.data.movie.title,
            onCinema: response.data.movie.onCinema,
            trailer: response.data.movie.trailer,
            posterURL: response.data.movie.posterURL,
            description: response.data.movie.description,
            //premiere: new Date(response.data.movie.premiere),
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
      const formData = ConvertMovieToFormData(editMovie);
      await axios.put<ApiResponse<any>>(`${urlMovies}/${id}`, formData, {
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

  console.log("movie:" + movie);
  console.log(movie);
  console.log("moviePutGet:" + moviePutGet);
  console.log(moviePutGet);

  return (
    <>
      <ShowErrors errors={errors}></ShowErrors>
      {movie && moviePutGet ? (
        <FormMovie
          formName="Modificar película"
          model={movie}
          onSubmit={(values) => editMovie(values)}
          noSelectedGenres={moviePutGet.noSelectedGenres || []} // Verificación de Nullidad aquí
          selectedGenres={moviePutGet.selectedGenres || []} // Verificación de Nullidad aquí
          noSelectedCinemas={moviePutGet.noSelectedCinemas || []} // Verificación de Nullidad aquí
          selectedCinemas={moviePutGet.selectedCinemas || []} // Verificación de Nullidad aquí
          selectedActors={moviePutGet.actors || []} // Verificación de Nullidad aquí
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
