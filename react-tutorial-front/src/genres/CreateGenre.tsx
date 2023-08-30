import { useNavigate } from "react-router-dom";
import Button from "../utils/Button";
import { Field, Formik, Form } from "formik";
import { Link } from "react-router-dom";

export default function CreateGenre() {
  //   const navigate = useNavigate();
  return (
    <>
      <h3>Crear Género</h3>

      <Formik
        initialValues={{
          name: "",
        }}
        onSubmit={(values) => {
          console.log(values);
        }}
      >
        <Form>
          <div className="form-group">
            <label htmlFor="name">Nombre</label>
            <Field name="name" className="form-control" />
          </div>
          <Button type="submit">Guardar</Button>
          <Link className="btn btn-secondary" to="/genres">
            Cancelar
          </Link>
        </Form>
      </Formik>
    </>
  );
}
