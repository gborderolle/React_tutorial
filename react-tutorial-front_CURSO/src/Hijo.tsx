// useContext: una especie de patrón de diseño Observer
// Clase 50: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25790698#overview

import { useContext } from "react";
import ValorContext from "./ValorContext";

export default function Hijo() {
  const valor = useContext(ValorContext);

  return (
    <>
      <h5>Componente Hijo: el valor del Context es: {valor}</h5>
    </>
  );
}
