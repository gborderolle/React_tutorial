import { cinemaDTO } from "../cinemas/cinema.model";
import { genreDTO } from "../genres/genre.model";
import FormMovie from "./FormMovie";

export default function CreateMovie() {
  const genres: genreDTO[] = [
    { id: 1, name: "Acción" },
    { id: 2, name: "Terror" },
    { id: 3, name: "Drama" },
    { id: 4, name: "Comedia" },
  ];

  const cinemas: cinemaDTO[] = [
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

  return (
    <>
      <FormMovie
        formName="Crear película"
        model={{ title: "", onCinema: true }}
        onSubmit={async (values) => {
          await new Promise((r) => setTimeout(r, 1000));
          console.log(values);
        }}
        selectedGenres={[]}
        noSelectedGenres={genres}
        selectedCinemas={[]}
        noSelectedCinemas={cinemas}
        selectedActors={[]}
      />
    </>
  );
}
