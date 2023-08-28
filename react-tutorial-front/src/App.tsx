import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";

function App() {
  const subtitulo = "Esto es un subtítulo";
const duplicar = (valor: number) =>valor*2;

  return (
    <div>
      <h1>Hola Mundo!</h1>
      <h3>{subtitulo.toUpperCase()}</h3>
      <h4>El doble de 3 es {duplicar(3)}</h4>
    </div>
  );
}

export default App;
