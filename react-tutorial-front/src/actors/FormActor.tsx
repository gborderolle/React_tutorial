import { Form, Formik, FormikHelpers } from "formik";
import FormGroupText from "../utils/FormGroupText";
import * as Yup from 'yup';
import { actorCreationDTO } from "./actor.model";

export default function FormActor(props: formActorProps) {
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
                    <FormGroupText buttonDisabled={formikProps.isSubmitting} formName="Crear actor" field="name" label="Nombre" navigation="/actors" />
                </Form>
            )}

        </Formik>

    )
}

interface formActorProps {
    model: actorCreationDTO;
    onSubmit(values: actorCreationDTO, action: FormikHelpers<actorCreationDTO>): void;

}