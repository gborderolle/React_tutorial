import { Form, Formik, FormikHelpers } from "formik";
import { userCredential } from "./auth.model";
import * as Yup from 'yup';
import FormGroupText from "../utils/FormGroupText";
import { Link } from "react-router-dom";
import Button from "../utils/Button";

export default function FormAuth(props: formAuthProps) {
    return (
        <Formik initialValues={props.model}
            onSubmit={props.onSubmit}
            validationSchema={Yup.object({
                email: Yup
                    .string()
                    .required('Dato requerido.')
                    .email('Email inválido.'),
                password: Yup
                    .string()
                    .required('Dato requerido.'),
            })}
        >

            {formikProps => (
                <Form>
                    <FormGroupText label="Email" field="email" />
                    <FormGroupText label="Password" field="password" type="password" />
                    <Button disabled={formikProps.isSubmitting} type="submit">Confirmar</Button>
                    <Link className="btn btn-secondary btn-sm ms-2" to="/">Cancelar</Link>
                </Form>
            )}

        </Formik>
    );
}

interface formAuthProps {
    model: userCredential;
    onSubmit(values: userCredential, actions: FormikHelpers<userCredential>): void;
}