// Clase 143: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26095218#notes

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
    console.log(`${urlMovies}/PutGet/${id}`);

    axios
      .get(`${urlMovies}/PutGet/${id}`)
      //.then((response: AxiosResponse<moviePutGetDTO>) => {
      .then((response: AxiosResponse<any>) => {
        const model: movieCreationDTO = {
          title: response.data.movie.title,
          onCinema: response.data.movie.onCinema,
          trailer: response.data.movie.trailer,
          posterURL: response.data.movie.posterURL,
          description: response.data.movie.description,
          datePremiere: new Date(response.data.movie.datePremiere),
        };
        setMovie(model);
        setMoviePutGet(response.data.result);
      });
  }, [id]);

  async function editMovie(editMovie: movieCreationDTO) {
    try {
      const formData = ConvertMovieToFormData(editMovie);
      await axios.put<ApiResponse<any>>(`${urlMovies}/${id}`, formData, {
        headers: {
          "x-version": "2",
          "Content-Type": "multipart/form-data", // importante si endpoint recibe "[FromForm]"
        },
      });
    } catch (error) {
      if (isAxiosError(error) && error.response) {
        setErrors(error.response.data);
      } else {
        setErrors(["An unexpected error occurred."]);
      }
    }
    navigate("/movies");
  }

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

// ShowErrors errors={errors}></ShowErrors>
//       {movie && moviePutGet ? (
//         <EditEntity<movieCreationDTO, movieDTO>
//           url={urlMovies}
//           urlIndex="/movies"
//           entityName="Movies"
//           transformFormData={ConvertMovieToFormData}
//         >
//           {(entity, edit) => (
//             <FormMovie
//               formName="Modificar película"
//               model={entity!}
//               onSubmit={(values) => edit(values)}
//               noSelectedGenres={moviePutGet.noSelectedGenres}
//               selectedGenres={moviePutGet.selectedGenres}
//               noSelectedCinemas={moviePutGet.noSelectedCinemas}
//               selectedCinemas={moviePutGet.selectedCinemas}
//               selectedActors={moviePutGet.actors}
//             />
//           )}
//         </EditEntity>
