import GenericList from "../utils/GenericList";
import Loading from "../utils/Loading";
import { movie } from "./movie.model";
import MovieSingle from "./movieSingle";

export default function ListMovies(props: listMoviesProps) {
  return (
    <GenericList list={props.movies}>
      <div
        id="carouselExampleSlidesOnly"
        className="carousel slide multi-item-carousel"
        data-bs-ride="carousel"
      >
        <div
          className="carousel-inner customCarousel"
          style={{ display: "flex", flexWrap: "wrap" }}
        >
          {props.movies?.map((movie) => (
            <MovieSingle movie={movie} key={movie.id} />
          ))}
        </div>

        <button
          className="carousel-control-prev"
          type="button"
          data-bs-target="#carouselExampleIndicators"
          data-bs-slide="prev"
        >
          <span
            className="carousel-control-prev-icon"
            aria-hidden="true"
          ></span>
          <span className="visually-hidden">Previous</span>
        </button>
        <button
          className="carousel-control-next"
          type="button"
          data-bs-target="#carouselExampleIndicators"
          data-bs-slide="next"
        >
          <span
            className="carousel-control-next-icon"
            aria-hidden="true"
          ></span>
          <span className="visually-hidden">Next</span>
        </button>
      </div>
    </GenericList>
  );
}
interface listMoviesProps {
  movies?: movie[];
}
