import { Link, NavLink, Navigate, useNavigate } from "react-router-dom";
import Authorized from "../auth/Authorized";
import { logout } from "../auth/ManageJWT";
import Button from "./Button";
import { useContext } from "react";
import AuthenticationContext from "../auth/AuthenticationContext";
import Swal from "sweetalert2";
import showSuccess from "../messages/ShowSuccess";

export default function Menu() {
  const navigate = useNavigate(); // sirve para navegar entre las páginas
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
            <Authorized
              role="admin"
              authorized={
                <>
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
                  <li className="nav-item">
                    <NavLink
                      className={({ isActive }) =>
                        isActive ? "nav-link active" : "nav-link"
                      }
                      to="/users"
                    >
                      Administración
                    </NavLink>
                  </li>
                </>
              }
            ></Authorized>
            <li className="nav-item">
              <NavLink
                className={({ isActive }) =>
                  isActive ? "nav-link active" : "nav-link"
                }
                to="/filter"
              >
                Filtrar películas
              </NavLink>
            </li>
          </ul>
          <div className="d-flex">
            <Authorized
              authorized={<>
                <span className="nav-link">Hola, {getUsername()}!</span>
                <Button
                  onClick={() => {
                    logout();
                    update([]);

                    showSuccess('Logout correcto');
                    setTimeout(() => {
                      navigate("/");
                    }, 2000);
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
