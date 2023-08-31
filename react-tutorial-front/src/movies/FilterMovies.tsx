import { Field, Form, Formik } from "formik";
import { genreDTO } from "../genres/genre.model";
import Button from "../utils/Button";

export default function FilterMovies() {
  const initialValues: filterMoviesForm = {
    title: "",
    genreId: 0,
    nextPremiere: false,
    onCinemas: false
  };

  const genres: genreDTO[] = [
    { id: 1, name: 'Acción' },
    { id: 2, name: 'Drama' },
    { id: 3, name: 'Terror' }
  ];

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
      </div>
    </>
  );
}

interface filterMoviesForm {
  title: string;
  genreId: number;
  nextPremiere: boolean;
  onCinemas: boolean;
}
