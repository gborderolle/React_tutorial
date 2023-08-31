import { Form, Formik, FormikHelpers } from "formik";
import FormGroupText from "../utils/FormGroupText";
import * as Yup from 'yup';
import { cinemaCreationDTO } from "./cinema.model";

export default function FormCinema(props: formCinemaProps) {
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
                    <FormGroupText buttonDisabled={formikProps.isSubmitting} formName="Crear cine" field="name" label="Nombre" navigation="/cinemas" />
                </Form>
            )}

        </Formik>

    )
}

interface formCinemaProps {
    model: cinemaCreationDTO;
    onSubmit(values: cinemaCreationDTO, action: FormikHelpers<cinemaCreationDTO>): void;

}