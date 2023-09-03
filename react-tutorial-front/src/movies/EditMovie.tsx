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
  const [movie, setMovie] = useState<movieCreationDTO>();
  const [moviePutGet, setMoviePutGet] = useState<moviePutGetDTO>();
  const [errors, setErrors] = useState<string[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get<ApiResponse<any>>(`${urlMovies}/PutGet/${id}`, {
          headers: {
            "x-version": "2",
          },
        });

        if (response && response.data) {
          const model: movieCreationDTO = {
            title: response.data.result.movie.title,
            onCinema: response.data.result.movie.onCinema,
            trailer: response.data.result.movie.trailer,
            posterURL: response.data.result.movie.posterURL,
            description: response.data.result.movie.description,
            datePremiere: new Date(response.data.result.movie.datePremiere),
          };

          setMovie(model);
          setMoviePutGet(response.data.result);
        } else {
          throw new Error("Unexpected data format from the API.");
        }

      } catch (error) {
        if (isAxiosError(error) && error.message) {
          setErrors([error.message]);
        } else {
          setErrors(["An unexpected error occurred."]);
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

  return (
    <>
      <ShowErrors errors={errors}></ShowErrors>
      {movie && moviePutGet ? (
        <FormMovie
          formName="Modificar película"
          model={movie}
          onSubmit={(values) => editMovie(values)}
          noSelectedGenres={moviePutGet.noSelectedGenres}
          selectedGenres={moviePutGet.selectedGenres}
          noSelectedCinemas={moviePutGet.noSelectedCinemas}
          selectedCinemas={moviePutGet.selectedCinemas}
          selectedActors={moviePutGet.actors}
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
