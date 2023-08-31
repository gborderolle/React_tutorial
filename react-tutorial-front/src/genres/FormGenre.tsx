import { Form, Formik, FormikHelpers } from "formik";
import FormGroupText from "../utils/FormGroupText";
import * as Yup from 'yup';
import { genreCreationDTO } from "./genre.model";

export default function FormGenre(props: formGenreProps) {
    return (

        <Formik
            initialValues={{
                name: "",
            }}

            onSubmit={props.onSubmit}

            validationSchema={Yup.object({
                name: Yup.string()
                    .required('Dato requerido.')
                    .firstCharCapitalization()
            })}
        >

            {(formikProps) => (
                <Form>
                    <FormGroupText buttonDisabled={formikProps.isSubmitting} formName="Crear género" field="name" label="Nombre" navigation="/genres" />
                </Form>
            )}

        </Formik>

    )
}

interface formGenreProps {
    model: genreCreationDTO;
    onSubmit(values: genreCreationDTO, action: FormikHelpers<genreCreationDTO>): void;

}