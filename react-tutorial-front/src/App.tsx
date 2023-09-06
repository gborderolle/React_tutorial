// Configurar ruteo
// Clase 63: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858262#overview

import "./App.css";
import { movieDTO } from "./movies/movie.model";
import Menu from "./utils/Menu";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import paths from "./route-config";
import setupValidations from "./Validations";
import Footer from "./utils/Footer";
import { useState } from "react";
import { claim } from "./auth/auth.model";
import AuthenticationContext from "./auth/AuthenticationContext";

setupValidations();

function App() {
  const [claims, setClaims] = useState<claim[]>([
    { name: "email", value: "felipe@hotmail.com" },
    // { name: "role", value: "admin" },
  ]);

  function update(claims: claim[]) {
    setClaims(claims);
  }

  function isAdmin() {
    return (
      claims.findIndex(
        (claim) => claim.name === "role" && claim.value === "admin"
      ) > -1
    );
  }

  return (
    <>
      <BrowserRouter>
        <AuthenticationContext.Provider value={{ claims, update }}>
          <Menu />
          <div className="container" style={{ marginLeft: "100px" }}>
            <Routes>
              {paths.map((pathObj) => (
                <Route
                  key={pathObj.path}
                  path={pathObj.path}
                  element={<pathObj.component />}
                >
                  {pathObj.isAdmin && !isAdmin() ? (
                    <>No tiene permiso</>
                  ) : (
                    <>Sí</>
                  )}
                </Route>
              ))}
            </Routes>
          </div>
          <Footer />
        </AuthenticationContext.Provider>
      </BrowserRouter>
    </>
  );
}

export default App;
