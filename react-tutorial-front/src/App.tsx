// Configurar ruteo
// Clase 63: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858262#overview

import "./App.css";
import { landingPageDTO, movie } from "./movies/movie.model";
import Menu from "./utils/Menu";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import paths from "./route-config";

function App() {

  const movieTest: movie = {
    id: 1,
    title: "Spider Man",
    description:
      "Spider-Man seeks the help of Doctor Strange to forget his exposed secret identity as Peter Parker. However, Strange's spell goes horribly wrong, leading to unwanted guests entering their universe.",
    poster:
      "https://upload.wikimedia.org/wikipedia/en/2/21/Web_of_Spider-Man_Vol_1_129-1.png",
  };

  return (
    <>
      <BrowserRouter>
        <Menu />
        <div className="container">

          <Routes>
            {paths.map(pathObj => (
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
