import React, { useState } from "react";
import "./App.css";
import MostrarTexto from "./MostrarTexto";
import BootCard from "./BootCard";
import Formulario from "./Formulario";
import ProyectarContenido from "./ProyectarContenido";
import ProyectarContenido2 from "./ProyectarContenido2";
import EjemploReloj from "./EjemploReloj";
import ContenidoDinamico from "./ContenidoDinamico";
import FormularioTexto from "./FormularioTexto";
import EjemploUseEffects from "./EjemploUseEffects";
import ValorContext from "./ValorContext";
import Abuelo from "./Abuelo";
import ErrorBoundary from "./ErrorBoundary";

function App() {
  const [titulo, setTitulo] = useState("[titulo]");
  const [cuerpo, setCuerpo] = useState("[cuerpo]");

  const [checked, setChecked] = useState(true);

  // const subtitulo = "Esto es un subtítulo";
  // const duplicar = (valor: number) => valor * 2; // función flecha

  // const manejarClick = () => console.log('Click!');

  const manejarKeyUpTexto = (e: React.KeyboardEvent<HTMLInputElement>) => {
    setCuerpo(e.currentTarget.value);
  };

  const manejarKeyUpTitulo = (textoInput: string) => {
    setTitulo(textoInput);
  };

  const parte2 = <EjemploReloj />;
  const estilos = {
    backgroundColor: "red",
    width: "50px",
    height: "50px",
  };
  const parte3 = <div style={estilos}></div>;

  const calificaciones = [
    { nombre: "Juanito", calificacion: 23 },
    { nombre: "Maria", calificacion: 66 },
    { nombre: "Erraldo", calificacion: -2 },
    { nombre: "Roberto", calificacion: 86 },
    { nombre: "Reinaldo", calificacion: 100 },
  ];

  return (
    <>
      <h1 className="h1Clase">Clase 51</h1>
      {calificaciones.map((cal) => (
        <ErrorBoundary key={cal.nombre}>
          <ContenidoDinamico {...cal} />
        </ErrorBoundary>
      ))}

      <h1 className="h1Clase">Clase 50</h1>
      <ValorContext.Provider value={cuerpo}>
        <Abuelo />
      </ValorContext.Provider>

      <hr />
      <h1 className="h1Clase">Clase 42</h1>
      <ProyectarContenido2
        parte1={<span>Este es un span del padre</span>}
        parte2={parte2}
        parte3={parte3}
      />
      <hr />
      <h1 className="h1Clase">Clase 46</h1>

      {/* {calificaciones.map((cal) => (
        <ContenidoDinamico key={cal.nombre} {...cal} />
      ))} */}

      {/* <ContenidoDinamico calificacion={calificaciones.cañ} nombre={"Ramón"}/> */}
      <br />
      <hr />
      <h1 className="h1Clase">Clase 47</h1>
      <form style={{ width: "40%" }}>
        <FormularioTexto
          manejarKeyUpTitulo={(e: string) => manejarKeyUpTitulo(e)}
        />
        <br />
        <div className="form-group">
          <input
            type="text"
            className="form-control"
            onKeyUp={(e) => manejarKeyUpTexto(e)}
            id="exampleInputPassword1"
            placeholder="Cuerpo"
          />
        </div>
        <br />
        <hr />
        <h1 className="h1Clase">Clase 49</h1>
        <div>
          <input
            type="checkbox"
            className="checkbox"
            onChange={(e) => setChecked(e.currentTarget.checked)}
            checked={checked}
          />{" "}
          Mostrar useEffect
        </div>
        {checked ? <EjemploUseEffects /> : "no se muestra =("}
      </form>

      <hr />
      <h1 className="h1Clase">Clase 41</h1>
      <MostrarTexto />

      <hr />
      <h1 className="h1Propio">Bootstrap</h1>
      <BootCard title={titulo} body={cuerpo} />
      <br />
      <hr />
      <hr />
      <h1 className="h1Propio">Bootstrap</h1>
      <Formulario />
    </>
  );
}

export default App;
