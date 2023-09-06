import React, { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { urlMovies, urlRatings } from "../utils/endpoints";
import axios, { AxiosResponse } from "axios";
import { movieDetailsDTO } from "./movie.model";
import Loading from "../utils/Loading";
import LeafletMap from "../utils/LeafletMap";
import { coordinateDTO } from "../utils/coordinateDTO";
import moment from "moment";
import Rating from "../utils/Rating";
import Swal from "sweetalert2";

export default function DetailsMovie() {
  const { id } = useParams();
  const [movieDetails, setMovieDetails] = useState<movieDetailsDTO>();
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const url_values = `${urlMovies}/${id}`;
        const param_values = {};
        const response: AxiosResponse<ApiResponse<any>> = await axios.get(
          url_values,
          {
            headers: { "x-version": "2" },
            params: param_values,
          }
        );
        if (response && response.data && response.data.result) {
          setMovieDetails(response.data.result);
        } else {
          throw new Error("Formato de datos inesperado de la API.");
        }
      } catch (error: any) {
        console.error(error);
      }
    };
    fetchData();
  }, [id]);

  function convertCoordinates(): coordinateDTO[] {
    if (movieDetails?.cinemas) {
      const coordinates = movieDetails.cinemas.map((cinema) => {
        return {
          latitude: cinema.latitude,
          longitude: cinema.longitude,
          name: cinema.name,
        } as coordinateDTO;
      });
      return coordinates;
    }
    return [];
  }

  function generateURLYoutubeEmbed(url: string): string {
    if (!url || !url.includes("&")) {
      return "";
    }
    const video_id = url.split("v=")[1];
    const posAmpersand = video_id.indexOf("&");
    if (posAmpersand !== -1) {
      return `https://www.youtube.com/embed/${video_id.substring(
        0,
        posAmpersand
      )}`;
    }
    return `https://www.youtube.com/embed/${video_id}`;
  }

  function getRandomColor(): string {
    const colors = [
      "primary",
      "secondary",
      "success",
      "danger",
      "warning",
      "info",
    ];
    return `border-${colors[Math.floor(Math.random() * colors.length)]}`;
  }

  async function onVote(vote: number) {
    try {
      const url_values = `${urlRatings}`;
      const param_values = {
        movieId: +id!,
        score: vote,
      };
      axios.post(url_values, {
        headers: { "x-version": "2" },
        params: param_values,
      });

      // await axios.post(url_values, model_values, config_values);
      Swal.fire({ icon: "success", title: "Voto recibido" });

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

  /*

  async function onVote(vote: number) {
    try {
      const url_values = urlRatings;
      const config_values = {
        headers: {
          "x-version": "2",
        },
      };
      const model_values = {
        movieId: +id!,
        score: vote,
      };

      console.log(url_values);
      console.log(model_values);
      console.log(config_values);

      await axios.post(
        url_values,
        { movieId: +id!, score: vote },
        config_values
      );
      // await axios.post(url_values, model_values, config_values);
      Swal.fire({ icon: "success", title: "Voto recibido" });

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


  */

  return (
    <div className="container mt-5">
      {movieDetails ? (
        <div className="row">
          <div className="col-md-4">
            <div className="card mb-3">
              <img
                src={movieDetails.movie.posterURL}
                alt="Imagen del poster"
                className="card-img-top"
              />
            </div>
            <div className="card">
              <div className="card-body">
                <h4 className="card-title">Actores:</h4>
                {movieDetails.actors?.map((actor) => (
                  <div
                    key={actor.id}
                    className={`d-flex align-items-center mb-3 ${getRandomColor()} rounded`}
                  >
                    <img
                      src={actor.photoURL}
                      alt={`Foto de ${actor.name}`}
                      className="actor-photo rounded mr-3 border-4 border-secondary"
                      width="100"
                      height="100"
                    />
                    <div>
                      <p className="card-text mb-0">{actor.name}</p>
                      <p className="card-text text-muted mb-0">
                        {actor.character}
                      </p>
                    </div>
                  </div>
                ))}
              </div>
            </div>
            <br />
            <div className="card">
              <div className="card-body">
                <h4 className="card-title">Reseñas:</h4>
                {movieDetails.reviews?.map((review, index) => (
                  <div key={index} className="mb-2">
                    <p className="card-text mb-0">{review.name}</p>
                    <p className="card-text text-muted mb-0">
                      Puntuación: {review.score}
                    </p>
                  </div>
                ))}
              </div>
            </div>
          </div>
          <div className="col-md-8">
            <div className="row">
              <div className="col d-flex align-items-center">
                <h2>
                  {movieDetails.movie.title} (
                  {moment(movieDetails.movie.premiere).toDate().getFullYear()})
                </h2>
                <Link key={id} to={`/movies/edit/${id}`} className="m-2">
                  Editar
                </Link>
              </div>
            </div>
            <div>
              Tu voto:{" "}
              <Rating maxValue={5} selectedValue={0} onChange={onVote} />
            </div>

            <p className="text-muted">
              {movieDetails.genres?.map((genre) => (
                <Link
                  key={genre.id}
                  to={`/movies/filter?genreId=${genre.id}`}
                  className="btn btn-primary btn-sm rounded m-1"
                >
                  {genre.name}
                </Link>
              ))}
            </p>
            <div className="card">
              <div className="card-body">
                <h4 className="card-title">Sinópsis:</h4>
                <p className="lead">{movieDetails.movie.description}</p>
              </div>
            </div>
            <br />
            <div className="card">
              <div className="card-body">
                <h4 className="card-title">Trailer:</h4>
                <div className="embed-responsive embed-responsive-16by9 mb-3">
                  {movieDetails.movie.trailer && (
                    <iframe
                      src={generateURLYoutubeEmbed(movieDetails.movie.trailer)}
                      title="youtube-trailer"
                      className="embed-responsive-item"
                      allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
                      allowFullScreen
                    ></iframe>
                  )}
                </div>
              </div>
            </div>
            <br />
            <div className="card">
              <div className="card-body">
                <h4 className="card-title">Cines:</h4>
                {movieDetails.cinemas && movieDetails.cinemas.length > 0 && (
                  <LeafletMap
                    coordinates={convertCoordinates()}
                    readOnly={true}
                  />
                )}
              </div>
            </div>
          </div>
        </div>
      ) : (
        <Loading />
      )}
    </div>
  );
}

interface ApiResponse<T> {
  isSuccess: boolean;
  result: T;
}
