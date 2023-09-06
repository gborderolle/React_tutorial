// Configurar ruteo
// Clase 63: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858262#overview

import "./App.css";
import Menu from "./utils/Menu";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import paths from "./route-config";
import setupValidations from "./Validations";
import Footer from "./utils/Footer";
import { useEffect, useState } from "react";
import { claim } from "./auth/auth.model";
import AuthenticationContext from "./auth/AuthenticationContext";
import React from "react";
import { getClaims } from "./auth/ManageJWT";

setupValidations();

function App() {
  const [claims, setClaims] = useState<claim[]>([
    // { name: "email", value: "felipe@hotmail.com" },
    // { name: "role", value: "admin" },
  ]);

  useEffect(() => {
    setClaims(getClaims());
  }, [])

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
              {paths.map((path) => (
                <Route
                  key={path.path}
                  path={path.path}
                  element={
                    path.isAdmin && !isAdmin() ? (
                      <div>No tiene permiso</div>
                    ) : (
                      React.createElement(path.component)
                    )
                  }
                />
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
