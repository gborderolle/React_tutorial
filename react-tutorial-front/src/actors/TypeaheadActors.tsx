// Typeahead: Buscador inteligente
// Clase 88: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25952594#overview

// Clase 89: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25968684#overview
// Mostrar foto junto a la sugerencia

import { Typeahead } from "react-bootstrap-typeahead";
import { actorMovieDTO } from "./actor.model";
import { ReactElement, useState } from "react";

export default function TypeaheadActors(props: typeaheadActorsProps) {
  const actors: actorMovieDTO[] = [
    {
      id: 1,
      name: "Brad Pitt",
      character: "",
      photoURL: "https://flxt.tmsimg.com/assets/1366_v9_bc.jpg",
    },
    {
      id: 2,
      name: "Cillian Murphy",
      character: "",
      photoURL:
        "https://i.guim.co.uk/img/media/7b482387e8703a4abb253b8007b1eadcbe2ba822/1648_678_2104_1262/master/2104.jpg",
    },
    {
      id: 3,
      name: "Margot Robbie",
      character: "",
      photoURL:
        "https://static.wikia.nocookie.net/ideas/images/2/2d/Margot_Robbie.jpg",
    },
    {
      id: 4,
      name: "Bradley Cooper",
      character: "",
      photoURL:
        "https://cdn.britannica.com/57/199057-050-CCE5410A/Bradley-Cooper-2008.jpg",
    },
  ];

  const selection: actorMovieDTO[] = [];
  const [draggedElement, setDraggedElement] = useState<
    actorMovieDTO | undefined
  >(undefined);

  function dragStartEvent(actor: actorMovieDTO) {
    setDraggedElement(actor);
  }

  function dragOverEvent(actor: actorMovieDTO) {
    if (!draggedElement) {
      return;
    }
    if (actor.id !== draggedElement.id) {
      const draggedElementIndex = props.actors.findIndex(
        (x) => x.id === draggedElement.id
      );
      const actorIndex = props.actors.findIndex((x) => x.id === actor.id);

      const actors = [...props.actors];
      actors[actorIndex] = draggedElement;
      actors[draggedElementIndex] = actor;
      props.onAdd(actors);
    }
  }

  return (
    <>
      <label>Actores:</label>
      <Typeahead
        id="typeahead"
        onChange={(actors: any) => {
          if (props.actors.findIndex((x) => x.id === actors[0].id) === -1) {
            props.onAdd([...props.actors, actors[0]]);
          }
        }}
        options={actors}
        labelKey={(actor: any) => actor.name}
        filterBy={["name"]}
        placeholder="Escriba el nombre del actor."
        minLength={2} // cantidad mínima de letras para que comience a sugerir
        flip={true} // true para mostrar las sugerencias hacia arriba
        selected={selection}
        renderMenuItemChildren={(actor: any) => (
          <>
            <img
              src={actor.photoURL}
              alt="Imagen actor"
              style={{
                height: "64px",
                marginRight: "10px",
                width: "64px",
              }}
            />
            <span>{actor.name}</span>
          </>
        )} // mostrar foto junto a la sugerencia
      />

      <ul className="list-group">
        {props.actors.map((actor) => (
          <li
            key={actor.id}
            className="list-group-item list-group-item-action"
            draggable={true}
            onDragStart={() => dragStartEvent(actor)}
            onDragOver={() => dragOverEvent(actor)}
          >
            {props.listUI(actor)}
            <span
              className="badge bg-primary pointer"
              style={{ marginLeft: "0.5rem" }}
              onClick={() => props.onRemove(actor)}
            >
              X
            </span>
          </li>
        ))}
      </ul>
    </>
  );
}

interface typeaheadActorsProps {
  actors: actorMovieDTO[];
  onAdd(actors: actorMovieDTO[]): void;
  listUI(actor: actorMovieDTO): ReactElement;
  onRemove(actor: actorMovieDTO): void;
}
