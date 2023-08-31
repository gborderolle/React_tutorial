import { Form, Formik, FormikHelpers } from "formik";
import FormGroupText from "../utils/FormGroupText";
import * as Yup from 'yup';
import { movieCreationDTO } from "../movies/movie.model";

export default function FormMovie(props: formMovieProps) {
    return (

        <Formik
            initialValues={{
                title: "",
            }}

            onSubmit={props.onSubmit}

            validationSchema={Yup.object({
                title: Yup.string()
                    .required('Dato requerido.')
                    .firstCharCapitalization()
            })}
        >

            {(formikProps) => (
                <Form>
                    <FormGroupText buttonDisabled={formikProps.isSubmitting} formName="Crear película" field="name" label="Nombre" navigation="/movies" />
                </Form>
            )}

        </Formik>

    )
}

interface formMovieProps {
    model: movieCreationDTO;
    onSubmit(values: movieCreationDTO, action: FormikHelpers<movieCreationDTO>): void;

}