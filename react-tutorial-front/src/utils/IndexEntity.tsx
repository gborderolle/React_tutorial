import axios, { isAxiosError, AxiosResponse } from "axios";
import { ReactElement, useEffect, useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import Pagination from "./Pagination";
import Button from "./Button";
import GenericList from "./GenericList";
import showConfirm from "./ShowConfirm";

export default function IndexEntity<T>(props: indexEntityProps<T>) {
  const navigate = useNavigate();
  const [entities, setEntities] = useState<T[]>();
  const [totalPages, setTotalPages] = useState(0);
  const [recordsPerPage, setRecordsPerPage] = useState(10);
  const [page, setPage] = useState(1);
  const [errors, setErrors] = useState<string[]>([]);

  useEffect(() => {
    loadData();
  }, [page, recordsPerPage]);

  async function deleteEntity(id: number) {
    try {
      const response = await axios.delete(`${props.url}/${id}`, {
        headers: {
          "x-version": "2",
        },
      });
      loadData();
    } catch (error) {
      if (isAxiosError(error) && error.response) {
        setErrors(error.response.data);
      } else {
        setErrors(["An unexpected error occurred."]);
      }
    }
    navigate(props.url);
  }

  function loadData() {
    axios
      .get(props.url, {
        headers: {
          "x-version": "2",
        },
        params: {
          page,
          recordsPerPage,
        },
      })
      .then((response: AxiosResponse) => {
        if (response.data.isSuccess && Array.isArray(response.data.result)) {
          const totalRows = parseInt(response.headers["totalsizerecords"], 10); // (todo en minúsculas acá) nombre de la variable en Header de la cantidad total de resutlados en la API
          setTotalPages(Math.ceil(totalRows / recordsPerPage));
          setEntities(response.data.result);
        } else {
          console.error("Unexpected data format from the API.");
        }
      })
      .catch((error) => {
        setErrors(error.response.data);
      });
  }

  const buttons = (urlEdit: string, id: number) => (
    <>
      <Link className="btn btn-success" to={urlEdit}>
        Editar
      </Link>
      <Button
        className="btn btn-danger"
        onClick={() => showConfirm(() => deleteEntity(id))}
      >
        Borrar
      </Button>
    </>
  );

  return (
    <div className="mt-4">
      <div
        className="card text-white bg-secondary mb-3"
        style={{ maxWidth: "50rem" }}
      >
        <div className="card-header">
          <h3>{props.title}</h3>
        </div>
        <div className="card-body">
          <ol className="list-group list-group-numbered">
            <li className="list-group-item d-flex justify-content-between align-items-start">
              <div className="ms-2 me-auto">
                <Link to={props.urlCreate}>Crear {props.entityName}</Link>
              </div>
            </li>
            <li className="list-group-item d-flex justify-content-between align-items-start">
              <div className="ms-2 me-auto w-100">
                <label>Listado:</label>

                <GenericList list={entities}>
                  <table className="table table-stripped">
                    {props.children(entities!, buttons)}
                  </table>
                </GenericList>

                <div
                  className="form-group"
                  style={{ display: "inline-flex", alignItems: "center" }}
                >
                  <label>Cantidad</label>
                  <select
                    className="form-control"
                    defaultValue={10}
                    style={{ width: "60px" }}
                    onChange={(e) => {
                      setPage(1);
                      setRecordsPerPage(parseInt(e.currentTarget.value, 10));
                    }}
                  >
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

interface indexEntityProps<T> {
  url: string;
  urlCreate: string;
  children(
    entities: T[],
    buttons: (urlEdit: string, id: number) => ReactElement
  ): ReactElement;
  title: string;
  entityName: string;
}
