// Ejemplo useEffect
// Clase 49: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25790412#overview

import { useEffect, useState } from "react";

export default function FormularioTexto() {
  const [clicks, setClicks] = useState(0);

  useEffect(() => {
    document.title = `${clicks} veces.`;

    return () => {
      console.log("El componente se destruyó.");
    };
  }, [clicks]); // [] el useEffect se ejecuta sólo si "clicks" cambia

  useEffect(() => {
    console.log("Ejecuto sólo una vez.");
  }, []); // si [] está vacío se ejecuta una única vez

  return (
    <>
      <button
        type="button"
        onClick={() => setClicks(clicks + 1)}
        className="btn btn-primary"
      >
        Cantidad: {clicks}
      </button>
    </>
  );
}
