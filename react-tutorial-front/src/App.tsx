// Configurar ruteo
// Clase 63: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858262#overview

import "./App.css";
import { movieDTO } from "./movies/movie.model";
import Menu from "./utils/Menu";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import paths from "./route-config";
import setupValidations from "./Validations";

setupValidations();

function App() {
  const movieTest: movieDTO = {
    id: 0,
    title: "",
    onCinema: true,
  };

  return (
    <>
      <BrowserRouter>
        <Menu />
        <div className="container" style={{ marginLeft: "100px" }}>
          <Routes>
            {paths.map((pathObj) => (
              <Route
                key={pathObj.path}
                path={pathObj.path}
                element={<pathObj.component />}
              />
            ))}
          </Routes>
        </div>
      </BrowserRouter>
    </>
  );
}

export default App;
