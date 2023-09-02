import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { genreDTO } from "./genre.model";
import axios, { AxiosResponse } from "axios";
import { urlGenres } from "../utils/endpoints";
import GenericList from "../utils/GenericList";
import Button from "../utils/Button";
import Pagination from "../utils/Pagination";
import Nbsp from "../utils/nbsp";

export default function IndexGenres() {
  const [genres, setGenres] = useState<genreDTO[]>([]);
  const [totalPages, setTotalPages] = useState(0);
  const [recordsPerPage, setRecordsPerPage] = useState(10);
  const [page, setPage] = useState(1);

  useEffect(() => {
    axios
      .get(urlGenres, {
        headers: {
          "x-version": "2",
        },
        params: {
          page,
          recordsPerPage: recordsPerPage,
        },
      })
      .then((response: AxiosResponse) => {
        console.log(response.data);
        if (response.data.isSuccess && Array.isArray(response.data.result)) {
          const totalRows = parseInt(response.headers["totalsizerecords"], 10); // (todo en minúsculas acá) nombre de la variable en Header de la cantidad total de resutlados en la API
          setTotalPages(Math.ceil(totalRows / recordsPerPage));
          setGenres(response.data.result);
        } else {
          console.error("Unexpected data format from the API.");
        }
      })
      .catch((error) => {
        console.error(error);
      });
  }, [page, recordsPerPage]);

  return (
    <div className="mt-4">
      <div
        className="card text-white bg-secondary mb-3"
        style={{ maxWidth: "50rem" }}
      >
        <div className="card-header">
          <h3>Géneros</h3>
        </div>
        <div className="card-body">
          <ol className="list-group list-group-numbered">
            <li className="list-group-item d-flex justify-content-between align-items-start">
              <div className="ms-2 me-auto">
                <Link to="/genres/create">Crear</Link>
              </div>
            </li>
            <li className="list-group-item d-flex justify-content-between align-items-start">
              <div className="ms-2 me-auto">
                <Link to="/genres/edit">Modificar</Link>
              </div>
            </li>
            <li className="list-group-item d-flex justify-content-between align-items-start">
              <div className="ms-2 me-auto w-100">
                <label>Listado:</label>

                <GenericList list={genres}>
                  <table className="table table-stripped">
                    <thead>
                      <tr>
                        <th>#</th>
                        <th>Nombre</th>
                        <th>Acciones</th>
                      </tr>
                    </thead>
                    <tbody>
                      {Array.isArray(genres) &&
                        genres.map((genre, index) => (
                          <tr key={genre.id}>
                            <td>{index + 1}</td>
                            <td>{genre.name}</td>
                            <td>
                              <Link
                                className="btn btn-success"
                                to={`/genres/${genre.id}`}
                              >
                                Editar
                              </Link>
                              <Button className="btn btn-danger">Borrar</Button>
                            </td>
                          </tr>
                        ))}
                    </tbody>
                  </table>
                </GenericList>
                <div
                  className="form-group"
                  style={{ display: "inline-flex", alignItems: "center" }}
                >
                  <label>Cantidad</label>
                  <Nbsp />
                  <select
                    className="form-control"
                    defaultValue={10}
                    style={{ width: "60px" }}
                    onChange={(e) => {
                      setPage(1);
                      setRecordsPerPage(parseInt(e.currentTarget.value, 10));
                    }}
                  >
                    <option value={2}>2</option>
                    <option value={10}>10</option>
                    <option value={25}>25</option>
                    <option value={50}>50</option>
                  </select>
                </div>
                <Pagination
                  totalPages={totalPages}
                  actualPage={page}
                  onChange={(newPage) => {
                    setPage(newPage);
                  }}
                />
              </div>
            </li>
          </ol>
        </div>
      </div>
    </div>
  );
}
