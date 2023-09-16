// Configurar ruteo
// Clase 63: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25858262#overview

import { BrowserRouter, Route, Routes } from "react-router-dom";
import setupValidations from "./Validations";
import { useEffect, useRef, useState } from "react";
import { claim } from "./auth/auth.model";
import AuthenticationContext from "./auth/AuthenticationContext";
import { getClaims } from "./auth/ManageJWT";
import { setupInterceptor } from "./utils/Interceptors";
import React from "react";
import paths from "./route-config";

import "bootstrap/dist/css/bootstrap.min.css";
import "./assets/css/animate.min.css";
import "./assets/scss/light-bootstrap-dashboard-react.scss?v=2.0.0";
import "./assets/css/demo.css";
import "@fortawesome/fontawesome-free/css/all.min.css";
import Sidebar from "./components/Sidebar/Sidebar";
import AdminNavbar from "./components/Navbars/AdminNavbar";
import Footer from "./utils/Footer";
import FixedPlugin from "./components/FixedPlugin/FixedPlugin";
import routes from "./routes";

import sidebarImage from "./assets/img/sidebar-3.jpg";

setupValidations();
setupInterceptor();

function App() {
  const [image, setImage] = useState<string>(sidebarImage);
  const [color, setColor] = useState<string>("black");
  const [hasImage, setHasImage] = useState<boolean>(true);
  const mainPanel = useRef<HTMLDivElement>(null);

  const [claims, setClaims] = useState<claim[]>([
    // { name: "email", value: "felipe@hotmail.com" },
    // { name: "role", value: "admin" },
  ]);

  useEffect(() => {
    setClaims(getClaims());
  }, []);

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
        {/* AuthenticationContext.Provider: Para que toda la app tenga acceso al estado de claims */}
        <AuthenticationContext.Provider value={{ claims, update }}>
          {/* <Menu />
          <div className="container" style={{ marginLeft: "100px" }}> */}

          <div className="wrapper">
            <Sidebar
              color={color}
              image={hasImage ? image : ""}
              routes={routes}
            />
            <div className="main-panel" ref={mainPanel}>
              <AdminNavbar />
              <div className="content">
                <Routes>
                  {/* Lógica de Ruteo 1 */}
                  {paths.map((path) => (
                    <Route
                      key={path.path}
                      path={path.path}
                      element={
                        path.isAdmin && !isAdmin() ? (
                          <div className="alert alert-warning">
                            Su usuario no tiene autorización.
                          </div>
                        ) : (
                          React.createElement(path.component)
                        )
                      }
                    />
                  ))}
                </Routes>
              </div>
              <Footer />
            </div>
          </div>
          <FixedPlugin
            hasImage={hasImage}
            setHasImage={() => setHasImage(!hasImage)}
            color={color}
            setColor={(color: string) => setColor(color)}
            image={image}
            setImage={(image: string) => setImage(image)}
          />

          {/* </div>
          <Footer /> */}
        </AuthenticationContext.Provider>
      </BrowserRouter>
    </>
  );
}

export default App;
