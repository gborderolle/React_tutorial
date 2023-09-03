import { actorMovieDTO } from "../actors/actor.model";
import { cinemaDTO } from "../cinemas/cinema.model";

export interface movie {
  id: number;
  title: string;
  poster: string;
  description: string;
}
export interface movieCreationDTO {
  title: string;
  onCinema: boolean;
  trailer?: string;
  description?: string;
  datePremiere?: Date;
  poster?: File;
  posterURL?: string;
  genreIds?: number[];
  cinemaIds?: number[];
  actors?: actorMovieDTO[];
}

export interface landingPageDTO {
  moviesInTheatres?: movie[];
  moviesNextReleases?: movie[];
}

export interface movieDTO {
  id: number;
  title: string;
  posterURL?: string;
  description?: string;
}

export interface moviePutGetDTO {
  movie: movieCreationDTO;
  selectedGenres: genreDTO[];
  noSelectedGenres: genreDTO[];
  selectedCinemas: cinemaDTO[];
  noSelectedCinemas: cinemaDTO[];
  actors: actorMovieDTO[];
}

export type moviesPostGetDTO = {
  result: {
    genres: genreDTO[];
    cinemas: cinemaDTO[];
  };
};
