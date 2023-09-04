import React, { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { urlMovies } from "../utils/endpoints";
import axios, { AxiosResponse } from "axios";
import { movieDetailsDTO } from "./movie.model";
import Loading from "../utils/Loading";
import LeafletMap from "../utils/LeafletMap";
import { coordinateDTO } from "../utils/coordinateDTO";

export default function DetailsMovie() {
    const { id } = useParams();
    const [movieDetails, setMovieDetails] = useState<movieDetailsDTO>();

    useEffect(() => {
        const fetchData = async () => {
            const config = {
                headers: {
                    "x-version": "2",
                },
            };
            try {
                let urlcompleta = `${urlMovies}/${id}`;
                const response: AxiosResponse<ApiResponse<any>> = await axios.get(
                    urlcompleta,
                    config
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
        if (movieDetails?.movie?.cinemas) {
            const coordinates = movieDetails.movie.cinemas.map(cinema => {
                return { latitude: cinema.latitude, longitude: cinema.longitude, name: cinema.name } as coordinateDTO;
            });
            return coordinates;
        }
        return [];
    }

    function generateURLYoutubeEmbed(url: string): string {
        if (!url) {
            return '';
        }
        const video_id = url.split('v=')[1];
        const posAmpersand = video_id.indexOf('&');
        if (posAmpersand !== -1) {
            return `https://www.youtube.com/embed/${video_id.substring(0, posAmpersand)}`;
        }
        return `https://www.youtube.com/embed/${video_id}`;
    }

    function getRandomColor(): string {
        const colors = ["primary", "secondary", "success", "danger", "warning", "info"];
        return `border-${colors[Math.floor(Math.random() * colors.length)]}`;
    }

    return (
        <div className="container mt-5">
            {movieDetails ? (
                <div className="row">
                    <div className="col-md-4">
                        <div className="card mb-3">
                            <img src={movieDetails.movie.posterURL} alt="Imagen del poster" className="card-img-top" />
                        </div>
                        <div className="card">
                            <div className="card-body">
                                <h4 className="card-title">Actores:</h4>
                                {movieDetails.actors?.map(actor => (
                                    <div key={actor.id} className={`d-flex align-items-center mb-3 ${getRandomColor()} rounded`}>
                                        <img src={actor.photoURL} alt={`Foto de ${actor.name}`} className="actor-photo rounded mr-3 border-4 border-secondary" width="100" height="100" />
                                        <div>
                                            <p className="card-text mb-0">{actor.name}</p>
                                            <p className="card-text text-muted mb-0">{actor.character}</p>
                                        </div>
                                    </div>
                                ))}
                            </div>
                        </div>
                    </div>
                    <div className="col-md-8">
                        <h2>{movieDetails.movie.title} ({movieDetails.movie.datePremiere?.getFullYear()})</h2>
                        <p className="text-muted">
                            {movieDetails.genres?.map(genre => (
                                <Link key={genre.id} to={`/movies/filter?genreId=${genre.id}`} className="btn btn-primary btn-sm rounded-pill mr-2">
                                    {genre.name}
                                </Link>
                            ))}
                        </p>
                        <p className="lead">{movieDetails.movie.description}</p>
                        {movieDetails.movie.trailer && (
                            <div className="embed-responsive embed-responsive-16by9 mb-3">
                                <iframe
                                    src={generateURLYoutubeEmbed(movieDetails.movie.trailer)}
                                    title="youtube-trailer"
                                    className="embed-responsive-item"
                                    allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
                                    allowFullScreen
                                ></iframe>
                            </div>
                        )}
                        <div className="card">
                            <div className="card-body">
                                <h4 className="card-title">Reseñas:</h4>
                                {movieDetails.reviews?.map((review, index) => (
                                    <div key={index} className="mb-2">
                                        <p className="card-text mb-0">{review.name}</p>
                                        <p className="card-text text-muted mb-0">Puntuación: {review.score}</p>
                                    </div>
                                ))}
                            </div>
                        </div>

                        <div className="card">
                            <div className="card-body">
                                <h4 className="card-title">Cines:</h4>
                                <LeafletMap coordinates={convertCoordinates()} readOnly={true} />
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
