import React, { useEffect, useRef, useState } from "react";
import { Route, Routes, useLocation } from "react-router-dom";  // Switch cambiado por Routes
import AdminNavbar from "../components/Navbars/AdminNavbar";
import Footer from "../components/Footer/Footer";
import Sidebar from "../components/Sidebar/Sidebar";
import FixedPlugin from "../components/FixedPlugin/FixedPlugin.js";
import routes from "../routes.js";

// Asumiendo que el archivo de imagen está presente en esta ubicación.
import sidebarImage from "../assets/img/sidebar-3.jpg";
// assets/img/sidebar-3.jpg";

const Admin: React.FC = () => {
  const [image, setImage] = useState<string>(sidebarImage);
  const [color, setColor] = useState<string>("black");
  const [hasImage, setHasImage] = useState<boolean>(true);
  const location = useLocation();
  const mainPanel = useRef<HTMLDivElement>(null);

  const getRoutes = (routes: RouteItem[]) => {
    return routes.map((prop, key) => {
      if (prop.layout === "/admin") {
        return (
          <Route
            key={key}
            path={prop.layout + prop.path}
            element={React.createElement(prop.component)}
          // render={(props) => <prop.component {...props} />}
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
    mainPanel.current!.scrollTop = 0;

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

  return (
    <>
      <div className="wrapper">
        <Sidebar color={color} image={hasImage ? image : ""} routes={routes} />
        <div className="main-panel" ref={mainPanel}>
          <AdminNavbar />
          <div className="content">
            <Routes>

              {getRoutes(routes)}

            </Routes>
          </div>
          <Footer />
        </div>
      </div>
      <FixedPlugin
        hasImage={hasImage}
        setHasImage={() => setHasImage(!hasImage)}
        color={color}
        setColor={(color: string) => setColor(color)}  // Tipo explícito para color
        image={image}
        setImage={(image: string) => setImage(image)}  // Tipo explícito para image
      />
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
