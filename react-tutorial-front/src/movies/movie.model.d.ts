export interface movie {
  id: number;
  title: string;
  poster: string;
  description: string;
}

export interface landingPageDTO {
    moviesInTheatres?: movie[];
    moviesNextReleases?: movie[];
}