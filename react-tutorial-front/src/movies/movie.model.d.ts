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
