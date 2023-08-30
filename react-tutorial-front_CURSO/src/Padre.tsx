// useContext: una especie de patrón de diseño Observer: para actualizar todos los componentes que esuchen en este caso a la variable [cuerpo] en App.tsx
// Clase 50: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25790698#overview

import { useContext } from "react";
import ValorContext from "./ValorContext";
import Hijo from "./Hijo";

export default function Padre() {
  const valor = useContext(ValorContext);

  return (
    <>
      <h5>Componente Padre: el valor del Context es: {valor}</h5>
      <Hijo />
    </>
  );
}
