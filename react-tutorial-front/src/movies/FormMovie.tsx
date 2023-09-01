import { Form, Formik, FormikHelpers } from "formik";
import FormGroupText from "../utils/FormGroupText";
import * as Yup from 'yup';
import { movieCreationDTO } from "../movies/movie.model";
import { Link } from "react-router-dom";
import Button from "../utils/Button";
import FormGroupCheckbox from "../utils/FormGroupCheckbox";
import FormGroupDate from "../utils/FormGroupDate";
import FormGroupImage from "../utils/FormGroupImage";

export default function FormMovie(props: formMovieProps) {
    return (

        <Formik
            initialValues={props.model}
            onSubmit={props.onSubmit}
            validationSchema={Yup.object({
                title: Yup.string()
                    .required('Dato requerido.')
                    .firstCharCapitalization()
            })}
        >
            {(formikProps) => (

                <Form>
                    <div className="mt-4">
                        <div className="card text-white bg-secondary mb-3" style={{ maxWidth: "20rem" }}>

                            <div className="card-header"><h3>{props.formName}</h3></div>
                            <div className="card-body">

                                <FormGroupText formName={props.formName} field="title" label="Nombre" />
                                <FormGroupCheckbox field="onCinema" label="En cines" />
                                <FormGroupText formName={props.formName} field="trailer" label="Trailer" />
                                <FormGroupDate field={"premiereDate"} label={"Fecha lanzamiento"} />
                                <FormGroupImage field={"poster"} label={"Poster"} imageURL={props.model.posterURL} />
                                <br />
                                <div className="btn-group" role="group" aria-label="First group">
                                    <Button type="submit" disabled={formikProps.isSubmitting}>
                                        Guardar
                                    </Button>
                                    <Link className="btn btn-sm btn-secondary" to="/">
                                        Cancelar
                                    </Link>
                                </div>

                            </div>
                        </div>

                    </div>

                </Form>
            )}

        </Formik>

    )
}

interface formMovieProps {
    model: movieCreationDTO;
    formName: string;
    onSubmit(values: movieCreationDTO, action: FormikHelpers<movieCreationDTO>): void;
}