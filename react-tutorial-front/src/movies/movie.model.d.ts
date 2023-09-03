import { actorMovieDTO } from "../actors/actor.model";

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

// export interface moviesPostGetDTO {
//   genres: genreDTO[];
//   cinemas: cinemaDTO[];
// }

export type moviesPostGetDTO = {
  result: {
    genres: genreDTO[],
    cinemas: cinemaDTO[]
  }
};
