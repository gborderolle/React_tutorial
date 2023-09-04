import { useState, useEffect } from "react";
import { landingPageDTO } from "./movies/movie.model";
import ListMovies from "./movies/ListMovies";
import axios, { AxiosResponse, isAxiosError } from "axios";
import { urlActors, urlMovies } from "./utils/endpoints";

export default function LandingPage() {
  const [errors, setErrors] = useState<string[]>([]);
  const [movies, setMovies] = useState<landingPageDTO>({});

  useEffect(() => {
    loadData();
  }, []);

  function loadData() {
    axios
      .get(`${urlMovies}`, {
        headers: {
          "x-version": "2",
        },
      })
      .then((response: AxiosResponse) => {
        if (response.data.isSuccess && Array.isArray(response.data.result)) {
          setMovies({
            moviesInTheatres: response.data.result,
            moviesNextReleases: [],
          });
        } else {
          console.error("Unexpected data format from the API.");
        }
      })
      .catch((error) => {
        if (isAxiosError(error) && error.response) {
          setErrors(error.response.data);
        } else {
          console.error(error);
        }
      });
  }

  return (
    <div className="container mt-4">
      <div className="row">
        <div className="col">
          <h3>En Cartelera</h3>
          <ListMovies movies={movies.moviesInTheatres} />
        </div>
      </div>
      <div className="row mt-4">
        <div className="col">
          <h3>Próximos estrenos</h3>
          <ListMovies movies={movies.moviesNextReleases} />
        </div>
      </div>
    </div>
  );
}
