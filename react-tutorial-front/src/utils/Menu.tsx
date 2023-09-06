import { Link, NavLink } from "react-router-dom";
import Authorized from "../auth/Authorized";
import { logout } from "../auth/ManageJWT";
import Button from "./Button";
import { useContext } from "react";
import AuthenticationContext from "../auth/AuthenticationContext";

export default function Menu() {
  const { update, claims } = useContext(AuthenticationContext);

  function getUsername(): string {
    return claims.filter(x => x.name === "email")[0]?.value;
  }

  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container-fluid">
        <NavLink
          className={({ isActive }) =>
            isActive ? "navbar-brand active" : "navbar-brand"
          }
          to="/"
        >
          React Películas
        </NavLink>

        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarContent"
          aria-controls="navbarContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarContent" style={{ display: 'flex', justifyContent: 'space-between' }}>
          <ul className="navbar-nav me-auto mb-2 mb-lg-0">
            <li className="nav-item">
              <NavLink
                className={({ isActive }) =>
                  isActive ? "nav-link active" : "nav-link"
                }
                to="/genres"
              >
                Géneros
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink
                className={({ isActive }) =>
                  isActive ? "nav-link active" : "nav-link"
                }
                to="/movies"
              >
                Películas
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink
                className={({ isActive }) =>
                  isActive ? "nav-link active" : "nav-link"
                }
                to="/actors"
              >
                Actores
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink
                className={({ isActive }) =>
                  isActive ? "nav-link active" : "nav-link"
                }
                to="/cinemas"
              >
                Cines
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink
                className={({ isActive }) =>
                  isActive ? "nav-link active" : "nav-link"
                }
                to="/reviews"
              >
                Reviews
              </NavLink>
            </li>
            <Authorized
              role="admin"
              authorized={
                <>
                  <li className="nav-item">
                    <NavLink
                      className={({ isActive }) =>
                        isActive ? "nav-link active" : "nav-link"
                      }
                      to="/reviews"
                    >
                      Administración
                    </NavLink>
                  </li>
                </>
              }
            ></Authorized>
          </ul>
          <div className="d-flex">
            <Authorized
              authorized={<>
                <span className="nav-link">Hola, {getUsername()}!</span>
                <Button
                  onClick={() => {
                    logout();
                    update([]);
                  }}
                  className="nav-link btn btn-link">Log out</Button>
              </>}
              unauthorized={<>
                <Link to="/register" className="nav-link btn btn-link me-2">Registro</Link>
                <Link to="/login" className="nav-link btn btn-link">Login</Link>
              </>
              }
            />
          </div>

        </div>
      </div>
    </nav>
  );
}
