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
}

export interface landingPageDTO {
  moviesInTheatres?: movie[];
  moviesNextReleases?: movie[];
}
