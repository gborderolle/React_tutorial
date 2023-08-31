import { useState, useEffect } from "react";
import { landingPageDTO } from "./movies/movie.model";
import ListMovies from "./movies/ListMovies";

export default function LandingPage() {
  const [movies, setMovies] = useState<landingPageDTO>({});

  useEffect(() => {
    const timerId = setTimeout(() => {
      setMovies({
        moviesInTheatres: [
          {
            id: 1,
            title: "The Equalizer 3",
            description:
              "Desde que renunció a su vida como asesino del gobierno, Robert McCall ha luchado para reconciliarse con las cosas horribles que ha hecho en el pasado y encuentra un extraño consuelo en hacer justicia en nombre de los oprimidos. Mientras se encuentra en su casa en el sur de Italia, descubre que sus nuevos amigos están bajo el control de los jefes del crimen local.",
            poster:
              "https://www.elseptimoarte.net/carteles/341/the_equalizer_3_98440.jpg",
          },
          {
            id: 2,
            title: "Talk to me",
            description:
              "Cuando un grupo de amigos descubre cómo invocar espíritus utilizando una mano embalsamada, se enganchan a esta nueva sensación hasta que uno de ellos va demasiado lejos y abre la puerta al mundo de los espíritus, obligándoles a elegir en quién confiar: En los muertos o en los vivos.",
            poster:
              "https://www.elseptimoarte.net/carteles/341/hablame_97828.jpg",
          },
          {
            id: 3,
            title: "Irgendwann werden wir uns alles erzählen",
            description:
              "Verano de 1990, antigua Alemania Oriental. María está a punto de cumplir 19 años y vive en la granja de los padres de su novio Johannes. En un ambiente lleno de posibilidades y con una sensación de inicio de una nueva era con la reunificación alemana, María prefiere perderse en los libros que concentrarse en graduarse. A esto se le añade el inicio de una pasión secreta y un nuevo amor hacia Henner, el carismático y determinante granjero de al lado que le dobla la edad.",
            poster:
              "https://www.elseptimoarte.net/carteles/341/algun_dia_nos_lo_contaremos_todo_98130.jpg",
          },
        ],
        moviesNextReleases: [
          {
            id: 4,
            title: "The Old Guard 2",
            description:
              "Basada en las novelas gráficas de Greg Rucka y Leandro Fernández, la primera entrega sigue a un equipo encubierto de mercenarios inmortales que, de repente, quedan expuestos al mundo. Es entonces cuando deben luchar para mantener su identidad en secreto justo cuando se les une un nuevo e inesperado miembro.",
            poster:
              "https://es.web.img3.acsta.net/c_310_420/pictures/21/08/27/10/48/0715374.png",
          },
          {
            id: 5,
            title: "La monja II",
            description:
              "Año 1956. En Francia donde el mal campa a sus anchas, con un sacerdote asesinado, y todas las señales apuntan al demonio Valak. La hermana Irene tendrá que enfrentarse a esta malévola pero familiar fuerza que debe ser contenida a toda costa.",
            poster:
              "https://es.web.img3.acsta.net/c_310_420/pictures/23/07/18/09/37/2734596.jpg",
          },
          {
            id: 6,
            title: "Kraven The Hunter",
            description:
              "Película de acción y fantasía que gira en torno al origen del icónico supervillano Kraven el Cazador, antagonista de Spider Man. Desde joven, Sergei Kravinoff (Aaron Taylor-Johnson) fue entrenado para convertirse en un despiadado cazador. Ahora, transformado en Kraven el Cazador, deberá afrontar su pasado haciendo uso de sus excepcionales habilidades para la lucha y la caza.",
            poster:
              "https://es.web.img3.acsta.net/c_310_420/pictures/23/06/20/10/18/3149358.jpg",
          },
        ],
      });
    }, 1000);
    return () => clearTimeout(timerId);
  });

  return (
    <>
      <div className="mt-4">
        <h3>En Cartelera</h3>
        <ListMovies movies={movies.moviesInTheatres} />
        <h3>Próximos estrenos</h3>
        <ListMovies movies={movies.moviesNextReleases} />
      </div>
    </>
  );
}
