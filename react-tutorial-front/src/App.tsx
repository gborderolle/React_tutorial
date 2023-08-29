import React, { useState } from "react";
import "./App.css";
import MostrarTexto from "./MostrarTexto";
import BootCard from "./BootCard";
import Formulario from "./Formulario";
import ProyectarContenido from "./ProyectarContenido";
import ProyectarContenido2 from "./ProyectarContenido2";
import EjemploReloj from "./EjemploReloj";
import ContenidoDinamico from "./ContenidoDinamico";

function App() {

  const [titulo, setTitulo] = useState('[titulo]');
  const [cuerpo, setCuerpo] = useState('[cuerpo]');

  // const subtitulo = "Esto es un subtítulo";
  // const duplicar = (valor: number) => valor * 2; // función flecha

  // const manejarClick = () => console.log('Click!');

  const manejarKeyUpTexto = (e: React.KeyboardEvent<HTMLInputElement>) => {
    setCuerpo(e.currentTarget.value);
  }

  const manejarKeyUptitulo = (e: React.KeyboardEvent<HTMLInputElement>) => {
    setTitulo(e.currentTarget.value);
  }

  const parte2 = <EjemploReloj />
  const estilos = {
    backgroundColor: 'red', width: '50px', height: '50px'
  }
  const parte3 = <div style={estilos}></div>

  const calificaciones = [
    { nombre: 'Juanito', calificacion: 23 },
    { nombre: 'Maria', calificacion: 66 },
    { nombre: 'Roberto', calificacion: 86 },
    { nombre: 'Reinaldo', calificacion: 100 }
  ]


  return (
    <>

      {/* <ProyectarContenido2
        //parte1={<span>Este es un span del padre</span>}
        parte2={parte2}
        parte3={parte3}
        /> */}

      {calificaciones.map(cal => <ContenidoDinamico key={cal.nombre} {...cal} />)}

      {/* <ContenidoDinamico calificacion={calificaciones.cañ} nombre={"Ramón"}/> */}

      <br />
      <br />
      <form style={{ width: '40%' }}>
        <div className="form-group">
          <input type="text" className="form-control" onKeyUp={(e) => manejarKeyUptitulo(e)} id="exampleInputEmail1" placeholder="Título" />
        </div>
        <br />
        <div className="form-group">
          <input type="text" className="form-control" onKeyUp={(e) => manejarKeyUpTexto(e)} id="exampleInputPassword1" placeholder="Cuerpo" />
        </div>
        <br />
        <button type="submit" className="btn btn-primary">Submit</button>
      </form>

      <br />

      <MostrarTexto />
      <BootCard title={titulo} body={cuerpo} />
      <br />
      <Formulario />

    </>
  );
}

export default App;
