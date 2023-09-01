import { movie } from "./movie.model";

export default function MovieSingle(props: MovieSingleProps) {
  const setupLink = () => `/movie/${props.movie.id}`;

  return (
    <>
      <div>
        <div className="card" style={{ width: "20rem" }}>
          <a href={setupLink()}>
            <img
              className="card-img-top"
              src={props.movie.poster}
              alt="Poster"
            />
          </a>

          <div className="card-body">
            <h5 className="card-title">{props.movie.title}</h5>
            <p className="card-text">{props.movie.description}</p>
            <a href={setupLink()} className="btn btn-primary">
              Ver película
            </a>
          </div>
        </div>
      </div>
    </>
  );
}

interface MovieSingleProps {
  movie: movie;
}
