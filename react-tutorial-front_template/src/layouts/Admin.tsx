import React, { useEffect, useRef, useState } from "react";
import { Route, Routes, useLocation } from "react-router-dom"; // Switch cambiado por Routes
import routes from "../routes.js";

const Admin: React.FC = () => {
  const location = useLocation();
  const mainPanel = useRef<HTMLDivElement>(null);

  const getRoutes = (routes: RouteItem[]) => {
    console.log(routes);
    return routes.map((prop, key) => {
      if (prop.layout === "/admin") {
        return (
          <Route
            key={key}
            path={prop.path}
            // path={prop.layout + prop.path}
            element={React.createElement(prop.component)}
            // element={<prop.component {...prop} />}
            // render={(props: any) => <prop.component {...props} />}
          />
        );
      } else {
        return null;
      }
    });
  };

  useEffect(() => {
    document.documentElement.scrollTop = 0;
    document.scrollingElement!.scrollTop = 0;
    if (mainPanel.current) {
      mainPanel.current.scrollTop = 0;
    }

    if (
      window.innerWidth < 993 &&
      document.documentElement.className.indexOf("nav-open") !== -1
    ) {
      document.documentElement.classList.toggle("nav-open");
      let element = document.getElementById("bodyClick");
      if (element) {
        element.parentNode!.removeChild(element);
      }
    }
  }, [location]);

  // Admin es el Layout general
  // Los componentes los carga con getRoutes()
  return (
    <>
      <Routes>{getRoutes(routes)}</Routes>
    </>
  );
};

export default Admin;

interface RouteItem {
  layout: string;
  path: string;
  component: React.ElementType;
  // Otras propiedades que puedan tener tus rutas
}
