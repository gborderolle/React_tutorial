import { useState, useEffect } from "react";

export default function EjemploReloj() {
  // Estado: datos de un componente que si son modificados renderiza el componente
  //const [fecha, setFecha] = useState(new Date()); // React Hook

  // useEffect es un React Hook: permite manejar los efectos secundarios de un componente
  /*   useEffect(() => {
    // Se ejecuta cada vez que renderiza el componente
    const timerId = setInterval(() => {
      setFecha(new Date());
    }, 1000);

    return () => clearInterval(timerId); // Ejecuta una función cuando se destruye el componente
  });
 */
  return (
    <div></div>
    /*  // JSX (Javascript XML)
    <div>
      <h3>Ejemplo React</h3>
      <input />
      <div>{fecha.toString()}</div>
    </div> */
  );
}
