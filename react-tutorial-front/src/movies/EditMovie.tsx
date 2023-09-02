import { useNavigate, useParams } from "react-router-dom";
import FormMovie from "./FormMovie";
import { genreDTO } from "../genres/genre.model";
import { cinemaDTO } from "../cinemas/cinema.model";
import { actorMovieDTO } from "../actors/actor.model";

export default function EditMovie() {
  const noSelectedGenres: genreDTO[] = [
    { id: 3, name: "Drama" },
    { id: 4, name: "Comedia" },
  ];

  const selectedGenres: genreDTO[] = [
    { id: 1, name: "Acción" },
    { id: 2, name: "Terror" },
  ];

  const noSelectedCinemas: cinemaDTO[] = [
    {
      id: 1,
      name: "Moviecenter",
      latitude: -34.903330145650386,
      longitude: -56.137249458647425,
    },
    {
      id: 2,
      name: "Life Cinemas",
      latitude: -34.91894597486183,
      longitude: -56.156750917390845,
    },
  ];

  const selectedCinemas: cinemaDTO[] = [
    {
      id: 3,
      name: "Cinemateca",
      latitude: -34.90853352555303,
      longitude: -56.200940150687146,
    },
    {
      id: 4,
      name: "Punta Carretas",
      latitude: -34.92071812554256,
      longitude: -56.15575005033036,
    },
  ];

  const navigate = useNavigate();
  const { id }: any = useParams(); // Para leer parámetros de la URL

  const selectedActors: actorMovieDTO[] = [
    {
      id: 1,
      name: "Brad Pitt",
      character: "",
      photoURL: "https://flxt.tmsimg.com/assets/1366_v9_bc.jpg",
    },
  ];

  if (isNaN(id)) {
    navigate("/movies");
    return null;
  }

  return (
    <FormMovie
      formName="Modificar película"
      model={{ title: "Spider-Man", onCinema: true }}
      onSubmit={async (values) => {
        console.log(values);
      }}
      noSelectedGenres={noSelectedGenres}
      selectedGenres={selectedGenres}
      noSelectedCinemas={noSelectedCinemas}
      selectedCinemas={selectedCinemas}
      selectedActors={selectedActors}
    />
  );
}
