import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';

function App() {

  // Estado: datos de un componente que si son modificados renderiza el componente
  const [fecha, setFecha] = useState(new Date());

  // useEffect es un ReactHook: permite manejar los efectos secundarios de un componente
  useEffect(() => {
    const timerId = setInterval(()=>{
      setFecha(new Date());
    }, 1000)

    return () => clearInterval(timerId);
  })

  return (
    <div>
      
      <h3>Ejemplo React</h3>
        <input/>
        <div>{fecha.toString()}</div>

    </div>
  );
}

export default App;
