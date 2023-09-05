import { Field, Form, Formik } from "formik";
import { genreDTO } from "../genres/genre.model";
import Button from "../utils/Button";
import { urlGenres, urlMovies } from "../utils/endpoints";
import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { movieCreationDTO, movieDTO } from "./movie.model";
import ListMovies from "./ListMovies";

export default function FilterMovies() {

  const [genres, setGenres] = useState<genreDTO[]>([]);
  const [movies, setMovies] = useState<movieDTO[]>([]);

  const initialValues: filterMoviesForm = {
    title: "",
    genreId: 0,
    nextPremiere: false,
    onCinemas: false,
    page: 1,
    recordsPerPage: 10
  };

  useEffect(() => {
    const fetchGenres = async () => {
      const config = {
        headers: {
          "x-version": "2",
        },
      };
      try {
        let urlcompleta = `${urlGenres}/all`;
        const response: AxiosResponse<ApiResponse<any>> = await axios.get(
          urlcompleta,
          config
        );
        if (response && response.data && response.data.result) {
          setGenres(response.data.result);
        } else {
          throw new Error("Formato de datos inesperado de la API.");
        }
      } catch (error: any) {
        console.error(error);
      }
    };
    fetchGenres();
  }, []);

  useEffect(() => {
    searchMovies(initialValues);
  });

  function searchMovies(values: filterMoviesForm) {
    const search = async () => {
      const config = {
        headers: {
          "x-version": "2",
        },
      };
      try {
        let urlcompleta = `${urlMovies}/filter`;
        const response: AxiosResponse<ApiResponse<any>> = await axios.get(
          urlcompleta,
          config
        );
        if (response && response.data && response.data.result) {
          setMovies(response.data.result);
        } else {
          throw new Error("Formato de datos inesperado de la API.");
        }
      } catch (error: any) {
        console.error(error);
      }
    };
    search();
  }

  return (
    <>
      <div className="mt-4">
        <h3>Filtrar Películas</h3>

        <Formik
          initialValues={initialValues}
          onSubmit={values => console.log(values)}>

          {(formikProps) => (
            <Form>
              <div className="d-flex justify-content-between align-items-center mb-3">
                <div className="form-group">
                  <input type="text" className="form-control" id="title" placeholder="Título de la película" {...formikProps.getFieldHelpers('title')} />
                </div>
                <div className="form-group mx-sm-3">
                  <select className="form-control" {...formikProps.getFieldHelpers('genreId')}>
                    <option value="0">--Seleccione un género</option>
                    {genres.map(genre => <option key={genre.id} value={genre.id}>{genre.name}</option>)}
                  </select>
                </div>
                <div className="form-check mx-sm-3">
                  <Field type="checkbox" id="nextPremiere" name="nextPremiere" className="form-check-input" />
                  <label className="form-check-label" htmlFor="nextPremiere">Próximos estrenos</label>
                </div>
                <div className="form-check mx-sm-3">
                  <Field type="checkbox" id="onCinemas" name="onCinemas" className="form-check-input" />
                  <label className="form-check-label" htmlFor="onCinemas">En cines</label>
                </div>
                <div className="d-flex">
                  <Button className="btn btn-primary mx-2" onClick={() => formikProps.submitForm()}>Filtrar</Button>
                  <Button className="btn btn-danger mx-2" onClick={() => formikProps.setValues(initialValues)}>Limpiar</Button>
                </div>
              </div>
            </Form>
          )}

        </Formik>

        <ListMovies movies={movies} />

      </div>
    </>
  );
}

interface filterMoviesForm {
  title: string;
  genreId: number;
  nextPremiere: boolean;
  onCinemas: boolean;
  page: 1;
  recordsPerPage: 10;
}

interface ApiResponse<T> {
  isSuccess: boolean;
  result: T;
}
